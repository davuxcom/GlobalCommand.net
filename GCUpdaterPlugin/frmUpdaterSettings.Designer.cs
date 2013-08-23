namespace GCUpdaterPlugin
{
    partial class frmUpdaterSettings
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
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cDisplayAll = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rAutoUpdateDisabled = new System.Windows.Forms.RadioButton();
            this.rAutoUpdateEnabled = new System.Windows.Forms.RadioButton();
            this.txtRepo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateNow = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(212, 176);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 29);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "&OK";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(345, 1);
            this.label6.TabIndex = 32;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cDisplayAll);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtRepo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(2, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(294, 129);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // cDisplayAll
            // 
            this.cDisplayAll.Location = new System.Drawing.Point(9, 25);
            this.cDisplayAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cDisplayAll.Name = "cDisplayAll";
            this.cDisplayAll.Size = new System.Drawing.Size(153, 53);
            this.cDisplayAll.TabIndex = 15;
            this.cDisplayAll.Text = "Display all available packages in the repository.";
            this.cDisplayAll.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rAutoUpdateDisabled);
            this.groupBox2.Controls.Add(this.rAutoUpdateEnabled);
            this.groupBox2.Location = new System.Drawing.Point(176, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(111, 83);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Automatic Updates";
            // 
            // rAutoUpdateDisabled
            // 
            this.rAutoUpdateDisabled.AutoSize = true;
            this.rAutoUpdateDisabled.Location = new System.Drawing.Point(15, 52);
            this.rAutoUpdateDisabled.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rAutoUpdateDisabled.Name = "rAutoUpdateDisabled";
            this.rAutoUpdateDisabled.Size = new System.Drawing.Size(66, 17);
            this.rAutoUpdateDisabled.TabIndex = 1;
            this.rAutoUpdateDisabled.TabStop = true;
            this.rAutoUpdateDisabled.Text = "Disabled";
            this.rAutoUpdateDisabled.UseVisualStyleBackColor = true;
            // 
            // rAutoUpdateEnabled
            // 
            this.rAutoUpdateEnabled.AutoSize = true;
            this.rAutoUpdateEnabled.Location = new System.Drawing.Point(15, 26);
            this.rAutoUpdateEnabled.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rAutoUpdateEnabled.Name = "rAutoUpdateEnabled";
            this.rAutoUpdateEnabled.Size = new System.Drawing.Size(64, 17);
            this.rAutoUpdateEnabled.TabIndex = 0;
            this.rAutoUpdateEnabled.TabStop = true;
            this.rAutoUpdateEnabled.Text = "Enabled";
            this.rAutoUpdateEnabled.UseVisualStyleBackColor = true;
            // 
            // txtRepo
            // 
            this.txtRepo.Location = new System.Drawing.Point(6, 104);
            this.txtRepo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRepo.Name = "txtRepo";
            this.txtRepo.Size = new System.Drawing.Size(282, 20);
            this.txtRepo.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Repository:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 26);
            this.label1.TabIndex = 29;
            this.label1.Text = "Updater Settings";
            // 
            // btnUpdateNow
            // 
            this.btnUpdateNow.Location = new System.Drawing.Point(9, 176);
            this.btnUpdateNow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdateNow.Name = "btnUpdateNow";
            this.btnUpdateNow.Size = new System.Drawing.Size(94, 29);
            this.btnUpdateNow.TabIndex = 35;
            this.btnUpdateNow.Text = "&Update Now";
            this.btnUpdateNow.UseVisualStyleBackColor = true;
            this.btnUpdateNow.Click += new System.EventHandler(this.btnUpdateNow_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(318, 41);
            this.label5.TabIndex = 31;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::GCUpdaterPlugin.Properties.Resources.globe;
            this.pictureBox2.Location = new System.Drawing.Point(264, 5);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // frmUpdaterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 207);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdateNow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmUpdaterSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updater Settings";
            this.Load += new System.EventHandler(this.frmUpdaterSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateNow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rAutoUpdateDisabled;
        private System.Windows.Forms.RadioButton rAutoUpdateEnabled;
        private System.Windows.Forms.TextBox txtRepo;
        private System.Windows.Forms.CheckBox cDisplayAll;
    }
}