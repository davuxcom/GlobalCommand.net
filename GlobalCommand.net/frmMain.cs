using System;
using System.Windows.Forms;
using GCPluginFramework;


namespace GlobalCommand
{
    public partial class frmMain : Form
    {

        // -----------------------
        frmCommand CommandForm = new frmCommand();
        UserActivityHook ActivityHook = new UserActivityHook();
        delegate void VoidDelegate();
        // -----------------------

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            // here so we can make use of windowing.

            if (Security.SecurityKey == "")
            {
                MessageBox.Show("This application is not digitally signed.  Plase contact the author, this copy has been comprimized", "Fatal Error");
                Application.Exit();
                return;
            }

            if (! Log.Setup(Global.LogSaveFileName))
            {
                MessageBox.Show("Could not log to disk!");
            }

            NI.Icon = this.Icon;
            Global.mainForm = this;
            NI.ContextMenuStrip = NIMenu;

            lsvPlugins.Columns[0].Width = lsvPlugins.Width - 40;
            lsvCommands.Columns[0].Width = lsvCommands.Width - 40;

            ActivityHook.KeyPress += new KeyPressEventHandler(MyKeyPressed);

            Load_Commands();
            Load_Plugins();
        }

        private void Load_Commands()
        {
            if (Command.Commands == null)
            {
                Command.LoadState();
            }

            lsvCommands.Items.Clear();


            foreach (Command cmd in Command.Commands)
            {
                if (cmd != null)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = cmd.ToString();
                    li.Tag = cmd;
                    lsvCommands.Items.Add(li);
                }
            }
        }

        private void Load_Plugins()
        {
            ContextMenu PluginMenu = new ContextMenu();

            Plugin.LoadSate();

            Plugin[] temp_plugins = Plugin.Load();
            Plugin.Plugins.Add(new Plugin(new GCPlugin()));

            foreach (Plugin p in temp_plugins)
            {

                if (p.Signature != Plugin.vSignature.Verified)
                {
                    if (!p.AlwaysAllowed)
                    {

                        frmPluginSecurity f = new frmPluginSecurity();

                        f.setPlugin(p);

                        DialogResult d = f.ShowDialog(this);

                        switch (d)
                        {
                            case DialogResult.Abort:       // do not load asm
                                continue;
                            case DialogResult.OK:           // temp allow
                                //
                                break;
                            case DialogResult.Yes:          // always allow
                                p.AlwaysAllowed = true;
                                break;
                        }
                    }
                }

                Plugin.vActivationState state = p.Activate();

                switch (state)
                {
                    case Plugin.vActivationState.Activated:
                        // ok
                        Plugin.Plugins.Add(p);
                        break;
                    case Plugin.vActivationState.Error:
                        MessageBox.Show("Could not activate plugin: " + p.FriendlyName + "\n\nReason: See Error log","Error");
                        break;
                    case Plugin.vActivationState.NameConflict:
                        MessageBox.Show("Could not activate plugin: " + p.FriendlyName + "\n\nReason: Name Conflict","Error");
                        break;

                    default:
                        break;
                }
                
            }


            foreach(Plugin plugin in Plugin.Plugins)
            {
                if(plugin != null) 
                {

                    ListViewItem li = new ListViewItem();
                    li.Text = plugin.FriendlyName;
                    li.Tag = plugin;

                    if(plugin.getCommands() != null && plugin.getCommands().Length > 0) 
                    {
                        MenuItem PluginRootMenu = PluginMenu.MenuItems.Add(plugin.FriendlyName);

                        
                        

                        gcCommand[] cmds = plugin.getCommands();

                        if (cmds != null)
                        {
                            for (int k = 0; k < cmds.Length; k++)
                            {
                                PluginRootMenu.MenuItems.Add("[" + plugin.ShortName + "." + cmds[k].CommandKey + "]", new EventHandler(CommandForm.Menu_Click));
                            }

                            PluginRootMenu.MenuItems.Add("-");
                            MenuItem m = PluginRootMenu.MenuItems.Add("Show " + plugin.FriendlyName + " Help", new EventHandler(CommandForm.Menu_Help_Click));
                            m.Tag = cmds;
                        }
                    }

                    this.lsvPlugins.Items.Add(li);
                }
            }
            CommandForm.setMenu(PluginMenu);
        }

        public void MyKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (Global.KeysDisabled || e == null) { return; }

            if (e.KeyChar == 22) // Ctrl+V
            {
                KeyFunctions.PasteKey();
                return;
            }
            
            if (KeyFunctions.addKey(e.KeyChar.ToString()))
            {
                System.Threading.Thread t = new System.Threading.Thread(mySendKeys);
                t.Start();
            }
        }

        public void mySendKeys()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new VoidDelegate (mySendKeys));
            } 
            else 
            {
                try
                {
                    Global.KeysDisabled = true;
                    if (KeyFunctions.numToBackspace > 0)
                    {
                        SendKeys.Send(KeyFunctions.GetBackspaces());
                    }
                    SendKeys.Flush();

                    string o = KeyFunctions.getOutputString();
                    if (o != null && o != "")
                    {
                        SendKeys.Send(o);
                    }
                    Global.KeysDisabled = false;
                }
                catch (Exception e)
                {
                    Log.WriteLine("[WA] SendKeys Exception: " + e.Message + "\n\n" + e.StackTrace);
                }
            }
        }

        private void btnViewPlugin_Click(object sender, EventArgs e)
        {
            if (lsvPlugins.SelectedItems.Count == 0) { return; }

            Plugin p = (Plugin)lsvPlugins.SelectedItems[0].Tag;

            if (p != null)
            {
                frmPluginInfo f = new frmPluginInfo();
                f.setPlugin(p);
                f.ShowDialog(this);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Global.Closing)
            {
                e.Cancel = true;
            }
            this.Hide();
            Application.DoEvents();

            Plugin.SaveState();
            Command.SaveState();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lsvCommands.SelectedItems.Count > 0 && lsvCommands.SelectedItems[0].Tag  != null)
            {
                try
                {
                    Command.Commands.Remove((Command)lsvCommands.SelectedItems[0].Tag);
                    Load_Commands();
                }
                catch (Exception)
                {
                    // should never be an error.
                }
            }
            else
            {
                MessageBox.Show("You must select a cmmand to delete.");
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            CommandForm.setCommand(null);
            Global.KeysDisabled = true;
            CommandForm.ShowDialog(this);
            Global.KeysDisabled = false;
            this.Show();
            Load_Commands();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(lsvCommands.SelectedItems.Count > 0 ) {

                Command cmd = (Command)lsvCommands.SelectedItems[0].Tag;
                if(cmd != null) {
                    CommandForm.setCommand( cmd );
                    Global.KeysDisabled = true;
                    CommandForm.ShowDialog(this);
                    Global.KeysDisabled = false;
                }
            }
            this.Show();
            Load_Commands();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.Closing = true;
            Plugin.DisposeAll();
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.Show();
            this.Hide();
        }

        private void showConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void NIMenu_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (lsvPlugins.SelectedItems.Count == 0) { return; }

            Plugin p = (Plugin)lsvPlugins.SelectedItems[0].Tag;

            if (p != null)
            {
                if(p.ShowConfigDialog() == false) {
                    MessageBox.Show("This plugin does not have a configuration dialog","Information");
                }
            }
        }

        private void NI_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}

