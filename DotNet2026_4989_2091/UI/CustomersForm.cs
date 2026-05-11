using BL;
using System;
using System.Windows.Forms;

namespace UI;

public partial class CustomersForm : Form
{
    private readonly IBl _bl = BL.Factory.Get();
    public CustomersForm()
    {
        InitializeComponent();
    }

    private void CustomersForm_Load(object sender, EventArgs e)
    {
        try
        {
            var data = _bl.Customer.ReadAll()?.ToList();

            if (data != null)
            {
                CustomersGrid.DataSource = data;

                // בדיקה שהעמודות קיימות לפני שמשנים להן כותרת
                if (CustomersGrid.Columns.Count > 0)
                {
                    // השתמשי בשמות המדויקים מה-BO (כמו שכתבת ב-Add)
                    if (CustomersGrid.Columns.Contains("CustId"))
                        CustomersGrid.Columns["CustId"].HeaderText = "מזהה";

                    if (CustomersGrid.Columns.Contains("CustName"))
                        CustomersGrid.Columns["CustName"].HeaderText = "שם הלקוח";

                    if (CustomersGrid.Columns.Contains("CustAddress"))
                        CustomersGrid.Columns["CustAddress"].HeaderText = "כתובת";

                    if (CustomersGrid.Columns.Contains("CustPhone"))
                        CustomersGrid.Columns["CustPhone"].HeaderText = "טלפון";

                    // עיצוב
                    CustomersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    CustomersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("שגיאה בטעינה: " + ex.Message);
        }
    }
    private void FormatCustomersGrid()
    {
        if (CustomersGrid.Columns.Count > 0)
        {
            // שינוי שמות הכותרות לעברית (ודאי שהשמות בתוך המירכאות תואמים למאפיינים ב-BO.Customer)
            CustomersGrid.Columns["Id"].HeaderText = "מזהה לקוח";
            CustomersGrid.Columns["Name"].HeaderText = "שם מלא";
            CustomersGrid.Columns["Phone"].HeaderText = "טלפון";
            CustomersGrid.Columns["Address"].HeaderText = "כתובת";

            // עיצוב כללי שייראה יפה
            CustomersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // פריסה על כל הרוחב
            CustomersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // בחירת שורה מלאה
            CustomersGrid.RowHeadersVisible = false; // העלמת העמודה הריקה בצד שמאל
            CustomersGrid.ReadOnly = true; // מניעת עריכה ישירות בטבלה

            // צבע שורות מתחלף (אופציונלי - עוזר לקריאות)
            CustomersGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
        }
    }

    private void SearchCustomersBTN_Click(object sender, EventArgs e)
    {
        try
        {
            // 1. קבלת הטקסט לחיפוש (ניקוי רווחים והפיכה לאותיות קטנות לחיפוש לא רגיש לרישיות)
            string searchText = SearchTextBox.Text.Trim().ToLower();

            // 2. פנייה ל-BL לקבלת הרשימה העדכנית ביותר
            var allCustomers = _bl.Customer.ReadAll();

            if (allCustomers == null)
            {
                CustomersGrid.DataSource = null;
                return;
            }

            // 3. אם תיבת החיפוש ריקה - נציג פשוט את כל הרשימה ונצא
            if (string.IsNullOrEmpty(searchText))
            {
                CustomersGrid.DataSource = allCustomers.ToList();
                return;
            }

            // 4. קבלת הקריטריון לחיפוש מה-ComboBox
            // (הנחה: ב-ComboBox יש ערכים כמו "שם", "מזהה", "טלפון")
            string searchBy = SearchByComboBox.SelectedItem?.ToString() ?? "שם";

            // 5. סינון יעיל בעזרת LINQ
            var filteredResults = allCustomers.Where(c =>
            {
                return searchBy switch
                {
                    "מזהה" => c.CustId.ToString().Contains(searchText),
                    "טלפון" => c.CustPhone != null && c.CustPhone.Contains(searchText),
                    "כתובת" => c.CustAddress != null && c.CustAddress.ToLower().Contains(searchText),
                    _ => c.CustName != null && c.CustName.ToLower().Contains(searchText) // ברירת מחדל: חיפוש לפי שם
                };
            }).ToList();

            // 6. עדכון הגריד
            CustomersGrid.DataSource = filteredResults;

            // 7. משוב למשתמש אם לא נמצאו תוצאות
            if (filteredResults.Count == 0)
            {
                MessageBox.Show("לא נמצאו לקוחות התואמים לחיפוש שלך.", "חיפוש", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"שגיאה במהלך החיפוש: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void AddCustomerBTN_Click(object sender, EventArgs e)
    {
        try
        {
            // 1. יצירת אובייקט לקוח חדש ומילוי הנתונים מהתיבות בטופס
            BO.Customer newCustomer = new BO.Customer
            {
                CustId = int.Parse(txtCustId.Text), // המרה של הטקסט למספר (ת.ז)
                CustName = txtCustName.Text,
                CustAddress = txtCustAddress.Text,
                CustPhone = txtCustPhone.Text
            };

            // 2. קריאה ל-BL כדי להוסיף את הלקוח לבסיס הנתונים
            int id = _bl.Customer.Create(newCustomer);
            if (id == 0)
                throw new Exception("הלקוח כבר קיים או שהנתונים לא תקינים");

            // 3. הודעת הצלחה ורענון הטבלה כדי שנראה את הלקוח החדש
            MessageBox.Show("הלקוח נוסף בהצלחה!", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // רענון הגריד (קריאה לפונקציית ה-Load או שליפה מחדש)
            CustomersGrid.DataSource = _bl.Customer.ReadAll().ToList();

            // אופציונלי: ניקוי התיבות לאחר ההוספה
            txtCustId.Clear();
            txtCustName.Clear();
            txtCustAddress.Clear();
            txtCustPhone.Clear();
        }
        catch (Exception ex)
        {
            // אם למשל המשתמש הקיש אותיות במקום מספר בתעודת הזהות, או שהלקוח כבר קיים
            MessageBox.Show("שגיאה בהוספת הלקוח: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void UpdateCustomerBTN_Click(object sender, EventArgs e)
    {
        try
        {
            // 1. יצירת אובייקט לקוח עם הנתונים המעודכנים מהתיבות בטופס
            BO.Customer customerToUpdate = new BO.Customer
            {
                CustId = int.Parse(txtCustId.Text), // המזהה של הלקוח שאותו מעדכנים
                CustName = txtCustName.Text,
                CustAddress = txtCustAddress.Text,
                CustPhone = txtCustPhone.Text
            };

            // 2. קריאה ל-BL לביצוע העדכון
            _bl.Customer.Update(customerToUpdate);

            // 3. הודעת הצלחה ורענון הטבלה כדי לראות את השינויים
            MessageBox.Show("פרטי הלקוח עודכנו בהצלחה!", "עדכון", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // רענון הגריד
            CustomersGrid.DataSource = _bl.Customer.ReadAll().ToList();
        }
        catch (Exception ex)
        {
            // טיפול בשגיאות (למשל אם הלקוח לא נמצא או שהנתונים לא תקינים)
            MessageBox.Show("שגיאה בעדכון הלקוח: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteCustomerBTN_Click(object sender, EventArgs e)
    {
        try
        {
            // 1. בדיקה אם הוזן מזהה בתיבת הטקסט (או אם נבחר לקוח)
            if (string.IsNullOrEmpty(txtCustId.Text))
            {
                MessageBox.Show("אנא בחרי לקוח מהרשימה לפני המחיקה", "לבדיקתך");
                return;
            }

            int customerId = int.Parse(txtCustId.Text);

            // 2. הצגת תיבת אישור למשתמש כדי למנוע מחיקה בטעות
            var result = MessageBox.Show($"האם את בטוחה שברצונך למחוק את לקוח מספר {customerId}?",
                                         "אישור מחיקה",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            // 3. אם המשתמש לחץ "כן" - מבצעים את המחיקה
            if (result == DialogResult.Yes)
            {
                _bl.Customer.Delete(customerId);

                MessageBox.Show("הלקוח נמחק בהצלחה", "מחיקה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. רענון הטבלה וניקוי התיבות
                CustomersGrid.DataSource = _bl.Customer.ReadAll().ToList();

                txtCustId.Clear();
                txtCustName.Clear();
                txtCustAddress.Clear();
                txtCustPhone.Clear();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("שגיאה במחיקת הלקוח: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CustomersGrid_SelectionChanged(object sender, EventArgs e)
    {
        // 1. הגנה: אם אין שורות נבחרות (למשל בזמן רענון הרשימה) - נקה את התיבות
        if (CustomersGrid.SelectedRows.Count == 0)
        {
            ClearTextFields(); // פונקציית עזר שנבנה למטה
            return;
        }

        try
        {
            // 2. שליפת הלקוח מהשורה הראשונה שנבחרה
            var selectedCustomer = CustomersGrid.SelectedRows[0].DataBoundItem as BO.Customer;

            if (selectedCustomer != null)
            {
                // 3. עדכון התיבות
                txtCustId.Text = selectedCustomer.CustId.ToString();
                txtCustName.Text = selectedCustomer.CustName;
                txtCustAddress.Text = selectedCustomer.CustAddress;
                txtCustPhone.Text = selectedCustomer.CustPhone;

                // 4. חשוב: כשעורכים לקוח קיים, אסור לשנות את ה-ID שלו
                txtCustId.ReadOnly = true;
            }
        }
        catch (Exception)
        {
            // בזמן טעינה ראשונית הגריד לפעמים "מתבלבל", אז אנחנו פשוט מתעלמים מהשגיאה הזו
        }
    }

    // פונקציית עזר שתשמש אותך גם אחרי הוספה/מחיקה
    private void ClearTextFields()
    {
        txtCustId.Clear();
        txtCustName.Clear();
        txtCustAddress.Clear();
        txtCustPhone.Clear();
        txtCustId.ReadOnly = false; // מחזירים את האפשרות לכתוב ID בשביל לקוח חדש
    }
    private void SearchTextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string searchText = SearchTextBox.Text.Trim().ToLower();
            var allCustomers = _bl.Customer.ReadAll();

            if (allCustomers == null) return;

            // אם התיבה ריקה - נציג את כולם
            if (string.IsNullOrEmpty(searchText))
            {
                CustomersGrid.DataSource = allCustomers.ToList();
                return;
            }

            string searchBy = SearchByComboBox.SelectedItem?.ToString() ?? "שם הלקוח";

            var filteredResults = allCustomers.Where(c =>
            {
                return searchBy switch
                {
                    "מזהה" => c.CustId.ToString().Contains(searchText),
                    "טלפון" => c.CustPhone != null && c.CustPhone.Contains(searchText),
                    "כתובת" => c.CustAddress != null && c.CustAddress.ToLower().Contains(searchText),
                    _ => c.CustName != null && c.CustName.ToLower().Contains(searchText)
                };
            }).ToList();

            CustomersGrid.DataSource = filteredResults;
        }
        catch (Exception ex)
        {
            // בחיפוש תוך כדי הקלדה עדיף לא להקפיץ MessageBox כל שניה, אלא להדפיס למערכת
            System.Diagnostics.Debug.WriteLine("Search error: " + ex.Message);
        }
    }

    private void SearchByComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // אם יש טקסט בתיבת החיפוש, נריץ את פונקציית החיפוש מחדש
        // כדי להתאים את הסינון לקריטריון החדש שנבחר
        if (!string.IsNullOrEmpty(SearchTextBox.Text))
        {
            SearchTextBox_TextChanged_1(sender, e);
        }
    }
    private void CustomersGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void txtCustId_TextChanged(object sender, EventArgs e)
    {
        // 1. בדיקה אם התיבה ריקה - אם כן, אין טעם להמשיך
        if (string.IsNullOrWhiteSpace(txtCustId.Text))
        {
            return;
        }

        // 2. ולידציה בסיסית: בדיקה שהוזנו רק ספרות
        if (!int.TryParse(txtCustId.Text, out int id))
        {
            // אופציונלי: אפשר לצבוע את הרקע באדום אם זה לא מספר
            txtCustId.BackColor = Color.MistyRose;
            return;
        }
        else
        {
            txtCustId.BackColor = Color.White;
        }

        // 3. בדיקת "לקוח קיים" (UX מצוין): 
        // אם המשתמש מנסה להוסיף לקוח חדש ומקיש ID שכבר קיים, 
        // כדאי להתריע לו או למלא את הפרטים אוטומטית.
        try
        {
            // אנחנו בודקים אם אנחנו במצב "הוספה" (כלומר התיבה לא לקריאה בלבד)
            if (!txtCustId.ReadOnly)
            {
                var allCustomers = _bl.Customer.ReadAll();
                bool exists = allCustomers.Any(c => c.CustId == id);

                if (exists)
                {
                    // אפשר להוסיף Tooltip או הודעה קטנה שהלקוח כבר קיים
                    System.Diagnostics.Debug.WriteLine("Warning: Customer ID already exists.");
                }
            }
        }
        catch { /* הגנה כדי שלא יקרוס תוך כדי הקלדה */ }
    }

    private void SearchTextBox_TextChanged_1(object sender, EventArgs e)
    {
        try
        {
            // 1. קבלת הטקסט מהתיבה (ניקוי רווחים והפיכה לאותיות קטנות לחיפוש גמיש)
            string searchText = SearchTextBox.Text.Trim().ToLower();

            // 2. פנייה ל-BL לקבלת כל הלקוחות
            var allCustomers = _bl.Customer.ReadAll();

            if (allCustomers == null) return;

            // 3. אם התיבה ריקה - נציג את כולם ונסיים
            if (string.IsNullOrEmpty(searchText))
            {
                CustomersGrid.DataSource = allCustomers.ToList();
                return;
            }

            // 4. זיהוי הקריטריון לחיפוש מה-ComboBox
            string searchBy = SearchByComboBox.SelectedItem?.ToString() ?? "שם הלקוח";

            // 5. סינון הרשימה בעזרת LINQ
            var filteredResults = allCustomers.Where(c =>
            {
                return searchBy switch
                {
                    "מזהה" => c.CustId.ToString().Contains(searchText),
                    "טלפון" => c.CustPhone != null && c.CustPhone.Contains(searchText),
                    "כתובת" => c.CustAddress != null && c.CustAddress.ToLower().Contains(searchText),
                    _ => c.CustName != null && c.CustName.ToLower().Contains(searchText) // ברירת מחדל: חיפוש לפי שם
                };
            }).ToList();

            // 6. עדכון הגריד בתוצאות המסוננות
            CustomersGrid.DataSource = filteredResults;
        }
        catch (Exception ex)
        {
            // בחיפוש "חי" לא נרצה להקפיץ MessageBox על כל שגיאת הקלדה, אז נדפיס ל-Output
            System.Diagnostics.Debug.WriteLine("Search error: " + ex.Message);
        }
    }
}
