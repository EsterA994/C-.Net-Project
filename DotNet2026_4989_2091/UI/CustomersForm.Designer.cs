namespace UI;

partial class CustomersForm
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
        SearchCustomersBTN = new Button();
        CustomersGrid = new DataGridView();
        AddCustomerBTN = new Button();
        UpdateCustomerBTN = new Button();
        DeleteCustomerBTN = new Button();
        labelActions = new Label();
        labelSearch = new Label();
        labelSingle = new Label();
        txtCustId = new TextBox();
        txtCustName = new TextBox();
        txtCustAddress = new TextBox();
        txtCustPhone = new TextBox();
        labelId = new Label();
        labelName = new Label();
        labelAddress = new Label();
        labelPhone = new Label();
        ((System.ComponentModel.ISupportInitialize)CustomersGrid).BeginInit();
        SuspendLayout();
        // 
        // SearchByComboBox
        // 
        SearchByComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        SearchByComboBox.FormattingEnabled = true;
        SearchByComboBox.Items.AddRange(new object[] { "שם", "כתובת", "טלפון" });
        SearchByComboBox.Location = new Point(20, 20);
        SearchByComboBox.Name = "SearchByComboBox";
        SearchByComboBox.Size = new Size(140, 28);
        SearchByComboBox.TabIndex = 0;
        SearchByComboBox.SelectedIndexChanged += SearchByComboBox_SelectedIndexChanged;
        // 
        // SearchTextBox
        // 
        SearchTextBox.Location = new Point(170, 20);
        SearchTextBox.Name = "SearchTextBox";
        SearchTextBox.Size = new Size(240, 27);
        SearchTextBox.TabIndex = 1;
        SearchTextBox.TextChanged += SearchTextBox_TextChanged_1;
        // 
        // SearchCustomersBTN
        // 
        SearchCustomersBTN.Location = new Point(420, 18);
        SearchCustomersBTN.Name = "SearchCustomersBTN";
        SearchCustomersBTN.Size = new Size(90, 30);
        SearchCustomersBTN.TabIndex = 2;
        SearchCustomersBTN.Text = "חפש";
        SearchCustomersBTN.UseVisualStyleBackColor = true;
        SearchCustomersBTN.Click += SearchCustomersBTN_Click;
        // 
        // CustomersGrid
        // 
        CustomersGrid.AllowUserToAddRows = false;
        CustomersGrid.AllowUserToDeleteRows = false;
        CustomersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        CustomersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        CustomersGrid.Location = new Point(20, 60);
        CustomersGrid.MultiSelect = false;
        CustomersGrid.Name = "CustomersGrid";
        CustomersGrid.ReadOnly = true;
        CustomersGrid.RowHeadersVisible = false;
        CustomersGrid.RowHeadersWidth = 51;
        CustomersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        CustomersGrid.Size = new Size(760, 220);
        CustomersGrid.TabIndex = 3;
        CustomersGrid.CellContentClick += CustomersGrid_CellContentClick;
        CustomersGrid.SelectionChanged += CustomersGrid_SelectionChanged;
        // 
        // AddCustomerBTN
        // 
        AddCustomerBTN.Location = new Point(20, 290);
        AddCustomerBTN.Name = "AddCustomerBTN";
        AddCustomerBTN.Size = new Size(120, 40);
        AddCustomerBTN.TabIndex = 4;
        AddCustomerBTN.Text = "הוספת לקוח";
        AddCustomerBTN.UseVisualStyleBackColor = true;
        AddCustomerBTN.Click += AddCustomerBTN_Click;
        // 
        // UpdateCustomerBTN
        // 
        UpdateCustomerBTN.Location = new Point(160, 290);
        UpdateCustomerBTN.Name = "UpdateCustomerBTN";
        UpdateCustomerBTN.Size = new Size(120, 40);
        UpdateCustomerBTN.TabIndex = 5;
        UpdateCustomerBTN.Text = "עדכון לקוח";
        UpdateCustomerBTN.UseVisualStyleBackColor = true;
        UpdateCustomerBTN.Click += UpdateCustomerBTN_Click;
        // 
        // DeleteCustomerBTN
        // 
        DeleteCustomerBTN.Location = new Point(300, 290);
        DeleteCustomerBTN.Name = "DeleteCustomerBTN";
        DeleteCustomerBTN.Size = new Size(120, 40);
        DeleteCustomerBTN.TabIndex = 6;
        DeleteCustomerBTN.Text = "מחיקת לקוח";
        DeleteCustomerBTN.UseVisualStyleBackColor = true;
        DeleteCustomerBTN.Click += DeleteCustomerBTN_Click;
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
        // txtCustId
        // 
        txtCustId.Location = new Point(120, 330);
        txtCustId.Name = "txtCustId";
        txtCustId.Size = new Size(100, 27);
        txtCustId.TabIndex = 11;
        txtCustId.TextChanged += txtCustId_TextChanged;
        // 
        // txtCustName
        // 
        txtCustName.Location = new Point(240, 330);
        txtCustName.Name = "txtCustName";
        txtCustName.Size = new Size(200, 27);
        txtCustName.TabIndex = 12;
        // 
        // txtCustAddress
        // 
        txtCustAddress.Location = new Point(460, 330);
        txtCustAddress.Name = "txtCustAddress";
        txtCustAddress.Size = new Size(220, 27);
        txtCustAddress.TabIndex = 13;
        // 
        // txtCustPhone
        // 
        txtCustPhone.Location = new Point(700, 330);
        txtCustPhone.Name = "txtCustPhone";
        txtCustPhone.Size = new Size(120, 27);
        txtCustPhone.TabIndex = 14;
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
        // labelAddress
        // 
        labelAddress.AutoSize = true;
        labelAddress.Location = new Point(460, 360);
        labelAddress.Name = "labelAddress";
        labelAddress.Size = new Size(52, 20);
        labelAddress.TabIndex = 17;
        labelAddress.Text = "כתובת";
        // 
        // labelPhone
        // 
        labelPhone.AutoSize = true;
        labelPhone.Location = new Point(700, 360);
        labelPhone.Name = "labelPhone";
        labelPhone.Size = new Size(44, 20);
        labelPhone.TabIndex = 18;
        labelPhone.Text = "טלפון";
        // 
        // CustomersForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(840, 420);
        Controls.Add(labelPhone);
        Controls.Add(labelAddress);
        Controls.Add(labelName);
        Controls.Add(labelId);
        Controls.Add(txtCustPhone);
        Controls.Add(txtCustAddress);
        Controls.Add(txtCustName);
        Controls.Add(txtCustId);
        Controls.Add(labelSingle);
        Controls.Add(labelSearch);
        Controls.Add(labelActions);
        Controls.Add(DeleteCustomerBTN);
        Controls.Add(UpdateCustomerBTN);
        Controls.Add(AddCustomerBTN);
        Controls.Add(CustomersGrid);
        Controls.Add(SearchCustomersBTN);
        Controls.Add(SearchTextBox);
        Controls.Add(SearchByComboBox);
        Name = "CustomersForm";
        Text = "ניהול לקוחות";
        Load += CustomersForm_Load;
        ((System.ComponentModel.ISupportInitialize)CustomersGrid).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.ComboBox SearchByComboBox;
    private System.Windows.Forms.TextBox SearchTextBox;
    private System.Windows.Forms.Button SearchCustomersBTN;
    private System.Windows.Forms.DataGridView CustomersGrid;
    private System.Windows.Forms.Button AddCustomerBTN;
    private System.Windows.Forms.Button UpdateCustomerBTN;
    private System.Windows.Forms.Button DeleteCustomerBTN;
    private System.Windows.Forms.Label labelActions;
    private System.Windows.Forms.Label labelSearch;
    private System.Windows.Forms.Label labelSingle;
    private System.Windows.Forms.TextBox txtCustId;
    private System.Windows.Forms.TextBox txtCustName;
    private System.Windows.Forms.TextBox txtCustAddress;
    private System.Windows.Forms.TextBox txtCustPhone;
    private System.Windows.Forms.Label labelId;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Label labelAddress;
    private System.Windows.Forms.Label labelPhone;
}
