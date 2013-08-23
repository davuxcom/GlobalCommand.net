using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GlobalCommand
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Application.ProductVersion;
            

            Graphics graphics;
            graphics = this.CreateGraphics();

            if (graphics.DpiY > 96)
            {
                this.Height += 9;
            }

            graphics.Dispose(); 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:daveamenta@gmail.com");
        }
    }
}
