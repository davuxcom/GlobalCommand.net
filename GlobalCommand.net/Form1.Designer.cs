

/*
namespace GlobalCommand.net
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lstCommands = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnViewInfo = new System.Windows.Forms.Button();
            this.lstPlugins = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPreviewPrint = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.chkBackspace = new System.Windows.Forms.CheckBox();
            this.txtPrint = new System.Windows.Forms.TextBox();
            this.txtActionStr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.lstCommands);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(181, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commands";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(120, 141);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(52, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(68, 141);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(43, 28);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(14, 141);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(44, 28);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lstCommands
            // 
            this.lstCommands.FormattingEnabled = true;
            this.lstCommands.Location = new System.Drawing.Point(4, 17);
            this.lstCommands.Margin = new System.Windows.Forms.Padding(2);
            this.lstCommands.Name = "lstCommands";
            this.lstCommands.Size = new System.Drawing.Size(173, 121);
            this.lstCommands.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewInfo);
            this.groupBox2.Controls.Add(this.lstPlugins);
            this.groupBox2.Location = new System.Drawing.Point(219, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(180, 176);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plug-Ins Loaded";
            // 
            // btnViewInfo
            // 
            this.btnViewInfo.Location = new System.Drawing.Point(14, 141);
            this.btnViewInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewInfo.Name = "btnViewInfo";
            this.btnViewInfo.Size = new System.Drawing.Size(149, 28);
            this.btnViewInfo.TabIndex = 1;
            this.btnViewInfo.Text = "View Module Information";
            this.btnViewInfo.UseVisualStyleBackColor = true;
            this.btnViewInfo.Click += new System.EventHandler(this.btnViewInfo_Click);
            // 
            // lstPlugins
            // 
            this.lstPlugins.FormattingEnabled = true;
            this.lstPlugins.Location = new System.Drawing.Point(4, 17);
            this.lstPlugins.Margin = new System.Windows.Forms.Padding(2);
            this.lstPlugins.Name = "lstPlugins";
            this.lstPlugins.Size = new System.Drawing.Size(172, 121);
            this.lstPlugins.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnPreviewPrint);
            this.groupBox3.Controls.Add(this.btnInsert);
            this.groupBox3.Controls.Add(this.chkBackspace);
            this.groupBox3.Controls.Add(this.txtPrint);
            this.groupBox3.Controls.Add(this.txtActionStr);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(9, 190);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(390, 246);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Command";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter_1);
            // 
            // btnPreviewPrint
            // 
            this.btnPreviewPrint.Location = new System.Drawing.Point(275, 49);
            this.btnPreviewPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreviewPrint.Name = "btnPreviewPrint";
            this.btnPreviewPrint.Size = new System.Drawing.Size(53, 21);
            this.btnPreviewPrint.TabIndex = 9;
            this.btnPreviewPrint.Text = "Preview";
            this.btnPreviewPrint.UseVisualStyleBackColor = true;
            this.btnPreviewPrint.Click += new System.EventHandler(this.btnPreviewPrint_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(86, 48);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(53, 22);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "Insert...";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // chkBackspace
            // 
            this.chkBackspace.AutoSize = true;
            this.chkBackspace.Location = new System.Drawing.Point(288, 22);
            this.chkBackspace.Margin = new System.Windows.Forms.Padding(2);
            this.chkBackspace.Name = "chkBackspace";
            this.chkBackspace.Size = new System.Drawing.Size(104, 17);
            this.chkBackspace.TabIndex = 6;
            this.chkBackspace.Text = "Backspace Text";
            this.chkBackspace.UseVisualStyleBackColor = true;
            // 
            // txtPrint
            // 
            this.txtPrint.Location = new System.Drawing.Point(86, 74);
            this.txtPrint.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrint.Multiline = true;
            this.txtPrint.Name = "txtPrint";
            this.txtPrint.Size = new System.Drawing.Size(242, 168);
            this.txtPrint.TabIndex = 5;
            // 
            // txtActionStr
            // 
            this.txtActionStr.Location = new System.Drawing.Point(86, 20);
            this.txtActionStr.Margin = new System.Windows.Forms.Padding(2);
            this.txtActionStr.Name = "txtActionStr";
            this.txtActionStr.Size = new System.Drawing.Size(198, 20);
            this.txtActionStr.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key String";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(91, 441);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(224, 441);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Discard";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Action String:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 475);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "GlobalCommand.net";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstCommands;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstPlugins;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.CheckBox chkBackspace;
        private System.Windows.Forms.TextBox txtPrint;
        private System.Windows.Forms.TextBox txtActionStr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPreviewPrint;
        private System.Windows.Forms.Label label2;


    }
}

*/
