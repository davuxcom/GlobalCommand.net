namespace GlobalCommand
{
    partial class frmWb
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
            this._wb = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // _wb
            // 
            this._wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this._wb.Location = new System.Drawing.Point(0, 0);
            this._wb.MinimumSize = new System.Drawing.Size(20, 20);
            this._wb.Name = "_wb";
            this._wb.Size = new System.Drawing.Size(789, 508);
            this._wb.TabIndex = 0;
            // 
            // frmWb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 508);
            this.Controls.Add(this._wb);
            this.Name = "frmWb";
            this.ShowIcon = false;
            this.Text = "GlobalCommand 3 Help";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser _wb;
    }
}