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

    }

    private void UpdateProgress(int percentComplete)
    {
        pbarProgress.Value = percentComplete;
        pbarProgress.Update();
    }

    /// <summary>
    /// This click handler kicks off the process of loading
    /// player data into the database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnLoadPlayers_Click(object sender, EventArgs e)
    {
        UpdateStatusLabel("Loading Player Data...");
        UpdateProgress(0); // basically reset progress to zero before this runs

    }

    /// <summary>
    /// This click handler kicks off the process of loading the
    /// match data into the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnLoadMatches_Click(object sender, EventArgs e)
    {
        List<int> years = new List<int>();
        UpdateProgress(0); // basically reset progress to zero before this runs

        UpdateStatusLabel("Gathering Years...");

        foreach (Control ctl in this.flpMatchYears.Controls)
        {
            if (ctl is CheckBox)
            {
                CheckBox chk = (CheckBox)ctl;
                years.Add(int.Parse(chk.Text));
            }
        }


    }
}