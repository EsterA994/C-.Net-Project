using System;
using System.Windows.Forms;

namespace UI;

public partial class SalesForm : Form
{
    public SalesForm()
    {
        InitializeComponent();
    }

    private void SalesForm_Load(object sender, EventArgs e)
    {
        // TODO: load data into SalesGrid when BL is connected
    }

    private void SearchBTN_Click(object sender, EventArgs e)
    {
        // TODO: perform search based on SearchByComboBox and SearchTextBox
    }

    private void AddSaleBTN_Click(object sender, EventArgs e)
    {
        // TODO: open add sale dialog
    }

    private void UpdateSaleBTN_Click(object sender, EventArgs e)
    {
        // TODO: open selected sale for editing
    }

    private void DeleteSaleBTN_Click(object sender, EventArgs e)
    {
        // TODO: delete selected sale after confirmation
    }

    private void SearchTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void SearchByComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
