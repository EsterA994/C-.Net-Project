using System;
using System.Windows.Forms;

namespace UI;

public partial class ManagerForm : Form
{
    public ManagerForm()
    {
        InitializeComponent();
        // subscribe to button events
        this.SalesBTN.Click += SalesBTN_Click;
        this.ProductsBTN.Click += ProductsBTN_Click;
        this.CustomersBTN.Click += CustomersBTN_Click;
    }

    private void ManagerForm_Load(object sender, EventArgs e)
    {

    }

    private void SalesBTN_Click(object sender, EventArgs e)
    {
        var salesForm = new SalesForm();
        salesForm.ShowDialog();
    }

    private void ProductsBTN_Click(object sender, EventArgs e)
    {
        var productsForm = new ProductsForm();
        productsForm.ShowDialog();
    }

    private void CustomersBTN_Click(object sender, EventArgs e)
    {
    }

    private void CustomersBTN_Click_1(object sender, EventArgs e)
    {
        var CustomersForm = new CustomersForm();
        CustomersForm.ShowDialog();
    }
}
