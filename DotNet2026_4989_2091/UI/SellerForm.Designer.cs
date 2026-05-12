namespace UI
{
    partial class SellerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button NewOrderBTN;
        private System.Windows.Forms.Label SellerTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.NewOrderBTN = new System.Windows.Forms.Button();
            this.SellerTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // SellerTitle
            this.SellerTitle.AutoSize = true;
            this.SellerTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.SellerTitle.Location = new System.Drawing.Point(300, 50);
            this.SellerTitle.Text = "מערכת מכירה - קופאי";

            // NewOrderBTN
            this.NewOrderBTN.Location = new System.Drawing.Point(250, 150);
            this.NewOrderBTN.Name = "NewOrderBTN";
            this.NewOrderBTN.Size = new System.Drawing.Size(300, 100);
            this.NewOrderBTN.Text = "הזמנה חדשה";
            this.NewOrderBTN.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.NewOrderBTN.Click += new System.EventHandler(this.NewOrderBTN_Click);

            // SellerForm

            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SellerTitle);
            this.Controls.Add(this.NewOrderBTN);
            this.Name = "SellerForm";
            this.Text = "Seller Terminal";
            this.ResumeLayout(false);
            this.PerformLayout();
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            /*Controls.Add(newOrderBTN);
            Controls.Add(helloSellerLbl);*/
            Name = "SellerForm";
            Text = "SellerForm";
            Load += SellerForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }
    }
}