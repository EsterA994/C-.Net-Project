namespace UI;

partial class ManagerForm
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
        greetingLabel = new Label();
        ProductsBTN = new Button();
        CustomersBTN = new Button();
        SalesBTN = new Button();
        SuspendLayout();
        // 
        // greetingLabel
        // 
        greetingLabel.AutoSize = true;
        greetingLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        greetingLabel.Location = new Point(280, 15);
        greetingLabel.Name = "greetingLabel";
        greetingLabel.Size = new Size(135, 32);
        greetingLabel.TabIndex = 0;
        greetingLabel.Text = "שלום מנהל";
        greetingLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ProductsBTN
        // 
        ProductsBTN.Location = new Point(44, 75);
        ProductsBTN.Margin = new Padding(3, 2, 3, 2);
        ProductsBTN.Name = "ProductsBTN";
        ProductsBTN.Size = new Size(178, 139);
        ProductsBTN.TabIndex = 1;
        ProductsBTN.Text = "מוצרים";
        ProductsBTN.UseVisualStyleBackColor = true;
        // 
        // CustomersBTN
        // 
        CustomersBTN.Location = new Point(262, 75);
        CustomersBTN.Margin = new Padding(3, 2, 3, 2);
        CustomersBTN.Name = "CustomersBTN";
        CustomersBTN.Size = new Size(165, 139);
        CustomersBTN.TabIndex = 2;
        CustomersBTN.Text = "לקוחות";
        CustomersBTN.UseVisualStyleBackColor = true;
        CustomersBTN.Click += CustomersBTN_Click_1;
        // 
        // SalesBTN
        // 
        SalesBTN.AutoEllipsis = true;
        SalesBTN.Location = new Point(452, 75);
        SalesBTN.Margin = new Padding(3, 2, 3, 2);
        SalesBTN.Name = "SalesBTN";
        SalesBTN.Size = new Size(205, 139);
        SalesBTN.TabIndex = 3;
        SalesBTN.Text = "מבצעים";
        SalesBTN.UseVisualStyleBackColor = true;
        // 
        // ManagerForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 374);
        Controls.Add(SalesBTN);
        Controls.Add(CustomersBTN);
        Controls.Add(ProductsBTN);
        Controls.Add(greetingLabel);
        Margin = new Padding(3, 2, 3, 2);
        Name = "ManagerForm";
        Text = "Manager";
        Load += ManagerForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label greetingLabel;
    private System.Windows.Forms.Button ProductsBTN;
    private System.Windows.Forms.Button CustomersBTN;
    private System.Windows.Forms.Button SalesBTN;
}
