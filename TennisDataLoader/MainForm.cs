namespace TennisDataLoader;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void btnSelectAllYears_Click(object sender, EventArgs e)
    {
        ToggleAllMatchYearCheckboxes(true);
    }

    private void btnSelectNoYears_Click(object sender, EventArgs e)
    {
        ToggleAllMatchYearCheckboxes(false);
    }

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
}