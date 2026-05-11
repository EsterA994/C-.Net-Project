using System;
using System.Windows.Forms;

namespace UI;

public partial class ProductsForm : Form
{
    public ProductsForm()
    {
        InitializeComponent();
    }

    private void ProductsForm_Load(object sender, EventArgs e)
    {
        // TODO: load products into ProductsGrid when BL is connected
        // e.g. bind columns: ProdId, ProdName, ProdCategory, Price, QuantityInStock
    }

    private void SearchProductsBTN_Click(object sender, EventArgs e)
    {
        // TODO: perform search/filter based on SearchByComboBox and SearchTextBox
    }

    private void AddProductBTN_Click(object sender, EventArgs e)
    {
        // TODO: read fields from the input controls and call BL to add product
    }

    private void UpdateProductBTN_Click(object sender, EventArgs e)
    {
        // TODO: read selected product or fields and call BL to update
    }

    private void DeleteProductBTN_Click(object sender, EventArgs e)
    {
        // TODO: delete selected product after confirmation
    }

    private void ProductsGrid_SelectionChanged(object sender, EventArgs e)
    {
        // TODO: when selection changes populate the single-item fields for viewing/editing
    }

    private void SearchTextBox_TextChanged(object sender, EventArgs e)
    {

    }
}
