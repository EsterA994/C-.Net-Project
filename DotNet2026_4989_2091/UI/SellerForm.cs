using System;
using System.Windows.Forms;

namespace UI
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent(); // פונקציה מה-Designer שבונה את המסך
        }

        private void NewOrderBTN_Click(object sender, EventArgs e)
        {
            // פתיחת המסך הבא שבו מזינים פרטי לקוח
            new CustomerDetailsForm().ShowDialog();
        }
    }
}