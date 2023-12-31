using System.Reflection;
using TennisDataLoader.Extensions;

namespace TennisDataLoader;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Set all of the year checkboxes to have a checked state
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSelectAllYears_Click(object sender, EventArgs e)
    {
        ToggleAllMatchYearCheckboxes(true);
    }

    /// <summary>
    /// Set all of the year checkboxes to have an unchecked state
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSelectNoYears_Click(object sender, EventArgs e)
    {
        ToggleAllMatchYearCheckboxes(false);
    }

    /// <summary>
    /// Set all of the checkboxes to have either a checked or unchecked state depending
    /// on whether true or false is passed in the `isChecked` value.
    /// </summary>
    /// <param name="isChecked"></param>
    private void ToggleAllMatchYearCheckboxes(bool isChecked)
    {
        foreach (Control ctl in this.flpMatchYears.Controls)
        {
            if (ctl is CheckBox)
            {
                CheckBox chk = (CheckBox)ctl;
                chk.Checked = isChecked;
            }
        }
    }

    /// <summary>
    /// A centralized method to update the status label text
    /// </summary>
    /// <param name="statusText"></param>
    private void UpdateStatusLabel(string statusText)
    {
        lblStatus.Text = statusText;
        lblStatus.Update();
        this.Refresh();
        this.Update();
    }

    /// <summary>
    /// Updates the progress bar with a certain value and refreshes the UI
    /// </summary>
    /// <param name="percentComplete"></param>
    private void UpdateProgress(double percentComplete)
    {
        pbarProgress.Value = Convert.ToInt32(percentComplete);
        pbarProgress.Update();
        this.Refresh();
        this.Update();
    }

    private void ToggleButtonsEnabled(bool enabledState)
    {
        btnLoadMatches.Enabled = enabledState;
        btnLoadPlayers.Enabled = enabledState;
    }

    /// <summary>
    /// This click handler kicks off the process of downloading the csv data file
    /// and then loading that player data into the database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnLoadPlayers_Click(object sender, EventArgs e)
    {
        ToggleButtonsEnabled(false);
        UpdateStatusLabel("Downloading Player Data...");
        UpdateProgress(0); // basically reset progress to zero before this runs

        string playersCsvDataFileUrl = @"https://raw.githubusercontent.com/JeffSackmann/tennis_atp/master/atp_players.csv";
        string localPlayersDataFilePath = Path.Combine(ProjectSourcePath.Value + @"DataFiles\PlayersData\atp_players.csv");

        using (DataFileDownloader dataFileDownloader = new DataFileDownloader())
        {
            dataFileDownloader.ProgressChanged += DataFileDownloader_ProgressChanged;
            dataFileDownloader.DownloadCompleted += DataFileDownloader_DownloadCompleted;
            await dataFileDownloader.DownloadFile(playersCsvDataFileUrl, localPlayersDataFilePath);
        }

        PlayersFileProcessor playerFileProcessor = new PlayersFileProcessor();
        playerFileProcessor.ProcessFile(localPlayersDataFilePath);
        

        ToggleButtonsEnabled(true);
    }

    /// <summary>
    /// This is the event handler that receives the notification that a file download progress has changed
    /// </summary>
    /// <param name="sender">The sending class/assembly (in this case, the DataFileDownloader class)</param>
    /// <param name="e">The arguments that accompany the event (see the properties of <seealso cref="DataFileDownloader"/>)</param>
    private void DataFileDownloader_ProgressChanged(object? sender, DataFileDownloadProgressEventArgs e)
    {
        UpdateStatusLabel((int)e.ProgressPercentage + "% Completed.");
        UpdateProgress(e.ProgressPercentage);
    }

    /// <summary>
    /// This is the event handler the receives the notification that a file download attempt has completed
    /// </summary>
    /// <param name="sender">The sending class/assembly (in this case, the DataFileDownloader class)</param>
    /// <param name="e">The arguments that accompany the event (see the properties of <seealso cref="DataFileDownloader"/>)</param>
    private void DataFileDownloader_DownloadCompleted(object? sender, DataFileDownloadEventArgs e)
    {
        if (e.FileDownloadedSuccessfully)
        {
            UpdateStatusLabel($"Download of {e.FileNameDownloaded} is Complete. Total size: {e.TotalBytesDownloaded.BytesAsHumanReadableString()}");
        }
        else
        {
            UpdateStatusLabel("Download Failed." + e.Exception?.Message);
        }

    }

    /// <summary>
    /// This click handler kicks off the process of loading the
    /// match data into the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnLoadMatches_Click(object sender, EventArgs e)
    {
        ToggleButtonsEnabled(false);

        List<int> years = new List<int>();
        UpdateProgress(0); // basically reset progress to zero before this runs

        UpdateStatusLabel("Gathering Match Years...");

        foreach (Control ctl in this.flpMatchYears.Controls)
        {
            if (ctl is CheckBox)
            {
                CheckBox chk = (CheckBox)ctl;
                if (chk.Checked)
                {
                    years.Add(int.Parse(chk.Text));
                }
            }
        }

        // Go through each year that was gathered from the checkboxes
        // and download the data file for each year
        using (DataFileDownloader dataFileDownloader = new DataFileDownloader())
        {
            dataFileDownloader.ProgressChanged += DataFileDownloader_ProgressChanged;
            dataFileDownloader.DownloadCompleted += DataFileDownloader_DownloadCompleted;

            foreach (int year in years) {
                UpdateProgress(0D);
                UpdateStatusLabel($"Downloading matches data for {year}");
                string matchesCsvDataFileUrl = $"https://raw.githubusercontent.com/JeffSackmann/tennis_atp/master/atp_matches_{year}.csv";
                string localMatchesDataFilePath = Path.Combine(ProjectSourcePath.Value + $"DataFiles\\MatchesData\\atp_matches_{year}.csv");
                await dataFileDownloader.DownloadFile(matchesCsvDataFileUrl, localMatchesDataFilePath);
            }

        }

        foreach(int year in years)
        {
            UpdateStatusLabel($"Inserting matches data for {year}");
            string localMatchesDataFilePath = Path.Combine(ProjectSourcePath.Value + $"DataFiles\\MatchesData\\atp_matches_{year}.csv");
            MatchesFileProcessor matchesFileProcessor = new MatchesFileProcessor();
            matchesFileProcessor.ProcessFile(localMatchesDataFilePath);
        }
        

        ToggleButtonsEnabled(true);
    }

    /// <summary>
    /// Runs as the form is loading before it gets displayed/drawn for the first time.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MainForm_Load(object sender, EventArgs e)
    {
        // Setup certain control properties to some initial values.
        lblStatus.Text = "Ready";
        pbarProgress.Value = 0;
    }
}