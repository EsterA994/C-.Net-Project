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
            comboProducts = new ComboBox();
            numAmount = new NumericUpDown();
            AddProductBtn = new Button();
            dgvItems = new DataGridView();
            lblTotal = new Label();
            FinishBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // comboProducts
            // 
            comboProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            comboProducts.Location = new Point(30, 30);
            comboProducts.Name = "comboProducts";
            comboProducts.Size = new Size(200, 23);
            comboProducts.TabIndex = 0;
            // 
            // numAmount
            // 
            numAmount.Location = new Point(250, 30);
            numAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAmount.Name = "numAmount";
            numAmount.Size = new Size(120, 23);
            numAmount.TabIndex = 1;
            numAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // AddProductBtn
            // 
            AddProductBtn.Location = new Point(400, 30);
            AddProductBtn.Name = "AddProductBtn";
            AddProductBtn.Size = new Size(75, 23);
            AddProductBtn.TabIndex = 2;
            AddProductBtn.Text = "הוסף לסל";
            AddProductBtn.Click += AddProductBtn_Click;
            // 
            // dgvItems
            // 
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(30, 80);
            dgvItems.Name = "dgvItems";
            dgvItems.Size = new Size(700, 250);
            dgvItems.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.Location = new Point(30, 350);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(149, 25);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "סה\"כ: 0.00 ש\"ח";
            // 
            // FinishBtn
            // 
            FinishBtn.BackColor = Color.LightGreen;
            FinishBtn.Location = new Point(600, 350);
            FinishBtn.Name = "FinishBtn";
            FinishBtn.Size = new Size(130, 45);
            FinishBtn.TabIndex = 5;
            FinishBtn.Text = "סיום והדפסה";
            FinishBtn.UseVisualStyleBackColor = false;
            FinishBtn.Click += FinishBtn_Click;
            // 
            // OrderForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(comboProducts);
            Controls.Add(numAmount);
            Controls.Add(AddProductBtn);
            Controls.Add(dgvItems);
            Controls.Add(lblTotal);
            Controls.Add(FinishBtn);
            Name = "OrderForm";
            Text = "ניהול סל קניות";
            Load += OrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}