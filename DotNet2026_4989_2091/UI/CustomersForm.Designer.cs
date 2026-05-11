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
        this.SearchByComboBox = new System.Windows.Forms.ComboBox();
        this.SearchTextBox = new System.Windows.Forms.TextBox();
        this.SearchCustomersBTN = new System.Windows.Forms.Button();
        this.CustomersGrid = new System.Windows.Forms.DataGridView();
        this.AddCustomerBTN = new System.Windows.Forms.Button();
        this.UpdateCustomerBTN = new System.Windows.Forms.Button();
        this.DeleteCustomerBTN = new System.Windows.Forms.Button();
        this.labelActions = new System.Windows.Forms.Label();
        this.labelSearch = new System.Windows.Forms.Label();
        this.labelSingle = new System.Windows.Forms.Label();
        this.txtCustId = new System.Windows.Forms.TextBox();
        this.txtCustName = new System.Windows.Forms.TextBox();
        this.txtCustAddress = new System.Windows.Forms.TextBox();
        this.txtCustPhone = new System.Windows.Forms.TextBox();
        this.labelId = new System.Windows.Forms.Label();
        this.labelName = new System.Windows.Forms.Label();
        this.labelAddress = new System.Windows.Forms.Label();
        this.labelPhone = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.CustomersGrid)).BeginInit();
        this.SuspendLayout();
        // 
        // SearchByComboBox
        // 
        this.SearchByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.SearchByComboBox.FormattingEnabled = true;
        this.SearchByComboBox.Items.AddRange(new object[] {
            "שם",
            "כתובת",
            "טלפון"});
        this.SearchByComboBox.Location = new System.Drawing.Point(20, 20);
        this.SearchByComboBox.Name = "SearchByComboBox";
        this.SearchByComboBox.Size = new System.Drawing.Size(140, 28);
        this.SearchByComboBox.TabIndex = 0;
        // 
        // SearchTextBox
        // 
        this.SearchTextBox.Location = new System.Drawing.Point(170, 20);
        this.SearchTextBox.Name = "SearchTextBox";
        this.SearchTextBox.Size = new System.Drawing.Size(240, 27);
        this.SearchTextBox.TabIndex = 1;
        // 
        // SearchCustomersBTN
        // 
        this.SearchCustomersBTN.Location = new System.Drawing.Point(420, 18);
        this.SearchCustomersBTN.Name = "SearchCustomersBTN";
        this.SearchCustomersBTN.Size = new System.Drawing.Size(90, 30);
        this.SearchCustomersBTN.TabIndex = 2;
        this.SearchCustomersBTN.Text = "חפש";
        this.SearchCustomersBTN.UseVisualStyleBackColor = true;
        this.SearchCustomersBTN.Click += new System.EventHandler(this.SearchCustomersBTN_Click);
        // 
        // CustomersGrid
        // 
        this.CustomersGrid.AllowUserToAddRows = false;
        this.CustomersGrid.AllowUserToDeleteRows = false;
        this.CustomersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.CustomersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.CustomersGrid.Location = new System.Drawing.Point(20, 60);
        this.CustomersGrid.MultiSelect = false;
        this.CustomersGrid.Name = "CustomersGrid";
        this.CustomersGrid.ReadOnly = true;
        this.CustomersGrid.RowHeadersVisible = false;
        this.CustomersGrid.RowTemplate.Height = 29;
        this.CustomersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.CustomersGrid.Size = new System.Drawing.Size(760, 220);
        this.CustomersGrid.TabIndex = 3;
        this.CustomersGrid.SelectionChanged += new System.EventHandler(this.CustomersGrid_SelectionChanged);
        // 
        // AddCustomerBTN
        // 
        this.AddCustomerBTN.Location = new System.Drawing.Point(20, 290);
        this.AddCustomerBTN.Name = "AddCustomerBTN";
        this.AddCustomerBTN.Size = new System.Drawing.Size(120, 40);
        this.AddCustomerBTN.TabIndex = 4;
        this.AddCustomerBTN.Text = "הוספת לקוח";
        this.AddCustomerBTN.UseVisualStyleBackColor = true;
        this.AddCustomerBTN.Click += new System.EventHandler(this.AddCustomerBTN_Click);
        // 
        // UpdateCustomerBTN
        // 
        this.UpdateCustomerBTN.Location = new System.Drawing.Point(160, 290);
        this.UpdateCustomerBTN.Name = "UpdateCustomerBTN";
        this.UpdateCustomerBTN.Size = new System.Drawing.Size(120, 40);
        this.UpdateCustomerBTN.TabIndex = 5;
        this.UpdateCustomerBTN.Text = "עדכון לקוח";
        this.UpdateCustomerBTN.UseVisualStyleBackColor = true;
        this.UpdateCustomerBTN.Click += new System.EventHandler(this.UpdateCustomerBTN_Click);
        // 
        // DeleteCustomerBTN
        // 
        this.DeleteCustomerBTN.Location = new System.Drawing.Point(300, 290);
        this.DeleteCustomerBTN.Name = "DeleteCustomerBTN";
        this.DeleteCustomerBTN.Size = new System.Drawing.Size(120, 40);
        this.DeleteCustomerBTN.TabIndex = 6;
        this.DeleteCustomerBTN.Text = "מחיקת לקוח";
        this.DeleteCustomerBTN.UseVisualStyleBackColor = true;
        this.DeleteCustomerBTN.Click += new System.EventHandler(this.DeleteCustomerBTN_Click);
        // 
        // labelActions
        // 
        this.labelActions.AutoSize = true;
        this.labelActions.Location = new System.Drawing.Point(20, 260);
        this.labelActions.Name = "labelActions";
        this.labelActions.Size = new System.Drawing.Size(61, 20);
        this.labelActions.TabIndex = 8;
        this.labelActions.Text = "פעולות:";
        // 
        // labelSearch
        // 
        this.labelSearch.AutoSize = true;
        this.labelSearch.Location = new System.Drawing.Point(20, 350);
        this.labelSearch.Name = "labelSearch";
        this.labelSearch.Size = new System.Drawing.Size(53, 20);
        this.labelSearch.TabIndex = 9;
        this.labelSearch.Text = "חיפוש";
        this.labelSearch.Visible = false;
        // 
        // labelSingle
        // 
        this.labelSingle.AutoSize = true;
        this.labelSingle.Location = new System.Drawing.Point(20, 330);
        this.labelSingle.Name = "labelSingle";
        this.labelSingle.Size = new System.Drawing.Size(88, 20);
        this.labelSingle.TabIndex = 10;
        this.labelSingle.Text = "הצגה בודדת:";
        // 
        // txtCustId
        // 
        this.txtCustId.Location = new System.Drawing.Point(120, 330);
        this.txtCustId.Name = "txtCustId";
        this.txtCustId.Size = new System.Drawing.Size(100, 27);
        this.txtCustId.TabIndex = 11;
        // 
        // txtCustName
        // 
        this.txtCustName.Location = new System.Drawing.Point(240, 330);
        this.txtCustName.Name = "txtCustName";
        this.txtCustName.Size = new System.Drawing.Size(200, 27);
        this.txtCustName.TabIndex = 12;
        // 
        // txtCustAddress
        // 
        this.txtCustAddress.Location = new System.Drawing.Point(460, 330);
        this.txtCustAddress.Name = "txtCustAddress";
        this.txtCustAddress.Size = new System.Drawing.Size(220, 27);
        this.txtCustAddress.TabIndex = 13;
        // 
        // txtCustPhone
        // 
        this.txtCustPhone.Location = new System.Drawing.Point(700, 330);
        this.txtCustPhone.Name = "txtCustPhone";
        this.txtCustPhone.Size = new System.Drawing.Size(120, 27);
        this.txtCustPhone.TabIndex = 14;
        // 
        // labelId
        // 
        this.labelId.AutoSize = true;
        this.labelId.Location = new System.Drawing.Point(120, 360);
        this.labelId.Name = "labelId";
        this.labelId.Size = new System.Drawing.Size(38, 20);
        this.labelId.TabIndex = 15;
        this.labelId.Text = "מזהה";
        // 
        // labelName
        // 
        this.labelName.AutoSize = true;
        this.labelName.Location = new System.Drawing.Point(240, 360);
        this.labelName.Name = "labelName";
        this.labelName.Size = new System.Drawing.Size(38, 20);
        this.labelName.TabIndex = 16;
        this.labelName.Text = "שם";
        // 
        // labelAddress
        // 
        this.labelAddress.AutoSize = true;
        this.labelAddress.Location = new System.Drawing.Point(460, 360);
        this.labelAddress.Name = "labelAddress";
        this.labelAddress.Size = new System.Drawing.Size(38, 20);
        this.labelAddress.TabIndex = 17;
        this.labelAddress.Text = "כתובת";
        // 
        // labelPhone
        // 
        this.labelPhone.AutoSize = true;
        this.labelPhone.Location = new System.Drawing.Point(700, 360);
        this.labelPhone.Name = "labelPhone";
        this.labelPhone.Size = new System.Drawing.Size(38, 20);
        this.labelPhone.TabIndex = 18;
        this.labelPhone.Text = "טלפון";
        // 
        // CustomersForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(840, 420);
        this.Controls.Add(this.labelPhone);
        this.Controls.Add(this.labelAddress);
        this.Controls.Add(this.labelName);
        this.Controls.Add(this.labelId);
        this.Controls.Add(this.txtCustPhone);
        this.Controls.Add(this.txtCustAddress);
        this.Controls.Add(this.txtCustName);
        this.Controls.Add(this.txtCustId);
        this.Controls.Add(this.labelSingle);
        this.Controls.Add(this.labelSearch);
        this.Controls.Add(this.labelActions);
        this.Controls.Add(this.DeleteCustomerBTN);
        this.Controls.Add(this.UpdateCustomerBTN);
        this.Controls.Add(this.AddCustomerBTN);
        this.Controls.Add(this.CustomersGrid);
        this.Controls.Add(this.SearchCustomersBTN);
        this.Controls.Add(this.SearchTextBox);
        this.Controls.Add(this.SearchByComboBox);
        this.Name = "CustomersForm";
        this.Text = "ניהול לקוחות";
        this.Load += new System.EventHandler(this.CustomersForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.CustomersGrid)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

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
