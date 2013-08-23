namespace GCUpdaterPlugin
{
    partial class frmUpdating
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
            this.btnInstall = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spinner = new CircularProgress.SpinningProgress.SpinningProgress();
            this.gDL = new System.Windows.Forms.GroupBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.pDownload = new System.Windows.Forms.ProgressBar();
            this.lsvUpdates = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gDL.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(375, 225);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(2);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(81, 29);
            this.btnInstall.TabIndex = 41;
            this.btnInstall.Text = "&Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(495, 1);
            this.label6.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 26);
            this.label1.TabIndex = 36;
            this.label1.Text = "GlobalCommand Update";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(468, 41);
            this.label5.TabIndex = 38;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::GCUpdaterPlugin.Properties.Resources.Network_256x256;
            this.pictureBox2.Location = new System.Drawing.Point(415, 5);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 40;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.spinner);
            this.groupBox1.Controls.Add(this.gDL);
            this.groupBox1.Controls.Add(this.pDownload);
            this.groupBox1.Controls.Add(this.lsvUpdates);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Location = new System.Drawing.Point(6, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(450, 177);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Information";
            // 
            // spinner
            // 
            this.spinner.AutoIncrementFrequency = 500;
            this.spinner.BehindTransistionSegmentIsActive = false;
            this.spinner.Location = new System.Drawing.Point(207, 101);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(30, 32);
            this.spinner.TabIndex = 43;
            this.spinner.TransistionSegment = 0;
            // 
            // gDL
            // 
            this.gDL.Controls.Add(this.lblSize);
            this.gDL.Controls.Add(this.lblSpeed);
            this.gDL.Location = new System.Drawing.Point(88, 106);
            this.gDL.Margin = new System.Windows.Forms.Padding(2);
            this.gDL.Name = "gDL";
            this.gDL.Padding = new System.Windows.Forms.Padding(2);
            this.gDL.Size = new System.Drawing.Size(266, 38);
            this.gDL.TabIndex = 47;
            this.gDL.TabStop = false;
            this.gDL.Text = "Download Statistics:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(127, 18);
            this.lblSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(125, 13);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "0.00000KB of 150000KB";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(11, 18);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(66, 13);
            this.lblSpeed.TabIndex = 0;
            this.lblSpeed.Text = "000000kbps";
            // 
            // pDownload
            // 
            this.pDownload.Location = new System.Drawing.Point(88, 150);
            this.pDownload.Margin = new System.Windows.Forms.Padding(2);
            this.pDownload.Name = "pDownload";
            this.pDownload.Size = new System.Drawing.Size(266, 19);
            this.pDownload.TabIndex = 46;
            this.pDownload.Value = 50;
            // 
            // lsvUpdates
            // 
            this.lsvUpdates.CheckBoxes = true;
            this.lsvUpdates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lsvUpdates.FullRowSelect = true;
            this.lsvUpdates.GridLines = true;
            this.lsvUpdates.Location = new System.Drawing.Point(402, 17);
            this.lsvUpdates.Margin = new System.Windows.Forms.Padding(2);
            this.lsvUpdates.Name = "lsvUpdates";
            this.lsvUpdates.Size = new System.Drawing.Size(439, 152);
            this.lsvUpdates.TabIndex = 45;
            this.lsvUpdates.UseCompatibleStateImageBehavior = false;
            this.lsvUpdates.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Module";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 50;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(4, 28);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(441, 69);
            this.lblStatus.TabIndex = 44;
            this.lblStatus.Text = "Connecting to update server...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2, 225);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 29);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmUpdating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 252);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmUpdating";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updating GlobalCommand";
            this.Load += new System.EventHandler(this.frmUpdating_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gDL.ResumeLayout(false);
            this.gDL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private CircularProgress.SpinningProgress.SpinningProgress spinner;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListView lsvUpdates;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox gDL;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.ProgressBar pDownload;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnCancel;
    }
}