using BlApi;
using BO;

namespace UI
{
    public partial class CustomerDetailsForm : Form
    {
        // קבלת ה-Interface של ה-BL דרך ה-Factory
        private static IBl _bl = BlApi.Factory.Get;

        public CustomerDetailsForm()
        {
            InitializeComponent();
        }

        private void StartOrderBTN_Click(object sender, EventArgs e)
        {
            // ולידציה 1: בדיקה שה-ID הוא מספר תקין (מונע קריסה)
            if (!int.TryParse(InputId.Text, out int id))
            {
                MessageBox.Show("תעודת זהות חייבת להכיל ספרות בלבד.", "שגיאת קלט");
                return;
            }

            // ולידציה 2: בדיקה שהשם לא ריק (textBox1 לפי ה-Designer שלך)
            string name = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("נא להזין שם לקוח.", "שגיאה");
                return;
            }

            try
            {
                // קריאה לפונקציית העזר שבודקת קיום לקוח
                BO.Customer customer = GetOrCreateCustomer(id, name);

                // אם חזר null (בגלל אי התאמת שם), עוצרים
                if (customer == null) return;

                // יצירת אובייקט הזמנה חדש להעברה למסך הבא
                BO.Order newOrder = new BO.Order
                {
                    IsPreferredCust = IsClubCheckBox.Checked,
                    ProductsList = new List<BO.ProductInOrder>(),
                    FinalPrice = 0
                };

                // פתיחת מסך ההזמנה והעברת אובייקט ההזמנה
                OrderForm orderForm = new OrderForm(newOrder);
                this.Hide();
                orderForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה במערכת: " + ex.Message);
            }
        }

        private BO.Customer GetOrCreateCustomer(int id, string name)
        {
            try
            {
                // ניסיון לקרוא לקוח קיים
                var existing = _bl.Customer.Read(id);

                // בדיקת אבטחה: אם קיים, האם זה אותו אדם?
                if (existing.CustName != name)
                {
                    MessageBox.Show("הלקוח קיים במערכת עם שם אחר. לא ניתן לשנות פרטים.", "שגיאת אימות");
                    return null;
                }
                return existing;
            }
            catch (BO.BlDoesNotExistException)
            {
                // אם לא נמצא - יוצרים לקוח חדש ב-Data Base
                BO.Customer newCust = new BO.Customer
                {
                    CustId = id,
                    CustName = name,
                    CustPhone = InputPhone.Text,
                    CustAddress = InputAddress.Text
                };
                _bl.Customer.Create(newCust);
                return newCust;
            }
        }

        private void CustomerDetailsForm_Load(object sender, EventArgs e) { }
    }
}