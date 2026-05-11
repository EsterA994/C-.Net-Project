namespace UI
{
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
            helloManagerLbl = new Label();
            SuspendLayout();
            // 
            // helloManagerLbl
            // 
            helloManagerLbl.AutoSize = true;
            helloManagerLbl.Location = new Point(368, 84);
            helloManagerLbl.Name = "helloManagerLbl";
            helloManagerLbl.Size = new Size(81, 20);
            helloManagerLbl.TabIndex = 1;
            helloManagerLbl.Text = "שלום מנהל";
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(helloManagerLbl);
            Name = "ManagerForm";
            Text = "ManagerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label helloManagerLbl;
    }
}