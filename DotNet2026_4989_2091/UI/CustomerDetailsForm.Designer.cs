namespace UI
{
    partial class CustomerDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox InputId;
        private System.Windows.Forms.TextBox textBox1; // זה השם שמופיע בקוד שלך כשם הלקוח
        private System.Windows.Forms.TextBox InputPhone;
        private System.Windows.Forms.TextBox InputAddress;
        private System.Windows.Forms.CheckBox IsClubCheckBox;
        private System.Windows.Forms.Button StartOrderBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.InputId = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.InputPhone = new System.Windows.Forms.TextBox();
            this.InputAddress = new System.Windows.Forms.TextBox();
            this.IsClubCheckBox = new System.Windows.Forms.CheckBox();
            this.StartOrderBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Label ID
            this.label1.Text = "תעודת זהות:";
            this.label1.Location = new System.Drawing.Point(50, 50);

            // InputId
            this.InputId.Location = new System.Drawing.Point(150, 50);
            this.InputId.Name = "InputId";

            // Label Name
            this.label2.Text = "שם מלא:";
            this.label2.Location = new System.Drawing.Point(50, 90);

            // textBox1 (Name)
            this.textBox1.Location = new System.Drawing.Point(150, 90);
            this.textBox1.Name = "textBox1";

            // IsClubCheckBox
            this.IsClubCheckBox.Text = "חבר מועדון?";
            this.IsClubCheckBox.Location = new System.Drawing.Point(150, 220);

            // StartOrderBTN
            this.StartOrderBTN.Text = "המשך לבחירת מוצרים";
            this.StartOrderBTN.Location = new System.Drawing.Point(150, 270);
            this.StartOrderBTN.Size = new System.Drawing.Size(150, 40);
            this.StartOrderBTN.Click += new System.EventHandler(this.StartOrderBTN_Click);

            // Form Layout
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.InputId);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.IsClubCheckBox);
            this.Controls.Add(this.StartOrderBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "CustomerDetailsForm";
            this.Text = "פרטי לקוח";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}