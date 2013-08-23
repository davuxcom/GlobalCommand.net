using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GlobalCommand;

namespace PluginDebugger
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            

            Global.SuppressErrors = true;
           Plugin[] temp_plugins = Plugin.Load();
           Global.SuppressErrors = false;

            foreach (Plugin p in temp_plugins)
            {


                Plugin.vActivationState state = p.Activate();

                switch (state)
                {
                    case Plugin.vActivationState.Activated:
                        // ok
                        Plugin.Plugins.Add(p);
                        break;
                    case Plugin.vActivationState.Error:
                        MessageBox.Show("Could not activate plugin: " + p.FriendlyName + "\n\nReason: See Error log", "Error");
                        break;
                    case Plugin.vActivationState.NameConflict:
                        MessageBox.Show("Could not activate plugin: " + p.FriendlyName + "\n\nReason: Name Conflict", "Error");
                        break;

                    default:
                        break;
                }



            }

            foreach (Plugin plug in Plugin.Plugins)
            {
                cboPlugins.Items.Add(plug);
            }

            cboPlugins_SelectedIndexChanged(null, null);
            
        }

        private void cboPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            Plugin p = (Plugin)cboPlugins.SelectedItem;

            if (p != null)
            {
                lblName.Text = p.FriendlyName;
                lblPublisher.Text = p.Publisher;
                lblDesc.Text = p.Description;

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

                        break;
                }

                lblAuthor.Text = p.Author;
                lblVersion.Text = p.Version;
                cboCommand.Items.Clear();

                if (p.getCommands() != null)
                {
                    foreach (GCPluginFramework.gcCommand cmd in p.getCommands())
                    {
                        cboCommand.Items.Add(cmd.CommandKey);
                    }
                }

            }
            else
            {
                lblName.Text = "No Plugin Selected";
                lblAuthor.Text = "-";
                lblSig.Text = "-";
                lblVersion.Text = "-";
                lblPublisher.Text = "-";

            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Plugin p = (Plugin)cboPlugins.SelectedItem;

            if (p != null)
            {
                txtOut.Text = p.ExecuteCommand(cboCommand.Text, txtAgs.Text);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Plugin p = (Plugin)cboPlugins.SelectedItem;

            if (p != null)
            {
                txtOut.Text = p.PreviewCommandOutput(cboCommand.Text, txtAgs.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Plugin p = (Plugin)cboPlugins.SelectedItem;

            if (p != null)
            {
                if (p.ShowConfigDialog() == false)
                {
                    MessageBox.Show("This plugin does not have a configuration dialog");
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Plugin.DisposeAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
