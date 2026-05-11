using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI
{
    public partial class loginCustForm : Form
    {
        public loginCustForm()
        {
            InitializeComponent();
        }

        private void startOrderBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputName.Text) || string.IsNullOrWhiteSpace(inputId.Text)
                || string.IsNullOrWhiteSpace(inputAddress.Text)|| string.IsNullOrWhiteSpace(inputPhone.Text))
            {
                MessageBox.Show("יש למלא את כל השדות");
                return;
            }
            maneger.CheckUser(userName.Text, password.Text);
            userName.Text = "";
            password.Text = "";
        }
    }
}
