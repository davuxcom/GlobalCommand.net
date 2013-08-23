using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using GCPluginFramework;


namespace GlobalCommand
{
    public partial class frmCommand : Form
    {
        private Command currentCommand = null;

        public void setCommand(Command cmd){
            currentCommand = cmd;

            this.txtPrint.Text = "";
            this.txtActionCommand.Text = "";
            this.txtACtionEnd.Text = "";
            this.chkBackspace.Checked = true;

            cCtrl.Checked = false;
            cShift.Checked = false;
            cWin.Checked = false;
            cAlt.Checked = false;
            txtHotkey.Text = "";


            if (currentCommand != null)
            {

                this.txtPrint.Text = currentCommand.PrintString;
                this.txtActionCommand.Text = currentCommand.ActionString;
                this.txtACtionEnd.Text = currentCommand.ActionEndString;
                this.chkBackspace.Checked = currentCommand.Backspace;



                if (currentCommand.hkey != null)
                {
                    rSelectHotKey.Checked = true;
                    int m = currentCommand.hkey.TheHotKey.modifiers;
                    txtHotkey.Text = currentCommand.hkey.TheHotKey.key.ToString();

                    if (m >= 8)
                    {
                        cWin.Checked = true;
                        m -= 8;
                    }
                    if (m >= 4)
                    {
                        cShift.Checked = true;
                        m -= 4;
                    }
                    if (m >= 2)
                    {
                        cCtrl.Checked = true;
                        m -= 2;
                    }
                    if (m == 1)
                    {
                        cAlt.Checked = true;
                    }
                    rSelectHotKey.Checked = true;
                    rSelectHotKey_CheckedChanged(null, null);
                }
                else
                {
                    rUseString.Checked = true;
                    rUseString_CheckedChanged(null, null);

                }
            }
            else
            {
                rUseString.Checked = true;
                rUseString_CheckedChanged(null, null);
            }

            this.tmrPreviewUpdate.Interval = 1000;
            this.tmrPreviewUpdate.Enabled = true;
            tmrPreviewUpdate_Tick(null, null);
        }

        public void setMenu(ContextMenu m) 
        {
            btnInsert.ContextMenu = m;
        }

        public frmCommand()
        {
            InitializeComponent();
        }

        public void Menu_Click(object sender, EventArgs e)
        {
            MenuItem it = (MenuItem)sender;
            this.txtPrint.Paste(it.Text);
        }

        // method needs to be fixed to show more pleasent help dialog. (FIXME)
        public void Menu_Help_Click(object sender, EventArgs e)
        {
            // FIXME help.cs

            MenuItem it = (MenuItem)sender;
            gcCommand[] cmds = (gcCommand[])it.Tag;

            if(cmds.Length != 0 ) {

                frmWb w = new frmWb();

                string str = "";

                str += "<font face=\"arial\">";
                str += "<style type=\"text/css\">table { border-color: #600; border-width: 0 0 1px 1px;" +
                    "   border-style: solid;"+ 
                     "}"+ "td" +
                    "{ border-width: 1px 1px 0 0;border-style: solid; padding: 4px;}";
                str += "</style>";

                str += "<table>";

                str += "<tr><td>Name</td><td>Description</td><td>Comments</td></tr>";

                for (int i = 0; i < cmds.Length; i++)
                {
                    str += "<tr>";
                    str += "<td>" + cmds[i].CommandKey + "</td>";
                    str += "<td>" + cmds[i].Description  + "</td>";

                        str += "<td>&nbsp;</td>";
  
                    
                    str += "</tr>";
                }
                str += "</table>";
                w.wb.Navigate("about:blank");
                w.wb.Document.Write(str);
                w.Show();
            } else {
                MessageBox.Show("No help for this cmd");
            }
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            btnInsert.ContextMenu.Show(btnInsert, new Point(0, 0));
        }

        private void tmrPreviewUpdate_Tick(object sender, EventArgs e)
        {
            int tk = Environment.TickCount;
            WriteWB(KeyFunctions.getPreviewString(txtPrint.Text, ""));

            if (Environment.TickCount - tk > 500)
            {
                WriteWB("Preview is disabled due to timeout (Greater than 100ms execution time)");
                tmrPreviewUpdate.Enabled = false;
            }
        }

