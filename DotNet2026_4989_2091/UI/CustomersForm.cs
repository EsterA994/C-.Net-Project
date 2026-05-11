using System;
using System.Windows.Forms;

namespace UI;

public partial class CustomersForm : Form
{
    public CustomersForm()
    {
        InitializeComponent();
    }

    private void CustomersForm_Load(object sender, EventArgs e)
    {
        // TODO: load customers into CustomersGrid when BL is connected
    }

    private void SearchCustomersBTN_Click(object sender, EventArgs e)
    {
        // TODO: perform search/filter based on SearchByComboBox and SearchTextBox
    }

    private void AddCustomerBTN_Click(object sender, EventArgs e)
    {
        // TODO: read fields from the input controls and call BL to add customer
    }

    private void UpdateCustomerBTN_Click(object sender, EventArgs e)
    {
        // TODO: read selected customer or fields and call BL to update
    }

    private void DeleteCustomerBTN_Click(object sender, EventArgs e)
    {
        // TODO: delete selected customer after confirmation
    }

    private void CustomersGrid_SelectionChanged(object sender, EventArgs e)
    {
        // TODO: when selection changes populate the single-item fields for viewing/editing
    }

    private void SearchTextBox_TextChanged(object sender, EventArgs e)
    {

    }
}
