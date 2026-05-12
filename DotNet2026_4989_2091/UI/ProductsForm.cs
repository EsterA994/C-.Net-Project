using System;
using System.Windows.Forms;
using BlApi;
using BO;
using static BO.ProdCategory;
namespace UI;

public partial class ProductsForm : Form
{
    static readonly IBl s_bl = Factory.Get;

    public ProductsForm()
    {
        InitializeComponent();
    }

    //private void ProductsForm_Load(object sender, EventArgs e)
    //{
    //    // TODO: load products into ProductsGrid when BL is connected
    //    // e.g. bind columns: ProdId, ProdName, ProdCategory, Price, QuantityInStock
    //    try
    //    {
    //        string searchText = SearchTextBox.Text.Trim().ToLower();
    //        var allProducts = s_bl.Product.ReadAll();

    //        if (allProducts == null) return;

    //        // אם התיבה ריקה - נציג את כולם
    //        if (string.IsNullOrEmpty(searchText))
    //        {
    //            ProductsGrid.DataSource = allProducts.ToList();
    //            return;
    //        }

    //        string searchBy = SearchByComboBox.SelectedItem?.ToString() ?? "שם המוצר";

    //        var filteredResults = allProducts.Where(p =>
    //        {
    //            return searchBy switch
    //            {
    //                "מזהה" => p.ProdId.ToString().Contains(searchText),
    //                "שם" => p.ProdName != null && p.ProdName.Contains(searchText),
    //                "קטגוריה" => p.ProdCategory != null && p.ProdCategory..Contains(searchText),
    //                "מחיר" => p.Price != null && p.Price.Contains(searchText)
    //            };
    //        }).ToList();

    //        CustomersGrid.DataSource = filteredResults;
    //    }
    //    catch (Exception ex)
    //    {
    //        // בחיפוש תוך כדי הקלדה עדיף לא להקפיץ MessageBox כל שניה, אלא להדפיס למערכת
    //        System.Diagnostics.Debug.WriteLine("Search error: " + ex.Message);
    //    }
    //}
    private void ProductsForm_Load(object sender, EventArgs e)
    {
        try
        {
            // טוען את כל המוצרים מה-BL
            var allProducts = s_bl.Product.ReadAll();

            if (allProducts == null || !allProducts.Any())
            {
                // אם אין מוצרים, לשקול להראות הודעה או לא לעשות כלום
                ProductsGrid.DataSource = null; // לא להציג דבר
                return;
            }

            // קובעים את מקור הנתונים של ה-DataGrid
            ProductsGrid.DataSource = allProducts.ToList();

            // בסעיף הזה אפשר להוסיף פעולות נוספות שקשורות בהצגת הנתונים, כמו קביעת עמודות וכו'.
        }
        catch (Exception ex)
        {
            // טיפול בשגיאות
            System.Diagnostics.Debug.WriteLine("Error loading products: " + ex.Message);
        }
    }
    private void SearchProductsBTN_Click(object sender, EventArgs e)
    {
        try
        {
            string searchText = SearchTextBox.Text.Trim().ToLower();
            var allProducts = s_bl.Product.ReadAll();

            if (allProducts == null) return;

            // אם התיבה ריקה - נציג את כולם
            if (string.IsNullOrEmpty(searchText))
            {
                ProductsGrid.DataSource = allProducts.ToList();
                return;
            }

            string searchBy = SearchByComboBox.SelectedItem?.ToString() ?? "שם מוצר";

            var filteredResults = allProducts.Where(p =>
            {
                return searchBy switch
                {
                    "מזהה" => p.ProdId.ToString().Contains(searchText),
                    "שם" => p.ProdName != null && p.ProdName.ToLower().Contains(searchText),
                    //"קטגוריה" => ,

                    "מחיר" => p.Price.ToString().Contains(searchText),
                    _ => false
                };
            }).ToList();

            // עדכון ה-DataGrid עם התוצאות המסוננות
            ProductsGrid.DataSource = filteredResults;
        }
        catch (Exception ex)
        {
            // טיפול בשגיאות
            System.Diagnostics.Debug.WriteLine("Search error: " + ex.Message);
        }
    }

