using CsvHelper;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisDataLoader.ClassCsvMaps;
using TennisDataLoader.Models;

namespace TennisDataLoader
{
    public class PlayersFileProcessor : DataFileProcessor
    {
        public PlayersFileProcessor() { }

        public async override void ProcessFile(string filePath)
        {
            base.ProcessFile(filePath);

            MongoClient mongoClient = CreateMongoClient();

            var database = mongoClient.GetDatabase("ATPTennis");
            var collection = database.GetCollection<ATPPlayer>("Players");

            // This will basically "truncate" the table/collection, but preserve
            // the indexes
            await collection.DeleteManyAsync(Builders<ATPPlayer>.Filter.Empty);

            List<ATPPlayer> players;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ATPPlayerMap>();
                players = csv.GetRecords<ATPPlayer>().ToList();
            }

            await collection.InsertManyAsync(players);

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
            if(commandStartedEvent.CommandName == "delete")
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
