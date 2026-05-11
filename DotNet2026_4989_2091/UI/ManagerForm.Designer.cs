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
        greetingLabel.Location = new Point(320, 20);
        greetingLabel.Name = "greetingLabel";
        greetingLabel.Size = new Size(169, 41);
        greetingLabel.TabIndex = 0;
        greetingLabel.Text = "שלום מנהל";
        greetingLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ProductsBTN
        // 
        ProductsBTN.Location = new Point(50, 100);
        ProductsBTN.Name = "ProductsBTN";
        ProductsBTN.Size = new Size(204, 185);
        ProductsBTN.TabIndex = 1;
        ProductsBTN.Text = "מוצרים";
        ProductsBTN.UseVisualStyleBackColor = true;
        // 
        // CustomersBTN
        // 
        CustomersBTN.Location = new Point(300, 100);
        CustomersBTN.Name = "CustomersBTN";
        CustomersBTN.Size = new Size(189, 185);
        CustomersBTN.TabIndex = 2;
        CustomersBTN.Text = "לקוחות";
        CustomersBTN.UseVisualStyleBackColor = true;
        // 
        // SalesBTN
        // 
        SalesBTN.AutoEllipsis = true;
        SalesBTN.Location = new Point(516, 100);
        SalesBTN.Name = "SalesBTN";
        SalesBTN.Size = new Size(234, 185);
        SalesBTN.TabIndex = 3;
        SalesBTN.Text = "מבצעים";
        SalesBTN.UseVisualStyleBackColor = true;
        // 
        // ManagerForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 499);
        Controls.Add(SalesBTN);
        Controls.Add(CustomersBTN);
        Controls.Add(ProductsBTN);
        Controls.Add(greetingLabel);
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