    private void AddProductBTN_Click(object sender, EventArgs e)
    {
        try
        {
            // יצירת אובייקט חדש של מוצר
            var newProduct = new Product
            {
                ProdId = int.Parse(txtProdId.Text), // מזהה המוצר
                ProdName = txtProdName.Text.Trim(), // שם המוצר
                Price = int.Parse(txtPrice.Text), // מחיר המוצר
                QuantityInStock = int.Parse(txtQuantity.Text) // כמות המוצר
            };

            // קריאה ל-BL כדי להוסיף את המוצר החדש
            s_bl.Product.Create(newProduct);

            MessageBox.Show("המוצר נוסף בהצלחה.");

            // טען מחדש את הרשימה כדי לראות את המוצר החדש
            ProductsForm_Load(sender, e);
        }
        catch (FormatException)
        {
            MessageBox.Show("נא להזין ערכים תקינים במחיר ובכמות.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("שגיאה בהוספת המוצר: " + ex.Message);
        }
    }


    private void UpdateProductBTN_Click(object sender, EventArgs e)
    {
        // בדוק אם יש מוצר נבחר
        if (ProductsGrid.SelectedRows.Count == 0)
        {
            MessageBox.Show("נא לבחור מוצר לעדכון.");
            return;
        }

        try
        {
            // קבלת ה-ID של המוצר הנבחר
            var selectedRow = ProductsGrid.SelectedRows[0];
            int productId = Convert.ToInt32(selectedRow.Cells["ProdId"].Value);

            // קריאה ל-BL כדי לקבל את המוצר הנוכחי
            var productToUpdate = s_bl.Product.Read(productId);

            // עדכון פרטי המוצר לפי הקלט מהמשתמש
            productToUpdate.ProdId = int.Parse(txtProdId.Text); // מזהה 
            productToUpdate.ProdName = txtProdName.Text.Trim(); // שם
            productToUpdate.Price = int.Parse(txtPrice.Text); // מחיר
            productToUpdate.QuantityInStock = int.Parse(txtQuantity.Text); // כמות

            // קריאה ל-BL לעדכון המוצר
            s_bl.Product.Update(productToUpdate);

            MessageBox.Show("המוצר עודכן בהצלחה.");

            // טען מחדש את הרשימה כדי לראות את השינויים
            ProductsForm_Load(sender, e);
        }
        catch (FormatException)
        {
            MessageBox.Show("נא להזין ערכים תקינים במחיר ובכמות.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("שגיאה בעדכון המוצר: " + ex.Message);
        }
    }

    private void DeleteProductBTN_Click(object sender, EventArgs e)
    {
        // בדוק אם יש מוצר נבחר בטבלה
        if (ProductsGrid.SelectedRows.Count == 0)
        {
            MessageBox.Show("נא לבחור מוצר למחיקה.");
            return;
        }

        // קבלת המוצר שנבחר
        var selectedRow = ProductsGrid.SelectedRows[0];
        var productId = (int)selectedRow.Cells["ProdId"].Value; // נניח שהמזהה במעטפת נקרא "ProdId"

        // בקש מהמשתמש אישור למחוק את המוצר
        var confirmationResult = MessageBox.Show(
            "האם אתה בטוח שברצונך למחוק את המוצר?",
            "אישור מחיקה",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (confirmationResult == DialogResult.Yes)
        {
            try
            {
                // קריאה ל-BL כדי למחוק את המוצר
                s_bl.Product.Delete(productId); // נניח שיש מתודה Delete ב-BL

                MessageBox.Show("המוצר נמחק בהצלחה.");

                // רענן את הרשימה אחרי המחיקה
                ProductsForm_Load(sender, e); // טען שוב את הרשימה
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה במחיקת המוצר: {ex.Message}");
            }
        }
    }

    private void ProductsGrid_SelectionChanged(object sender, EventArgs e)
    {
        // TODO: when selection changes populate the single-item fields for viewing/editing
    }

    private void SearchTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void ProductsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}
