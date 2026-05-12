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
using BlApi;
using BO;

namespace UI;

public partial class SalesForm : Form
{
    static readonly IBl s_bl = Factory.Get;
    readonly List<Sale> sales;

    public SalesForm()
    {
        InitializeComponent();
    }

    private void SalesForm_Load(object sender, EventArgs e)
    {
        try
        {
            var data = s_bl.Sale.ReadAll()?.ToList();

            if (data != null)
            {
                SalesGrid.DataSource = data;

                // בדיקה שהעמודות קיימות לפני שמשנים להן כותרת
                if (SalesGrid.Columns.Count > 0)
                {
                    // השתמשי בשמות המדויקים מה-BO (כמו שכתבת ב-Add)
                    if (SalesGrid.Columns.Contains("SaleId"))
                        SalesGrid.Columns["SaleId"].HeaderText = "מזהה מבצע";

                    if (SalesGrid.Columns.Contains("ProdId"))
                        SalesGrid.Columns["ProdId"].HeaderText = "מזהה מבצע";

                    if (SalesGrid.Columns.Contains("MinRequireQuantity"))
                        SalesGrid.Columns["MinRequireQuantity"].HeaderText = "כמות במבצע";

                    if (SalesGrid.Columns.Contains("PriceInSale"))
                        SalesGrid.Columns["PriceInSale"].HeaderText = "מחיר במבצע";

                    if (SalesGrid.Columns.Contains("JustForClub"))
                        SalesGrid.Columns["JustForClub"].HeaderText = "לחברי מועדון בלבד?";

                    if (SalesGrid.Columns.Contains("StartDateSale"))
                        SalesGrid.Columns["StartDateSale"].HeaderText = "תאריך התחלה";

                    if (SalesGrid.Columns.Contains("StopDateSale"))
                        SalesGrid.Columns["StopDateSale"].HeaderText = "תאריך סיום";

                    // עיצוב
                    SalesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    SalesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("שגיאה בטעינה: " + ex.Message);
        }
    }

    private void RefreshGrid()
    {
        try
        {
            SalesGrid.DataSource = s_bl.Sale.ReadAll().ToList();
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
        var allSales = s_bl.Sale.ReadAll();

        if (string.IsNullOrEmpty(text))
        {
            SalesGrid.DataSource = allSales.ToList();
            return;
        }

        if (SearchByComboBox.Text == "מזהה")
            SalesGrid.DataSource = allSales.Where(s => s.SaleId.ToString().Contains(text)).ToList();
        else if (SearchByComboBox.Text == "שם מוצר")
            SalesGrid.DataSource = allSales.Where(s => s_bl.Product.Read(s.ProdId)?.ProdName.Contains(text) ?? false).ToList();
        else if (SearchByComboBox.Text == "מחיר")
            SalesGrid.DataSource = allSales.Where(s => s.PriceInSale.ToString().Contains(text)).ToList();
    }

    private void AddSaleBTN_Click(object sender, EventArgs e)
    {
        try
        {
            // יצירת מבצע חדש from TextBox values
            Sale newSale = new Sale
            {
                SaleId = int.Parse(txtSaleId.Text),
                ProdId = int.Parse(txtSaleName.Text), //assuming txtSaleName is actually for ProdId
                MinRequireQuantity = int.Parse(txtQuantity.Text),
                PriceInSale = double.Parse(txtPrice.Text),
                JustForClub = true, // אם יש לך CheckBox בל אני מניח שזה הגדלה
                StartDateSale = DateTime.Now, // תאריך התחלה משתנה לפי הצורך
                StopDateSale = DateTime.Now.AddDays(30) // תאריך סיום משתנה לפי הצורך
            };

            s_bl.Sale.Create(newSale);
            RefreshGrid();
            MessageBox.Show("המבצע נוסף בהצלחה");
        }
        catch (Exception ex)
        {
            MessageBox.Show("שגיאה בהוספת המבצע: " + ex.Message);
        }
    }

    private void UpdateSaleBTN_Click(object sender, EventArgs e)
    {
        if (SalesGrid.SelectedRows.Count == 0)
        {
            MessageBox.Show("אנא בחר מבצע לעדכון");
            return;
        }

        try
        {
            // עדכון מבצע נבחר from TextBox values
            var selectedSale = (Sale)SalesGrid.SelectedRows[0].DataBoundItem;

            selectedSale.ProdId = int.Parse(txtSaleName.Text);
            selectedSale.MinRequireQuantity = int.Parse(txtQuantity.Text);
            selectedSale.PriceInSale = (double)decimal.Parse(txtPrice.Text);
            selectedSale.JustForClub = false;

            s_bl.Sale.Update(selectedSale);
            RefreshGrid();
            MessageBox.Show("המבצע עודכן בהצלחה");
        }
        catch (Exception ex)
        {
            MessageBox.Show("שגיאה בעדכון המבצע: " + ex.Message);
        }
    }

    private void DeleteSaleBTN_Click(object sender, EventArgs e)
    {
        if (SalesGrid.SelectedRows.Count == 0)
        {
            MessageBox.Show("אנא בחר מבצע למחיקה");
            return;
        }

        try
        {
            var selectedSale = (Sale)SalesGrid.SelectedRows[0].DataBoundItem;
            s_bl.Sale.Delete(selectedSale.SaleId);
            RefreshGrid();
            MessageBox.Show("המבצע נמחק בהצלחה");
        }
        catch (Exception ex)
        {
            MessageBox.Show("שגיאה במחיקת המבצע: " + ex.Message);
        }
    }

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