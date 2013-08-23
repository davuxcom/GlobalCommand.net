namespace GlobalCommand
{
    partial class frmPluginSecurity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPluginSecurity));
            this.label1 = new System.Windows.Forms.Label();
            this.btnAllowOnce = new System.Windows.Forms.Button();
            this.btnAllowAlways = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSig = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPlugin = new System.Windows.Forms.Label();
            this.lblNotice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Security Warning";
            // 
            // btnAllowOnce
            // 
            this.btnAllowOnce.Location = new System.Drawing.Point(2, 188);
            this.btnAllowOnce.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAllowOnce.Name = "btnAllowOnce";
            this.btnAllowOnce.Size = new System.Drawing.Size(76, 28);
            this.btnAllowOnce.TabIndex = 3;
            this.btnAllowOnce.Text = "&Allow Once";
            this.btnAllowOnce.UseVisualStyleBackColor = true;
            this.btnAllowOnce.Click += new System.EventHandler(this.btnAllowOnce_Click);
            // 
            // btnAllowAlways
            // 
            this.btnAllowAlways.Location = new System.Drawing.Point(91, 188);
            this.btnAllowAlways.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAllowAlways.Name = "btnAllowAlways";
            this.btnAllowAlways.Size = new System.Drawing.Size(76, 28);
            this.btnAllowAlways.TabIndex = 4;
            this.btnAllowAlways.Text = "Allow Always";
            this.btnAllowAlways.UseVisualStyleBackColor = true;
            this.btnAllowAlways.Click += new System.EventHandler(this.btnAllowAlways_Click);
            // 
            // btnReject
            // 
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.Location = new System.Drawing.Point(178, 188);
            this.btnReject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(118, 28);
            this.btnReject.TabIndex = 5;
            this.btnReject.Text = "Disallow";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPublisher);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblSig);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblPlugin);
            this.groupBox1.Controls.Add(this.lblNotice);
            this.groupBox1.Location = new System.Drawing.Point(2, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(294, 139);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plug-in Security Overview";
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublisher.Location = new System.Drawing.Point(88, 65);
            this.lblPublisher.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(93, 16);
            this.lblPublisher.TabIndex = 16;
            this.lblPublisher.Text = "PUBLISHER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Publisher:";
            // 
            // lblSig
            // 
            this.lblSig.AutoSize = true;
            this.lblSig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSig.Location = new System.Drawing.Point(88, 42);
            this.lblSig.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSig.Name = "lblSig";
            this.lblSig.Size = new System.Drawing.Size(176, 16);
            this.lblSig.TabIndex = 14;
            this.lblSig.Text = "SIGNATURE_PRESENT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Signature:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Name:";
            // 
            // lblPlugin
            // 
            this.lblPlugin.AutoSize = true;
            this.lblPlugin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlugin.Location = new System.Drawing.Point(88, 19);
            this.lblPlugin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlugin.Name = "lblPlugin";
            this.lblPlugin.Size = new System.Drawing.Size(63, 16);
            this.lblPlugin.TabIndex = 11;
            this.lblPlugin.Text = "PLUGIN";
            // 
            // lblNotice
            // 
            this.lblNotice.Location = new System.Drawing.Point(4, 91);
            this.lblNotice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(285, 41);
            this.lblNotice.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(318, 41);
            this.label5.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(345, 1);
            this.label6.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::GlobalCommand.Properties.Resources.security;
            this.pictureBox1.Location = new System.Drawing.Point(10, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ErrorImage = global::GlobalCommand.Properties.Resources.globe_256x256;
            this.pictureBox2.Image = global::GlobalCommand.Properties.Resources.globe_256x256;
            this.pictureBox2.Location = new System.Drawing.Point(266, 5);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // frmPluginSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 219);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnAllowAlways);
            this.Controls.Add(this.btnAllowOnce);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmPluginSecurity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plugin Security Warning";
            this.Load += new System.EventHandler(this.frmPluginSecurity_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAllowOnce;
        private System.Windows.Forms.Button btnAllowAlways;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPlugin;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.Label label2;
    }
}