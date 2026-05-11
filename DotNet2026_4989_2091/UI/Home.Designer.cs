namespace UI
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SellerButton = new Button();
            ManagerButton = new Button();
            HomeTitle = new Label();
            SuspendLayout();
            // 
            // SellerButton
            // 
            SellerButton.Location = new Point(165, 176);
            SellerButton.Name = "SellerButton";
            SellerButton.Size = new Size(201, 130);
            SellerButton.TabIndex = 0;
            SellerButton.Text = "קופאי";
            SellerButton.UseVisualStyleBackColor = true;
            SellerButton.Click += SellerButton_Click;
            // 
            // ManagerButton
            // 
            ManagerButton.Location = new Point(394, 176);
            ManagerButton.Name = "ManagerButton";
            ManagerButton.Size = new Size(201, 130);
            ManagerButton.TabIndex = 0;
            ManagerButton.Text = "מנהל";
            ManagerButton.UseVisualStyleBackColor = true;
            ManagerButton.Click += ManagerButton_Click;
            // 
            // HomeTitle
            // 
            HomeTitle.AutoSize = true;
            HomeTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HomeTitle.Location = new Point(263, 101);
            HomeTitle.Name = "HomeTitle";
            HomeTitle.Size = new Size(222, 41);
            HomeTitle.TabIndex = 1;
            HomeTitle.Text = "חנות המשחקים";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(HomeTitle);
            Controls.Add(ManagerButton);
            Controls.Add(SellerButton);
            Name = "Home";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SellerButton;
        private Button ManagerButton;
        private Label HomeTitle;
    }
}
