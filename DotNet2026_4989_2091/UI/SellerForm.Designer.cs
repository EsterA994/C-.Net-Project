namespace UI
{
    partial class SellerForm
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
            helloSellerLbl = new Label();
            newOrderBTN = new Button();
            SuspendLayout();
            // 
            // helloSellerLbl
            // 
            helloSellerLbl.AutoSize = true;
            helloSellerLbl.Location = new Point(357, 132);
            helloSellerLbl.Name = "helloSellerLbl";
            helloSellerLbl.Size = new Size(84, 20);
            helloSellerLbl.TabIndex = 0;
            helloSellerLbl.Text = "שלום קופאי";
            // 
            // newOrderBTN
            // 
            newOrderBTN.Location = new Point(326, 193);
            newOrderBTN.Name = "newOrderBTN";
            newOrderBTN.Size = new Size(143, 79);
            newOrderBTN.TabIndex = 1;
            newOrderBTN.Text = "הזמנה חדשה";
            newOrderBTN.UseVisualStyleBackColor = true;
            newOrderBTN.Click += newOrderBTN_Click;
            // 
            // SellerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(newOrderBTN);
            Controls.Add(helloSellerLbl);
            Name = "SellerForm";
            Text = "SellerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label helloSellerLbl;
        private Button newOrderBTN;
    }
}