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
            InputId = new TextBox();
            textBox1 = new TextBox();
            InputPhone = new TextBox();
            InputAddress = new TextBox();
            IsClubCheckBox = new CheckBox();
            StartOrderBTN = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // InputId
            // 
            InputId.Location = new Point(150, 50);
            InputId.Name = "InputId";
            InputId.Size = new Size(100, 27);
            InputId.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(150, 90);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 27);
            textBox1.TabIndex = 1;
            // 
            // InputPhone
            // 
            InputPhone.Location = new Point(0, 0);
            InputPhone.Name = "InputPhone";
            InputPhone.Size = new Size(100, 27);
            InputPhone.TabIndex = 0;
            // 
            // InputAddress
            // 
            InputAddress.Location = new Point(0, 0);
            InputAddress.Name = "InputAddress";
            InputAddress.Size = new Size(100, 27);
            InputAddress.TabIndex = 0;
            // 
            // IsClubCheckBox
            // 
            IsClubCheckBox.Location = new Point(150, 220);
            IsClubCheckBox.Name = "IsClubCheckBox";
            IsClubCheckBox.Size = new Size(104, 24);
            IsClubCheckBox.TabIndex = 2;
            IsClubCheckBox.Text = "חבר מועדון?";
            IsClubCheckBox.CheckedChanged += IsClubCheckBox_CheckedChanged;
            // 
            // StartOrderBTN
            // 
            StartOrderBTN.Location = new Point(150, 270);
            StartOrderBTN.Name = "StartOrderBTN";
            StartOrderBTN.Size = new Size(150, 40);
            StartOrderBTN.TabIndex = 3;
            StartOrderBTN.Text = "המשך לבחירת מוצרים";
            StartOrderBTN.Click += StartOrderBTN_Click;
            // 
            // label1
            // 
            label1.Location = new Point(50, 50);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 4;
            label1.Text = "תעודת זהות:";
            // 
            // label2
            // 
            label2.Location = new Point(50, 90);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 5;
            label2.Text = "שם מלא:";
            // 
            // CustomerDetailsForm
            // 
            ClientSize = new Size(450, 400);
            Controls.Add(InputId);
            Controls.Add(textBox1);
            Controls.Add(IsClubCheckBox);
            Controls.Add(StartOrderBTN);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "CustomerDetailsForm";
            Text = "פרטי לקוח";
            Load += CustomerDetailsForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}