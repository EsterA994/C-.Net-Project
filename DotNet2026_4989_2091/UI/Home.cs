using System;
using System.Windows.Forms;

namespace UI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ManagerButton_Click(object sender, EventArgs e)
        {
            var mgr = new ManagerForm();
            mgr.ShowDialog();
        }

        private void SellerButton_Click(object sender, EventArgs e)
        {
            SellerForm sellerForm = new SellerForm();
            sellerForm.ShowDialog();
        }
    }
}
