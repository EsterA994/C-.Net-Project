using BL;
using BlApi;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class OrderForm : Form
    {
        static readonly IBl s_bl = Factory.Get;
        private BO.Order _currentOrder; // שמירת ההזמנה שקיבלנו מהמסך הקודם

        // הבנאי מעדכן את המשתנה המקומי באובייקט שהגיע מה-CustomerDetailsForm
        public OrderForm(BO.Order order)
        {
            InitializeComponent();
            _currentOrder = order;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // טעינת רשימת המוצרים ל-ComboBox כדי שהמשתמש יוכל לבחור
            comboProducts.DataSource = s_bl.Product.ReadAll().ToList();
            comboProducts.DisplayMember = "ProdName"; // מה שיוצג למשתמש
            comboProducts.ValueMember = "ProdId";     // הערך שיחזור בקוד
        }

        private void AddProductBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int pId = (int)comboProducts.SelectedValue;
                int amount = (int)numAmount.Value;

                // קריאה ל-BL: הוא יוסיף ל-List ויחשב מחיר סופי (כולל הנחת מועדון!)
                s_bl.Order.AddProductToOrder(_currentOrder, pId, amount);

                // רענון התצוגה של הטבלה
                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה");
            }
        }

        private void UpdateUI()
        {
            // הדרך היחידה ש-WinForms מרענן Grid: ניתוק וחיבור מחדש
            dgvItems.DataSource = null;
            dgvItems.DataSource = _currentOrder.ProductsList;

            // עדכון מחיר סופי על המסך
            lblTotal.Text = $"סה\"כ לתשלום: {_currentOrder.FinalPrice:C}";
        }

        private void FinishBtn_Click(object sender, EventArgs e)
        {
            DoOrderForm doOrderForm = new DoOrderForm(lblTotal.Text);
            doOrderForm.ShowDialog();
        }
        
    }
}