        private void WriteWB(String str)
        {
            this.wbPreview.DocumentText = "<body bgcolor=\"#" + this.BackColor.R.ToString("X") + this.BackColor.G.ToString("X") + this.BackColor.B.ToString("X") + "\"><font face=\"arial\" size=\"1\">" + str;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Command cmd = new Command();

            if (rSelectHotKey.Checked)
            {
                if (txtHotkey.Text.Trim() != "")
                {
                    Keys k;
                    try
                    {
                        if (txtHotkey.Text.Length > 1)
                        {
                            k = (Keys)Keys.Parse(typeof(Keys), txtHotkey.Text.Trim());
                        }
                        else
                        {
                            k = (Keys)Keys.Parse(typeof(Keys), txtHotkey.Text.Trim().ToUpper());
                        }
                    } catch(Exception ex)  {
                        MessageBox.Show("Invalid key: " + ex.Message);
                        return;
                    }


                    if (cWin.Checked && (cCtrl.Checked || cAlt.Checked || cShift.Checked))
                    {
                        MessageBox.Show("You cannot use the 'Windows Key' modifier with any other modifier key", "Error");
                        return;
                    }
                    else
                    {
                        int mods = 0;
                        if(cCtrl.Checked) {
                            mods += HotKey.MOD_CONTROL;
                        }
                        if(cAlt.Checked) {
                            mods += HotKey.MOD_ALT;
                        }
                        if(cShift.Checked) {
                            mods += HotKey.MOD_SHIFT;
                        }
                        if(cWin.Checked) {
                            mods = HotKey.MOD_WIN;
                        }

                        // check exists
                        string s = HotKey.ToString(k, mods);
                        foreach (Command c in Command.Commands)
                        {
                            if (c.hkey != null && c != currentCommand)
                            {
                                if (c.hkey.ToString() == s)
                                {
                                    MessageBox.Show("This HotKey is already being used, select a different one.", "Error");
                                    return;
                                }
                            }
                        }

                        // if the hotkey already exists, we can't register it.
                        // delete the old hotkey now.

                        if (currentCommand != null)
                        {
                            if (currentCommand.hkey != null)
                            {
                                currentCommand.hkey.UnRegister();
                            }
                        }

                        cmd.hkey = new HotKey(new KeyPair(k, mods));
                        cmd.PrintString = txtPrint.Text + "";
                        cmd.ActionString = txtActionCommand.Text + "";
                    }
                } // else no key
            }
            else
            {
                if (txtActionCommand.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Yout must have a key sequence string that will activate this command.","Error");
                    return;
                }

                cmd.ActionString = txtActionCommand.Text;
                cmd.Backspace = chkBackspace.Checked;
                cmd.PrintString = txtPrint.Text;
                cmd.ActionEndString = txtACtionEnd.Text;
            }

            if (cmd.ActionString != "")
            {
                foreach (Command c in Command.Commands)
                {
                    if (c.ActionString.Trim().ToLower() == cmd.ActionString.Trim().ToLower() && c != currentCommand)
                    {
                        MessageBox.Show("This command is already being used.", "Error");
                        return;

                    }
                }
            }


            Command.Commands.Remove(currentCommand);
            Command.Commands.Add(cmd);

            this.tmrPreviewUpdate.Enabled = false;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.tmrPreviewUpdate.Enabled = false;
            this.Close();
        }

        private void frmCommand_Load(object sender, EventArgs e)
        {
            txtPrint.ScrollBars = ScrollBars.Vertical;
            wbPreview.ScrollBarsEnabled = false ;
            Application.DoEvents();

            Graphics graphics;
            graphics = this.CreateGraphics();
            if (graphics.DpiY > 96)
            {
                this.Height += 3;
            }
            graphics.Dispose(); 
        }

        private void rSelectHotKey_CheckedChanged(object sender, EventArgs e)
        {
            if (rSelectHotKey.Checked)
            {
                txtActionCommand.Enabled = false;
                txtACtionEnd.Enabled = false;
                chkBackspace.Enabled = false;

                txtHotkey.Enabled = true;
                cCtrl.Enabled = true;
                cAlt.Enabled = true;
                cShift.Enabled = true;
                cWin.Enabled = true;
            }
        }

        private void rUseString_CheckedChanged(object sender, EventArgs e)
        {
            if (rUseString.Checked)
            {
                txtActionCommand.Enabled = true;
                txtACtionEnd.Enabled = true;
                chkBackspace.Enabled = true;

                txtHotkey.Enabled = false;
                cCtrl.Enabled = false;
                cAlt.Enabled = false;
                cShift.Enabled = false;
                cWin.Enabled = false;
            }
        }

        private void cWin_CheckedChanged(object sender, EventArgs e)
        {
            cCtrl.Checked = false;
            cShift.Checked = false;
            cAlt.Checked = false;

            cCtrl.Enabled = !cWin.Checked;
            cShift.Enabled = !cWin.Checked;
            cAlt.Enabled = !cWin.Checked;
        }


    }
}
