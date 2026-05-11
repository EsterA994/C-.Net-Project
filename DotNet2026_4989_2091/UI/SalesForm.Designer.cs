namespace UI
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelQuantity = new Label();
            labelPrice = new Label();
            labelName = new Label();
            labelId = new Label();
            txtQuantity = new TextBox();
            txtPrice = new TextBox();
            txtSaleName = new TextBox();
            txtSaleId = new TextBox();
            labelSingle = new Label();
            labelSearch = new Label();
            labelActions = new Label();
            DeleteSaleBTN = new Button();
            UpdateSaleBTN = new Button();
            AddSaleBTN = new Button();
            SalesGrid = new DataGridView();
            SearchSaleBTN = new Button();
            valueSearch = new TextBox();
            SearchByComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)SalesGrid).BeginInit();
            SuspendLayout();
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new Point(605, 435);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(42, 20);
            labelQuantity.TabIndex = 36;
            labelQuantity.Text = "כמות";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(485, 435);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(41, 20);
            labelPrice.TabIndex = 35;
            labelPrice.Text = "מחיר";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(265, 435);
            labelName.Name = "labelName";
            labelName.Size = new Size(31, 20);
            labelName.TabIndex = 34;
            labelName.Text = "שם";
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(145, 435);
            labelId.Name = "labelId";
            labelId.Size = new Size(44, 20);
            labelId.TabIndex = 33;
            labelId.Text = "מזהה";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(605, 405);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 27);
            txtQuantity.TabIndex = 32;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(485, 405);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 27);
            txtPrice.TabIndex = 31;
            // 
            // txtSaleName
            // 
            txtSaleName.Location = new Point(265, 405);
            txtSaleName.Name = "txtSaleName";
            txtSaleName.Size = new Size(200, 27);
            txtSaleName.TabIndex = 30;
            txtSaleName.TextChanged += txtSaleName_TextChanged;
            // 
            // txtSaleId
            // 
            txtSaleId.Location = new Point(145, 405);
            txtSaleId.Name = "txtSaleId";
            txtSaleId.Size = new Size(100, 27);
            txtSaleId.TabIndex = 29;
            txtSaleId.TextChanged += txtSaleId_TextChanged;
            // 
            // labelSingle
            // 
            labelSingle.AutoSize = true;
            labelSingle.Location = new Point(45, 405);
            labelSingle.Name = "labelSingle";
            labelSingle.Size = new Size(90, 20);
            labelSingle.TabIndex = 28;
            labelSingle.Text = "הצגה בודדת:";
            labelSingle.Click += labelSingle_Click;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(45, 425);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(48, 20);
            labelSearch.TabIndex = 27;
            labelSearch.Text = "חיפוש";
            labelSearch.Visible = false;
            // 
            // labelActions
            // 
            labelActions.AutoSize = true;
            labelActions.Location = new Point(45, 335);
            labelActions.Name = "labelActions";
            labelActions.Size = new Size(57, 20);
            labelActions.TabIndex = 26;
            labelActions.Text = "פעולות:";
            // 
            // DeleteSaleBTN
            // 
            DeleteSaleBTN.Location = new Point(325, 365);
            DeleteSaleBTN.Name = "DeleteSaleBTN";
            DeleteSaleBTN.Size = new Size(120, 40);
            DeleteSaleBTN.TabIndex = 25;
            DeleteSaleBTN.Text = "מחיקת מבצע";
            DeleteSaleBTN.UseVisualStyleBackColor = true;
            DeleteSaleBTN.Click += DeleteSaleBTN_Click_1;
            // 
            // UpdateSaleBTN
            // 
            UpdateSaleBTN.Location = new Point(185, 365);
            UpdateSaleBTN.Name = "UpdateSaleBTN";
            UpdateSaleBTN.Size = new Size(120, 40);
            UpdateSaleBTN.TabIndex = 24;
            UpdateSaleBTN.Text = "עדכון מבצע";
            UpdateSaleBTN.UseVisualStyleBackColor = true;
            // 
            // AddSaleBTN
            // 
            AddSaleBTN.Location = new Point(45, 365);
            AddSaleBTN.Name = "AddSaleBTN";
            AddSaleBTN.Size = new Size(120, 40);
            AddSaleBTN.TabIndex = 23;
            AddSaleBTN.Text = "הוספת מבצע";
            AddSaleBTN.UseVisualStyleBackColor = true;
            // 
            // SalesGrid
            // 
            SalesGrid.AllowUserToAddRows = false;
            SalesGrid.AllowUserToDeleteRows = false;
            SalesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SalesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SalesGrid.Location = new Point(45, 135);
            SalesGrid.MultiSelect = false;
            SalesGrid.Name = "SalesGrid";
            SalesGrid.ReadOnly = true;
            SalesGrid.RowHeadersVisible = false;
            SalesGrid.RowHeadersWidth = 51;
            SalesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SalesGrid.Size = new Size(760, 220);
            SalesGrid.TabIndex = 22;
            SalesGrid.CellContentClick += SalesGrid_CellContentClick;
            // 
            // SearchSaleBTN
            // 
            SearchSaleBTN.Location = new Point(446, 27);
            SearchSaleBTN.Name = "SearchSaleBTN";
            SearchSaleBTN.Size = new Size(90, 30);
            SearchSaleBTN.TabIndex = 21;
            SearchSaleBTN.Text = "חפש";
            SearchSaleBTN.UseVisualStyleBackColor = true;
            // 
            // valueSearch
            // 
            valueSearch.Location = new Point(196, 29);
            valueSearch.Name = "valueSearch";
            valueSearch.Size = new Size(240, 27);
            valueSearch.TabIndex = 20;
            valueSearch.Text = "ערך";
            valueSearch.TextChanged += valueSearch_TextChanged;
            // 
            // SearchByComboBox
            // 
            SearchByComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SearchByComboBox.FormattingEnabled = true;
            SearchByComboBox.Items.AddRange(new object[] { "שם מבצע", "מזהה מוצר", "קטגוריה", "האם למועדון", "תאריך התחלה", "תאריך סיום" });
            SearchByComboBox.Location = new Point(49, 29);
            SearchByComboBox.Name = "SearchByComboBox";
            SearchByComboBox.Size = new Size(140, 28);
            SearchByComboBox.TabIndex = 19;
            SearchByComboBox.Tag = "";
            SearchByComboBox.SelectedIndexChanged += SearchByComboBox_SelectedIndexChanged;
            // 
            // SalesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 548);
            Controls.Add(labelQuantity);
            Controls.Add(labelPrice);
            Controls.Add(labelName);
            Controls.Add(labelId);
            Controls.Add(txtQuantity);
            Controls.Add(txtPrice);
            Controls.Add(txtSaleName);
            Controls.Add(txtSaleId);
            Controls.Add(labelSingle);
            Controls.Add(labelSearch);
            Controls.Add(labelActions);
            Controls.Add(DeleteSaleBTN);
            Controls.Add(UpdateSaleBTN);
            Controls.Add(AddSaleBTN);
            Controls.Add(SalesGrid);
            Controls.Add(SearchSaleBTN);
            Controls.Add(valueSearch);
            Controls.Add(SearchByComboBox);
            Name = "SalesForm";
            Text = "ניהול מבצעים";
            Load += SalesForm_Load;
            ((System.ComponentModel.ISupportInitialize)SalesGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelQuantity;
        private Label labelPrice;
        private Label labelName;
        private Label labelId;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private TextBox txtSaleName;
        private TextBox txtSaleId;
        private Label labelSingle;
        private Label labelSearch;
        private Label labelActions;
        private Button DeleteSaleBTN;
        private Button UpdateSaleBTN;
        private Button AddSaleBTN;
        private DataGridView SalesGrid;
        private Button SearchSaleBTN;
        private TextBox valueSearch;
        private ComboBox SearchByComboBox;
    }
}