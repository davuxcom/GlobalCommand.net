using System;
using System.Drawing;
using System.Windows.Forms;



namespace GlobalCommand
{
    public partial class frmPluginSecurity : Form
    {
        public frmPluginSecurity()
        {
            InitializeComponent();
        }

        public void setPlugin(Plugin p)
        {
            lblPlugin.Text = p.FileName;
            lblPublisher.Text = p.Publisher;

            if (p.Signature == Plugin.vSignature.Persent)
            {
                lblSig.Text = "Unrecognized Signature";
                lblSig.ForeColor = Color.YellowGreen;
            }
            else
            {
                lblSig.Text = "Unsigned Module";
                lblSig.ForeColor = Color.Red;
            }
        }


        private void btnReject_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnAllowAlways_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnAllowOnce_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmPluginSecurity_Load(object sender, EventArgs e)
        {
            /*
            Graphics graphics;
            graphics = this.CreateGraphics();

            if (graphics.DpiY > 96)
            {
                this.Height += 29;
            }

            graphics.Dispose(); 
            */
           

            lblNotice.Text = "You are trying to load a plugin that has not been signed " +
                "by the author of GlobalCommand.  Activating this plug-in could cause harm " +
                "to your computer.";

        }
    }
}
