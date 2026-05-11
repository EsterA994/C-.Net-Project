namespace UI
{
    partial class loginCustForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginTitle = new Label();
            inputName = new TextBox();
            inputId = new TextBox();
            inputAddress = new TextBox();
            inputPhone = new TextBox();
            clubCheckBox = new CheckBox();
            startOrderBTN = new Button();
            SuspendLayout();
            // 
            // loginTitle
            // 
            loginTitle.AutoSize = true;
            loginTitle.Location = new Point(355, 93);
            loginTitle.Name = "loginTitle";
            loginTitle.Size = new Size(114, 20);
            loginTitle.TabIndex = 0;
            loginTitle.Text = "הכנס פרטי לקוח";
            // 
            // inputName
            // 
            inputName.Location = new Point(311, 145);
            inputName.Name = "inputName";
            inputName.Size = new Size(206, 27);
            inputName.TabIndex = 1;
            inputName.Text = "שם לקוח";
            // 
            // inputId
            // 
            inputId.Location = new Point(311, 211);
            inputId.Name = "inputId";
            inputId.Size = new Size(206, 27);
            inputId.TabIndex = 1;
            inputId.Text = "מספר זהות";
            // 
            // inputAddress
            // 
            inputAddress.Location = new Point(311, 178);
            inputAddress.Name = "inputAddress";
            inputAddress.Size = new Size(206, 27);
            inputAddress.TabIndex = 1;
            inputAddress.Text = "כתובת";
            // 
            // inputPhone
            // 
            inputPhone.Location = new Point(311, 244);
            inputPhone.Name = "inputPhone";
            inputPhone.Size = new Size(206, 27);
            inputPhone.TabIndex = 1;
            inputPhone.Text = "מספר טלפון";
            // 
            // clubCheckBox
            // 
            clubCheckBox.AutoSize = true;
            clubCheckBox.Location = new Point(355, 286);
            clubCheckBox.Name = "clubCheckBox";
            clubCheckBox.Size = new Size(100, 24);
            clubCheckBox.TabIndex = 2;
            clubCheckBox.Text = "חבר מועדון";
            clubCheckBox.UseVisualStyleBackColor = true;
            // 
            // startOrderBTN
            // 
            startOrderBTN.Location = new Point(297, 328);
            startOrderBTN.Name = "startOrderBTN";
            startOrderBTN.Size = new Size(230, 43);
            startOrderBTN.TabIndex = 3;
            startOrderBTN.Text = "התחל הזמנה";
            startOrderBTN.UseVisualStyleBackColor = true;
            startOrderBTN.Click += startOrderBTN_Click;
            // 
            // loginCustForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startOrderBTN);
            Controls.Add(clubCheckBox);
            Controls.Add(inputPhone);
            Controls.Add(inputAddress);
            Controls.Add(inputId);
            Controls.Add(inputName);
            Controls.Add(loginTitle);
            Name = "loginCustForm";
            Text = "loginCustForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label loginTitle;
        private TextBox inputName;
        private TextBox inputId;
        private TextBox inputAddress;
        private TextBox inputPhone;
        private CheckBox clubCheckBox;
        private Button startOrderBTN;
    }
}