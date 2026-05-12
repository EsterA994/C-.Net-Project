namespace UI
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboProducts;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Button AddProductBtn;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button FinishBtn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboProducts = new System.Windows.Forms.ComboBox();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.AddProductBtn = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.FinishBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();

            // comboProducts
            this.comboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProducts.Location = new System.Drawing.Point(30, 30);
            this.comboProducts.Size = new System.Drawing.Size(200, 28);

            // numAmount (בחירת כמות)
            this.numAmount.Location = new System.Drawing.Point(250, 30);
            this.numAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // AddProductBtn
            this.AddProductBtn.Location = new System.Drawing.Point(400, 30);
            this.AddProductBtn.Text = "הוסף לסל";
            this.AddProductBtn.Click += new System.EventHandler(this.AddProductBtn_Click);

            // dgvItems (ה-Grid שמציג את ההזמנה)
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(30, 80);
            this.dgvItems.Size = new System.Drawing.Size(700, 250);
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // lblTotal (מחיר סופי)
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(30, 350);
            this.lblTotal.Text = "סה\"כ: 0.00 ש\"ח";

            // FinishBtn
            this.FinishBtn.Location = new System.Drawing.Point(600, 350);
            this.FinishBtn.Size = new System.Drawing.Size(130, 45);
            this.FinishBtn.Text = "סיום והדפסה";
            this.FinishBtn.BackColor = System.Drawing.Color.LightGreen;
            // הערה: יש להוסיף את האירוע FinishBtn_Click ב-OrderForm.cs

            // OrderForm Setup
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboProducts);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.AddProductBtn);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.FinishBtn);
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.Name = "OrderForm";
            this.Text = "ניהול סל קניות";
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}