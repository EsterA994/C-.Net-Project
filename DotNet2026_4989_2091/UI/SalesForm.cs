//using BL;
//using System;
//using System.Windows.Forms;

//namespace UI;

//public partial class SalesForm : Form
//{
//    private readonly IBl _bl = BL.Factory.Get();
//    public SalesForm()
//    {
//        InitializeComponent();
//    }


//    private void FormatTableColumns()
//    {
//        if (SalesGrid.Columns.Count > 0)
//        {
//            // הגדרת שמות העמודות לפי השדות ב-BO.Sale
//            SalesGrid.Columns["SaleId"].HeaderText = "קוד מבצע";
//            SalesGrid.Columns["ProdId"].HeaderText = "קוד מוצר";
//            SalesGrid.Columns["MinRequireQuantity"].HeaderText = "כמות מינימום";
//            SalesGrid.Columns["PriceInSale"].HeaderText = "מחיר במבצע";
//            SalesGrid.Columns["JustForClub"].HeaderText = "לחברי מועדון";
//            SalesGrid.Columns["StartDateSale"].HeaderText = "תאריך התחלה";
//            SalesGrid.Columns["StopDateSale"].HeaderText = "תאריך סיום";

//            // עיצוב אסתטי - פריסת עמודות על פני כל השטח
//            SalesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

//            // עיצוב עמודת המחיר למטבע (שקלים)
//            SalesGrid.Columns["PriceInSale"].DefaultCellStyle.Format = "C2";
//        }
//    }
//    private void SearchBTN_Click(object sender, EventArgs e)
//    {
//    }

//    private void AddSaleBTN_Click(object sender, EventArgs e)
//    {
//        // TODO: open add sale dialog
//    }

//    private void UpdateSaleBTN_Click(object sender, EventArgs e)
//    {
//        // TODO: open selected sale for editing
//    }

//    private void DeleteSaleBTN_Click(object sender, EventArgs e)
//    {
//        // TODO: delete selected sale after confirmation
//    }

//    private void SearchTextBox_TextChanged(object sender, EventArgs e)
//    {

//    }

//    private void SearchByComboBox_SelectedIndexChanged(object sender, EventArgs e)
//    {

//    }

//    private void SalesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
//    {

//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BL;
using BO;

namespace UI
{
    public partial class SalesForm : Form
    {
        private readonly IBl _bl = BL.Factory.Get();

        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            if (SearchByComboBox.Items.Count > 0) SearchByComboBox.SelectedIndex = 0;
        }

        private void RefreshGrid()
        {
            try
            {
                SalesGrid.DataSource = _bl.Sale.ReadAll().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת נתונים: " + ex.Message);
            }
        }

        // הפונקציה שגורמת לזה להיראות ולעבוד כמו במוצרים - עדכון השדות בצד
        private void SalesGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (SalesGrid.SelectedRows.Count > 0 && SalesGrid.SelectedRows[0].DataBoundItem is BO.Sale selectedSale)
            {
                txtSaleId.Text = selectedSale.SaleId.ToString();
                txtQuantity.Text = selectedSale.MinRequireQuantity.ToString();
                txtPrice.Text = selectedSale.PriceInSale.ToString();
                //chkIsClub.Checked = selectedSale.JustForClub;
            }
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            string text = valueSearch.Text.Trim();
            var allSales = _bl.Sale.ReadAll();

            if (string.IsNullOrEmpty(text))
            {
                SalesGrid.DataSource = allSales.ToList();
                return;
            }

            if (SearchByComboBox.Text == "מזהה")
                SalesGrid.DataSource = allSales.Where(s => s.SaleId.ToString().Contains(text)).ToList();
            else if (SearchByComboBox.Text == "שם מוצר")
                SalesGrid.DataSource = allSales.Where(s => _bl.Product.Read(s.ProdId)?.ProdName.Contains(text) ?? false).ToList();
            else if (SearchByComboBox.Text == "מחיר")
                SalesGrid.DataSource = allSales.Where(s => s.PriceInSale.ToString().Contains(text)).ToList();
        }

        private void AddSaleBTN_Click(object sender, EventArgs e) { /* מימוש הוספה */ }
        private void UpdateSaleBTN_Click(object sender, EventArgs e) { /* מימוש עדכון */ }
        private void DeleteSaleBTN_Click(object sender, EventArgs e) { /* מימוש מחיקה */ }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeleteSaleBTN_Click_1(object sender, EventArgs e)
        {

        }

        private void SalesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void valueSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSingle_Click(object sender, EventArgs e)
        {

        }

        private void txtSaleId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSaleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}