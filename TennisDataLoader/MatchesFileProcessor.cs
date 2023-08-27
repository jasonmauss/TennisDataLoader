using CsvHelper;
using MongoDB.Driver.Core.Events;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisDataLoader.ClassCsvMaps;
using TennisDataLoader.Models;
using System.Configuration;
using System.Globalization;

namespace TennisDataLoader
{
    public class MatchesFileProcessor : DataFileProcessor
    {
        public MatchesFileProcessor() { }

        public async override void ProcessFile(string filePath)
        {
            try
            {
                base.ProcessFile(filePath);

                MongoClient mongoClient = CreateMongoClient();

                string fileYear = getYearFromFileName(filePath);

                var database = mongoClient.GetDatabase("ATPTennis");
                string collectionName = $"Matches_{fileYear}";

                bool collectionExists = database.ListCollectionNames().ToList().Contains(collectionName);
                if(!collectionExists)
                {
                    await database.CreateCollectionAsync(collectionName);
                }

                var collection = database.GetCollection<ATPMatch>(collectionName);

                // This will basically "truncate" the table/collection, but preserve
                // the indexes
                if (collectionExists)
                {
                    await collection.DeleteManyAsync(Builders<ATPMatch>.Filter.Empty);
                }

                List<ATPMatch> matches;

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<ATPMatchMap>();
                    matches = csv.GetRecords<ATPMatch>().ToList();
                }

                await collection.InsertManyAsync(matches);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error occurred while processing Match CSV data file: { filePath } ", ex);
            }
        }

        private string getYearFromFileName(string filePath)
        {
            int lengthOfPath = Path.GetFileNameWithoutExtension(filePath).Length;
            return Path.GetFileNameWithoutExtension(filePath).Substring(lengthOfPath - 4);
        }

        private MongoClient CreateMongoClient()
        {
            return new MongoClient(

                new MongoClientSettings
                {
                    Server = new MongoServerAddress("localhost", 27017),
                    ClusterConfigurator = builder =>
                    {
                        builder.Subscribe(new SingleEventSubscriber<CommandStartedEvent>(CmdStartHandlerForDeleteManyCommand));
                        builder.Subscribe(new SingleEventSubscriber<CommandSucceededEvent>(CmdSucceededHandlerForDeleteManyCommand));
                    }
                }
            );
        }

        private void CmdStartHandlerForDeleteManyCommand(CommandStartedEvent commandStartedEvent)
        {
            if (commandStartedEvent.CommandName == "delete")
            {
                System.Diagnostics.Debug.WriteLine("Delete Started = " + commandStartedEvent.Command);
            }
        }

        private void CmdSucceededHandlerForDeleteManyCommand(CommandSucceededEvent commandSucceededEvent)
        {
            if (commandSucceededEvent.CommandName == "delete")
            {
                System.Diagnostics.Debug.WriteLine("Delete Succeeded = " + commandSucceededEvent.Reply);
            }
        }

    }
}
