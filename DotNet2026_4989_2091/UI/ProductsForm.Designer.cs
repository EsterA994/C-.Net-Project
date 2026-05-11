namespace UI;

partial class ProductsForm
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
        SearchByComboBox = new ComboBox();
        SearchTextBox = new TextBox();
        SearchProductsBTN = new Button();
        ProductsGrid = new DataGridView();
        AddProductBTN = new Button();
        UpdateProductBTN = new Button();
        DeleteProductBTN = new Button();
        labelActions = new Label();
        labelSearch = new Label();
        labelSingle = new Label();
        txtProdId = new TextBox();
        txtProdName = new TextBox();
        txtPrice = new TextBox();
        txtQuantity = new TextBox();
        labelId = new Label();
        labelName = new Label();
        labelPrice = new Label();
        labelQuantity = new Label();
        ((System.ComponentModel.ISupportInitialize)ProductsGrid).BeginInit();
        SuspendLayout();
        // 
        // SearchByComboBox
        // 
        SearchByComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        SearchByComboBox.FormattingEnabled = true;
        SearchByComboBox.Items.AddRange(new object[] { "שם מוצר", "קטגוריה", "טווח מחיר" });
        SearchByComboBox.Location = new Point(20, 20);
        SearchByComboBox.Name = "SearchByComboBox";
        SearchByComboBox.Size = new Size(140, 28);
        SearchByComboBox.TabIndex = 0;
        // 
        // SearchTextBox
        // 
        SearchTextBox.Location = new Point(170, 20);
        SearchTextBox.Name = "SearchTextBox";
        SearchTextBox.Size = new Size(240, 27);
        SearchTextBox.TabIndex = 1;
        SearchTextBox.TextChanged += SearchTextBox_TextChanged;
        // 
        // SearchProductsBTN
        // 
        SearchProductsBTN.Location = new Point(420, 18);
        SearchProductsBTN.Name = "SearchProductsBTN";
        SearchProductsBTN.Size = new Size(90, 30);
        SearchProductsBTN.TabIndex = 2;
        SearchProductsBTN.Text = "חפש";
        SearchProductsBTN.UseVisualStyleBackColor = true;
        SearchProductsBTN.Click += SearchProductsBTN_Click;
        // 
        // ProductsGrid
        // 
        ProductsGrid.AllowUserToAddRows = false;
        ProductsGrid.AllowUserToDeleteRows = false;
        ProductsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        ProductsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        ProductsGrid.Location = new Point(20, 60);
        ProductsGrid.MultiSelect = false;
        ProductsGrid.Name = "ProductsGrid";
        ProductsGrid.ReadOnly = true;
        ProductsGrid.RowHeadersVisible = false;
        ProductsGrid.RowHeadersWidth = 51;
        ProductsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        ProductsGrid.Size = new Size(760, 220);
        ProductsGrid.TabIndex = 3;
        ProductsGrid.SelectionChanged += ProductsGrid_SelectionChanged;
        // 
        // AddProductBTN
        // 
        AddProductBTN.Location = new Point(20, 290);
        AddProductBTN.Name = "AddProductBTN";
        AddProductBTN.Size = new Size(120, 40);
        AddProductBTN.TabIndex = 4;
        AddProductBTN.Text = "הוספת מוצר";
        AddProductBTN.UseVisualStyleBackColor = true;
        AddProductBTN.Click += AddProductBTN_Click;
        // 
        // UpdateProductBTN
        // 
        UpdateProductBTN.Location = new Point(160, 290);
        UpdateProductBTN.Name = "UpdateProductBTN";
        UpdateProductBTN.Size = new Size(120, 40);
        UpdateProductBTN.TabIndex = 5;
        UpdateProductBTN.Text = "עדכון מוצר";
        UpdateProductBTN.UseVisualStyleBackColor = true;
        UpdateProductBTN.Click += UpdateProductBTN_Click;
        // 
        // DeleteProductBTN
        // 
        DeleteProductBTN.Location = new Point(300, 290);
        DeleteProductBTN.Name = "DeleteProductBTN";
        DeleteProductBTN.Size = new Size(120, 40);
        DeleteProductBTN.TabIndex = 6;
        DeleteProductBTN.Text = "מחיקת מוצר";
        DeleteProductBTN.UseVisualStyleBackColor = true;
        DeleteProductBTN.Click += DeleteProductBTN_Click;
        // 
        // labelActions
        // 
        labelActions.AutoSize = true;
        labelActions.Location = new Point(20, 260);
        labelActions.Name = "labelActions";
        labelActions.Size = new Size(57, 20);
        labelActions.TabIndex = 8;
        labelActions.Text = "פעולות:";
        // 
        // labelSearch
        // 
        labelSearch.AutoSize = true;
        labelSearch.Location = new Point(20, 350);
        labelSearch.Name = "labelSearch";
        labelSearch.Size = new Size(48, 20);
        labelSearch.TabIndex = 9;
        labelSearch.Text = "חיפוש";
        labelSearch.Visible = false;
        // 
        // labelSingle
        // 
        labelSingle.AutoSize = true;
        labelSingle.Location = new Point(20, 330);
        labelSingle.Name = "labelSingle";
        labelSingle.Size = new Size(90, 20);
        labelSingle.TabIndex = 10;
        labelSingle.Text = "הצגה בודדת:";
        // 
        // txtProdId
        // 
        txtProdId.Location = new Point(120, 330);
        txtProdId.Name = "txtProdId";
        txtProdId.Size = new Size(100, 27);
        txtProdId.TabIndex = 11;
        // 
        // txtProdName
        // 
        txtProdName.Location = new Point(240, 330);
        txtProdName.Name = "txtProdName";
        txtProdName.Size = new Size(200, 27);
        txtProdName.TabIndex = 12;
        // 
        // txtPrice
        // 
        txtPrice.Location = new Point(460, 330);
        txtPrice.Name = "txtPrice";
        txtPrice.Size = new Size(100, 27);
        txtPrice.TabIndex = 13;
        // 
        // txtQuantity
        // 
        txtQuantity.Location = new Point(580, 330);
        txtQuantity.Name = "txtQuantity";
        txtQuantity.Size = new Size(100, 27);
        txtQuantity.TabIndex = 14;
        // 
        // labelId
        // 
        labelId.AutoSize = true;
        labelId.Location = new Point(120, 360);
        labelId.Name = "labelId";
        labelId.Size = new Size(44, 20);
        labelId.TabIndex = 15;
        labelId.Text = "מזהה";
        // 
        // labelName
        // 
        labelName.AutoSize = true;
        labelName.Location = new Point(240, 360);
        labelName.Name = "labelName";
        labelName.Size = new Size(31, 20);
        labelName.TabIndex = 16;
        labelName.Text = "שם";
        // 
        // labelPrice
        // 
        labelPrice.AutoSize = true;
        labelPrice.Location = new Point(460, 360);
        labelPrice.Name = "labelPrice";
        labelPrice.Size = new Size(41, 20);
        labelPrice.TabIndex = 17;
        labelPrice.Text = "מחיר";
        // 
        // labelQuantity
        // 
        labelQuantity.AutoSize = true;
        labelQuantity.Location = new Point(580, 360);
        labelQuantity.Name = "labelQuantity";
        labelQuantity.Size = new Size(42, 20);
        labelQuantity.TabIndex = 18;
        labelQuantity.Text = "כמות";
        // 
        // ProductsForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 420);
        Controls.Add(labelQuantity);
        Controls.Add(labelPrice);
        Controls.Add(labelName);
        Controls.Add(labelId);
        Controls.Add(txtQuantity);
        Controls.Add(txtPrice);
        Controls.Add(txtProdName);
        Controls.Add(txtProdId);
        Controls.Add(labelSingle);
        Controls.Add(labelSearch);
        Controls.Add(labelActions);
        Controls.Add(DeleteProductBTN);
        Controls.Add(UpdateProductBTN);
        Controls.Add(AddProductBTN);
        Controls.Add(ProductsGrid);
        Controls.Add(SearchProductsBTN);
        Controls.Add(SearchTextBox);
        Controls.Add(SearchByComboBox);
        Name = "ProductsForm";
        Text = "ניהול מוצרים";
        Load += ProductsForm_Load;
        ((System.ComponentModel.ISupportInitialize)ProductsGrid).EndInit();
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox SearchByComboBox;
    private System.Windows.Forms.TextBox SearchTextBox;
    private System.Windows.Forms.Button SearchProductsBTN;
    private System.Windows.Forms.DataGridView ProductsGrid;
    private System.Windows.Forms.Button AddProductBTN;
    private System.Windows.Forms.Button UpdateProductBTN;
    private System.Windows.Forms.Button DeleteProductBTN;
    private System.Windows.Forms.Label labelActions;
    private System.Windows.Forms.Label labelSearch;
    private System.Windows.Forms.Label labelSingle;
    private System.Windows.Forms.TextBox txtProdId;
    private System.Windows.Forms.TextBox txtProdName;
    private System.Windows.Forms.TextBox txtPrice;
    private System.Windows.Forms.TextBox txtQuantity;
    private System.Windows.Forms.Label labelId;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Label labelPrice;
    private System.Windows.Forms.Label labelQuantity;
}
