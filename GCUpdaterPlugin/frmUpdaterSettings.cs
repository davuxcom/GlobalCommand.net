using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;


namespace GCUpdaterPlugin
{
    public partial class frmUpdaterSettings : Form
    {
        public frmUpdaterSettings()
        {
            InitializeComponent();
        }

        private bool SaveStrings()
        {

            try
            {
                Uri u = new Uri(txtRepo.Text);
            }
            catch (Exception)
            {
                return false;
            }
            Settings.Strings[0] = txtRepo.Text;
            Settings.Strings[1] = cDisplayAll.Checked.ToString();
            Settings.Strings[2] = rAutoUpdateEnabled.Checked.ToString();
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            if (SaveStrings())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Error in repository URL format", "Error");
            }

            
        }

        private void btnUpdateNow_Click(object sender, EventArgs e)
        {

            if (SaveStrings())
            {
                frmUpdating f = new frmUpdating();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error in repository URL format", "Error");
            }


        }

        private void frmUpdaterSettings_Load(object sender, EventArgs e)
        {

            try {

                txtRepo.Text = Settings.Strings[0];
                cDisplayAll.Checked = bool.Parse(Settings.Strings[1]);
                rAutoUpdateEnabled.Checked = bool.Parse(Settings.Strings[2]);
            }
            catch (Exception)
            {

                // 
            }
        }
    }
}
