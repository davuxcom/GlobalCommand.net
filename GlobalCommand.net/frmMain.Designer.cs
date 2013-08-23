namespace GlobalCommand
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lsvCommands = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnViewPlugin = new System.Windows.Forms.Button();
            this.lsvPlugins = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.NI = new System.Windows.Forms.NotifyIcon(this.components);
            this.NIMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.NIMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.lsvCommands);
            this.groupBox1.Location = new System.Drawing.Point(0, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 343);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commands:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(224, 302);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 35);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(120, 302);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 35);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "View/Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(10, 302);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(84, 35);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click_1);
            // 
            // lsvCommands
            // 
            this.lsvCommands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lsvCommands.FullRowSelect = true;
            this.lsvCommands.GridLines = true;
            this.lsvCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvCommands.Location = new System.Drawing.Point(10, 21);
            this.lsvCommands.MultiSelect = false;
            this.lsvCommands.Name = "lsvCommands";
            this.lsvCommands.Size = new System.Drawing.Size(298, 275);
            this.lsvCommands.TabIndex = 0;
            this.lsvCommands.UseCompatibleStateImageBehavior = false;
            this.lsvCommands.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Action String";
            this.columnHeader2.Width = 213;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSettings);
            this.groupBox2.Controls.Add(this.btnViewPlugin);
            this.groupBox2.Controls.Add(this.lsvPlugins);
            this.groupBox2.Location = new System.Drawing.Point(320, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 343);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plug-Ins:";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(166, 302);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(126, 35);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "View &Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnViewPlugin
            // 
            this.btnViewPlugin.Location = new System.Drawing.Point(21, 302);
            this.btnViewPlugin.Name = "btnViewPlugin";
            this.btnViewPlugin.Size = new System.Drawing.Size(129, 35);
            this.btnViewPlugin.TabIndex = 2;
            this.btnViewPlugin.Text = "&View Details";
            this.btnViewPlugin.UseVisualStyleBackColor = true;
            this.btnViewPlugin.Click += new System.EventHandler(this.btnViewPlugin_Click);
            // 
            // lsvPlugins
            // 
            this.lsvPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.lsvPlugins.FullRowSelect = true;
            this.lsvPlugins.GridLines = true;
            this.lsvPlugins.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvPlugins.Location = new System.Drawing.Point(10, 21);
            this.lsvPlugins.MultiSelect = false;
            this.lsvPlugins.Name = "lsvPlugins";
            this.lsvPlugins.Size = new System.Drawing.Size(298, 275);
            this.lsvPlugins.TabIndex = 0;
            this.lsvPlugins.UseCompatibleStateImageBehavior = false;
            this.lsvPlugins.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 213;
            // 
            // NI
            // 
            this.NI.Text = "GlobalCommand 3 - by David Amenta";
            this.NI.Visible = true;
            this.NI.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NI_MouseDoubleClick);
            // 
            // NIMenu
            // 
            this.NIMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.showConfigurationToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.NIMenu.Name = "NIMenu";
            this.NIMenu.Size = new System.Drawing.Size(210, 82);
            this.NIMenu.DoubleClick += new System.EventHandler(this.NIMenu_DoubleClick);
            this.NIMenu.Click += new System.EventHandler(this.NIMenu_DoubleClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // showConfigurationToolStripMenuItem
            // 
            this.showConfigurationToolStripMenuItem.Name = "showConfigurationToolStripMenuItem";
            this.showConfigurationToolStripMenuItem.Size = new System.Drawing.Size(209, 24);
            this.showConfigurationToolStripMenuItem.Text = "Show Configuration";
            this.showConfigurationToolStripMenuItem.Click += new System.EventHandler(this.showConfigurationToolStripMenuItem_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.White;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(10, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(169, 29);
            this.lblHeader.TabIndex = 13;
            this.lblHeader.Text = "Control Center";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(666, 50);
            this.label5.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(-3, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(760, 1);
            this.label6.TabIndex = 15;
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(206, 6);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = global::GlobalCommand.Properties.Resources.globe_256x256;
            this.pictureBox1.Image = global::GlobalCommand.Properties.Resources.globe_256x256;
            this.pictureBox1.Location = new System.Drawing.Point(591, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 406);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GlobalCommand 3 Configuration";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.NIMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lsvCommands;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnViewPlugin;
        private System.Windows.Forms.ListView lsvPlugins;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.NotifyIcon NI;
        private System.Windows.Forms.ContextMenuStrip NIMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showConfigurationToolStripMenuItem;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;


    }
}