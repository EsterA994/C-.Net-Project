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
            ManagerForm managerForm = new ManagerForm();
            managerForm.ShowDialog();
        }

        private void SellerButton_Click(object sender, EventArgs e)
        {
            SellerForm sellerForm = new SellerForm();
            sellerForm.ShowDialog();
        }
    }
}
