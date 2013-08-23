namespace GlobalCommand
{
    partial class frmCommand
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
            this.components = new System.ComponentModel.Container();
            this.wbPreview = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtACtionEnd = new System.Windows.Forms.TextBox();
            this.chkBackspace = new System.Windows.Forms.CheckBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtPrint = new System.Windows.Forms.TextBox();
            this.txtActionCommand = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tmrPreviewUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblHeader = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cShift = new System.Windows.Forms.CheckBox();
            this.cWin = new System.Windows.Forms.CheckBox();
            this.cAlt = new System.Windows.Forms.CheckBox();
            this.cCtrl = new System.Windows.Forms.CheckBox();
            this.rUseString = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHotkey = new System.Windows.Forms.TextBox();
            this.rSelectHotKey = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbPreview
            // 
            this.wbPreview.Location = new System.Drawing.Point(12, 355);
            this.wbPreview.Margin = new System.Windows.Forms.Padding(2);
            this.wbPreview.MinimumSize = new System.Drawing.Size(15, 16);
            this.wbPreview.Name = "wbPreview";
            this.wbPreview.ScriptErrorsSuppressed = true;
            this.wbPreview.ScrollBarsEnabled = false;
            this.wbPreview.Size = new System.Drawing.Size(311, 42);
            this.wbPreview.TabIndex = 13;
            this.wbPreview.WebBrowserShortcutsEnabled = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 209);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Enter the commands that you wish to execute when the action keys or hotkeys are p" +
                "ressed.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Key Sequence:";
            // 
            // txtACtionEnd
            // 
            this.txtACtionEnd.Location = new System.Drawing.Point(205, 107);
            this.txtACtionEnd.Margin = new System.Windows.Forms.Padding(2);
            this.txtACtionEnd.MaxLength = 1;
            this.txtACtionEnd.Name = "txtACtionEnd";
            this.txtACtionEnd.Size = new System.Drawing.Size(20, 20);
            this.txtACtionEnd.TabIndex = 6;
            // 
            // chkBackspace
            // 
            this.chkBackspace.AutoSize = true;
            this.chkBackspace.Checked = true;
            this.chkBackspace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBackspace.Location = new System.Drawing.Point(47, 132);
            this.chkBackspace.Margin = new System.Windows.Forms.Padding(2);
            this.chkBackspace.Name = "chkBackspace";
            this.chkBackspace.Size = new System.Drawing.Size(270, 17);
            this.chkBackspace.TabIndex = 5;
            this.chkBackspace.Text = "Clear (Backspace) the command before processing.";
            this.chkBackspace.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(14, 312);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(68, 22);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "Insert...";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtPrint
            // 
            this.txtPrint.Location = new System.Drawing.Point(11, 242);
            this.txtPrint.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrint.Multiline = true;
            this.txtPrint.Name = "txtPrint";
            this.txtPrint.Size = new System.Drawing.Size(311, 71);
            this.txtPrint.TabIndex = 3;
            // 
            // txtActionCommand
            // 
            this.txtActionCommand.Location = new System.Drawing.Point(205, 85);
            this.txtActionCommand.Margin = new System.Windows.Forms.Padding(2);
            this.txtActionCommand.MaxLength = 16;
            this.txtActionCommand.Name = "txtActionCommand";
            this.txtActionCommand.Size = new System.Drawing.Size(104, 20);
            this.txtActionCommand.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(219, 401);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 31);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(101, 401);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tmrPreviewUpdate
            // 
            this.tmrPreviewUpdate.Tick += new System.EventHandler(this.tmrPreviewUpdate_Tick);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.White;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(10, 10);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(138, 24);
            this.lblHeader.TabIndex = 10;
            this.lblHeader.Text = "Add Command";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(394, 41);
            this.label5.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(420, 1);
            this.label6.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = global::GlobalCommand.Properties.Resources.globe_256x256;
            this.pictureBox1.Image = global::GlobalCommand.Properties.Resources.globe_256x256;
            this.pictureBox1.Location = new System.Drawing.Point(288, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cShift);
            this.groupBox2.Controls.Add(this.cWin);
            this.groupBox2.Controls.Add(this.cAlt);
            this.groupBox2.Controls.Add(this.cCtrl);
            this.groupBox2.Controls.Add(this.rUseString);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtHotkey);
            this.groupBox2.Controls.Add(this.rSelectHotKey);
            this.groupBox2.Controls.Add(this.txtActionCommand);
            this.groupBox2.Controls.Add(this.chkBackspace);
            this.groupBox2.Controls.Add(this.txtACtionEnd);
            this.groupBox2.Location = new System.Drawing.Point(3, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 160);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Command Actuation Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "End Signal (For arguments):";
            // 
            // cShift
            // 
            this.cShift.AutoSize = true;
            this.cShift.Location = new System.Drawing.Point(225, 42);
            this.cShift.Margin = new System.Windows.Forms.Padding(2);
            this.cShift.Name = "cShift";
            this.cShift.Size = new System.Drawing.Size(47, 17);
            this.cShift.TabIndex = 25;
            this.cShift.Text = "Shift";
            this.cShift.UseVisualStyleBackColor = true;
            // 
            // cWin
            // 
            this.cWin.AutoSize = true;
            this.cWin.Location = new System.Drawing.Point(274, 42);
            this.cWin.Margin = new System.Windows.Forms.Padding(2);
            this.cWin.Name = "cWin";
            this.cWin.Size = new System.Drawing.Size(45, 17);
            this.cWin.TabIndex = 24;
            this.cWin.Text = "Win";
            this.cWin.UseVisualStyleBackColor = true;
            this.cWin.CheckedChanged += new System.EventHandler(this.cWin_CheckedChanged);
            // 
            // cAlt
            // 
            this.cAlt.AutoSize = true;
            this.cAlt.Location = new System.Drawing.Point(187, 42);
            this.cAlt.Margin = new System.Windows.Forms.Padding(2);
            this.cAlt.Name = "cAlt";
            this.cAlt.Size = new System.Drawing.Size(38, 17);
            this.cAlt.TabIndex = 23;
            this.cAlt.Text = "Alt";
            this.cAlt.UseVisualStyleBackColor = true;
            // 
            // cCtrl
            // 
            this.cCtrl.AutoSize = true;
            this.cCtrl.Location = new System.Drawing.Point(145, 42);
            this.cCtrl.Margin = new System.Windows.Forms.Padding(2);
            this.cCtrl.Name = "cCtrl";
            this.cCtrl.Size = new System.Drawing.Size(41, 17);
            this.cCtrl.TabIndex = 22;
            this.cCtrl.Text = "Ctrl";
            this.cCtrl.UseVisualStyleBackColor = true;
            // 
            // rUseString
            // 
            this.rUseString.AutoSize = true;
            this.rUseString.Checked = true;
            this.rUseString.Location = new System.Drawing.Point(10, 64);
            this.rUseString.Margin = new System.Windows.Forms.Padding(2);
            this.rUseString.Name = "rUseString";
            this.rUseString.Size = new System.Drawing.Size(231, 17);
            this.rUseString.TabIndex = 21;
            this.rUseString.TabStop = true;
            this.rUseString.Text = "Use a typed string to activate this command";
            this.rUseString.UseVisualStyleBackColor = true;
            this.rUseString.CheckedChanged += new System.EventHandler(this.rUseString_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Hotkey:";
            // 
            // txtHotkey
            // 
            this.txtHotkey.Location = new System.Drawing.Point(98, 40);
            this.txtHotkey.Margin = new System.Windows.Forms.Padding(2);
            this.txtHotkey.MaxLength = 65565;
            this.txtHotkey.Name = "txtHotkey";
            this.txtHotkey.Size = new System.Drawing.Size(42, 20);
            this.txtHotkey.TabIndex = 19;
            // 
            // rSelectHotKey
            // 
            this.rSelectHotKey.AutoSize = true;
            this.rSelectHotKey.Location = new System.Drawing.Point(10, 18);
            this.rSelectHotKey.Margin = new System.Windows.Forms.Padding(2);
            this.rSelectHotKey.Name = "rSelectHotKey";
            this.rSelectHotKey.Size = new System.Drawing.Size(209, 17);
            this.rSelectHotKey.TabIndex = 18;
            this.rSelectHotKey.Text = "Use a hotkey to activate this command";
            this.rSelectHotKey.UseVisualStyleBackColor = true;
            this.rSelectHotKey.CheckedChanged += new System.EventHandler(this.rSelectHotKey_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 338);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Preview of text that will be sent when the command is activated:";
            // 
            // frmCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 435);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.wbPreview);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPrint);
            this.Controls.Add(this.btnInsert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCommand";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Command Window";
            this.Load += new System.EventHandler(this.frmCommand_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrint;
        private System.Windows.Forms.TextBox txtActionCommand;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.CheckBox chkBackspace;
        private System.Windows.Forms.Timer tmrPreviewUpdate;
        private System.Windows.Forms.TextBox txtACtionEnd;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.WebBrowser wbPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cShift;
        private System.Windows.Forms.CheckBox cWin;
        private System.Windows.Forms.CheckBox cAlt;
        private System.Windows.Forms.CheckBox cCtrl;
        private System.Windows.Forms.RadioButton rUseString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHotkey;
        private System.Windows.Forms.RadioButton rSelectHotKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
    }
}