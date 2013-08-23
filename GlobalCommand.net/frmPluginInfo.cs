using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;


namespace GlobalCommand
{
    public partial class frmPluginInfo : Form
    {
        Plugin p = null;

        public frmPluginInfo()
        {
            InitializeComponent();
        }

        private void frmPluginInfo_Load(object sender, EventArgs e)
        {
            Graphics graphics;
            graphics = this.CreateGraphics();

            if (graphics.DpiY > 96)
            {
                this.Height += 36;
            }
            graphics.Dispose(); 
        }

        public void setPlugin(Plugin plugin)
        {
            p = plugin;

            lblAuthor.Text = plugin.Author;
            lblDesc.Text = plugin.Description;
            lblName.Text = plugin.FriendlyName;
            lblVersion.Text = plugin.Version;
            lblPublisher.Text = plugin.Publisher;

            switch (p.Signature)
            {
                case Plugin.vSignature.Persent:
                    lblSig.Text = "Signature Present";
                    lblSig.ForeColor = Color.YellowGreen;
                    break;
                case Plugin.vSignature.NotPresent:
                    lblSig.Text = "Signature Not Present";
                    lblSig.ForeColor = Color.Red;
                    break;
                case Plugin.vSignature.Verified:
                    lblSig.Text = "Signature Verified";
                    lblSig.ForeColor = Color.Green;
                    btnBlock.Visible = false;
                    break;
            }

            if(p.AlwaysAllowed) {
                btnBlock.Text = "&Remove From Allow List";
            }
            else
            {
                btnBlock.Text = "&Add to Allow List";
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            btnBlock.Enabled = false;

            p.AlwaysAllowed = !p.AlwaysAllowed;
        }
    }
}
