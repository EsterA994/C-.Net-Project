namespace UI;

partial class SalesForm
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
        SearchBTN = new Button();
        SalesGrid = new DataGridView();
        AddSaleBTN = new Button();
        UpdateSaleBTN = new Button();
        DeleteSaleBTN = new Button();
        labelSearch = new Label();
        labelActions = new Label();
        ((System.ComponentModel.ISupportInitialize)SalesGrid).BeginInit();
        SuspendLayout();
        // 
        // SearchByComboBox
        // 
        SearchByComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        SearchByComboBox.FormattingEnabled = true;
        SearchByComboBox.Items.AddRange(new object[] { "מזהה", "שם מוצר", "מחיר" });
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
        SearchTextBox.Size = new Size(244, 27);
        SearchTextBox.TabIndex = 1;
        SearchTextBox.TextChanged += SearchTextBox_TextChanged;
        // 
        // SearchBTN
        // 
        SearchBTN.Location = new Point(420, 18);
        SearchBTN.Name = "SearchBTN";
        SearchBTN.Size = new Size(90, 30);
        SearchBTN.TabIndex = 2;
        SearchBTN.Text = "חפש";
        SearchBTN.UseVisualStyleBackColor = true;
        SearchBTN.Click += SearchBTN_Click;
        // 
        // SalesGrid
        // 
        SalesGrid.AllowUserToAddRows = false;
        SalesGrid.AllowUserToDeleteRows = false;
        SalesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        SalesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        SalesGrid.Location = new Point(20, 60);
        SalesGrid.MultiSelect = false;
        SalesGrid.Name = "SalesGrid";
        SalesGrid.ReadOnly = true;
        SalesGrid.RowHeadersVisible = false;
        SalesGrid.RowHeadersWidth = 51;
        SalesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        SalesGrid.Size = new Size(760, 320);
        SalesGrid.TabIndex = 3;
        // 
        // AddSaleBTN
        // 
        AddSaleBTN.Location = new Point(20, 390);
        AddSaleBTN.Name = "AddSaleBTN";
        AddSaleBTN.Size = new Size(120, 40);
        AddSaleBTN.TabIndex = 4;
        AddSaleBTN.Text = "הוסף מבצע";
        AddSaleBTN.UseVisualStyleBackColor = true;
        AddSaleBTN.Click += AddSaleBTN_Click;
        // 
        // UpdateSaleBTN
        // 
        UpdateSaleBTN.Location = new Point(160, 390);
        UpdateSaleBTN.Name = "UpdateSaleBTN";
        UpdateSaleBTN.Size = new Size(120, 40);
        UpdateSaleBTN.TabIndex = 5;
        UpdateSaleBTN.Text = "עדכן מבצע";
        UpdateSaleBTN.UseVisualStyleBackColor = true;
        UpdateSaleBTN.Click += UpdateSaleBTN_Click;
        // 
        // DeleteSaleBTN
        // 
        DeleteSaleBTN.Location = new Point(300, 390);
        DeleteSaleBTN.Name = "DeleteSaleBTN";
        DeleteSaleBTN.Size = new Size(120, 40);
        DeleteSaleBTN.TabIndex = 6;
        DeleteSaleBTN.Text = "מחק מבצע";
        DeleteSaleBTN.UseVisualStyleBackColor = true;
        DeleteSaleBTN.Click += DeleteSaleBTN_Click;
        // 
        // labelSearch
        // 
        labelSearch.AutoSize = true;
        labelSearch.Location = new Point(20, 400);
        labelSearch.Name = "labelSearch";
        labelSearch.Size = new Size(53, 20);
        labelSearch.TabIndex = 7;
        labelSearch.Text = "חיפוש";
        labelSearch.Visible = false;
        // 
        // labelActions
        // 
        labelActions.AutoSize = true;
        labelActions.Location = new Point(20, 370);
        labelActions.Name = "labelActions";
        labelActions.Size = new Size(61, 20);
        labelActions.TabIndex = 8;
        labelActions.Text = "פעולות:";
        // 
        // SalesForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(labelActions);
        Controls.Add(labelSearch);
        Controls.Add(DeleteSaleBTN);
        Controls.Add(UpdateSaleBTN);
        Controls.Add(AddSaleBTN);
        Controls.Add(SalesGrid);
        Controls.Add(SearchBTN);
        Controls.Add(SearchTextBox);
        Controls.Add(SearchByComboBox);
        Name = "SalesForm";
        Text = "ניהול מבצעים";
        Load += SalesForm_Load;
        ((System.ComponentModel.ISupportInitialize)SalesGrid).EndInit();
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox SearchByComboBox;
    private System.Windows.Forms.TextBox SearchTextBox;
    private System.Windows.Forms.Button SearchBTN;
    private System.Windows.Forms.DataGridView SalesGrid;
    private System.Windows.Forms.Button AddSaleBTN;
    private System.Windows.Forms.Button UpdateSaleBTN;
    private System.Windows.Forms.Button DeleteSaleBTN;
    private System.Windows.Forms.Label labelSearch;
    private System.Windows.Forms.Label labelActions;
}
