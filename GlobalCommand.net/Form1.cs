using System;
/*
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;



using Interfaces;

namespace GlobalCommand.net
{
    public partial class Form1 : Form
    {

        Commands c = new Commands();
        Command cur = null;

        UserActivityHook ua = new UserActivityHook();


        // for running sendkeys
        delegate void cmdRun();
        int cindex = 0;

        // window positions
        private int WINDOW_UP = 210;
        private int WINDOW_DOWN = 501;

        // key buffer
        string keybuffer = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Stream s = null;

            this.Height = WINDOW_UP;

            // install keyhook
            ua.KeyPress += new KeyPressEventHandler(MyKeyPressed);
            
            
            // open data file
            try
            {
                s = File.Open("gcdata.bin", FileMode.Open);
                BinaryFormatter b = new BinaryFormatter();
                c = (Commands)b.Deserialize(s);
                s.Close();
            }
            catch
            {
                try
                {
                    s.Close();
                }
                catch { }
                c = new Commands();
            }

            // load commands from data
            Load_Commands();

            // load plugins from folder
            PluginController.init();

            // setup menus for plugins
            ContextMenu PrintMenu = new ContextMenu();
            ContextMenu ActionMenu = new ContextMenu();

            for (int i = 0; i < PluginController.Plugins.Length; i++)
            {
                if (PluginController.Plugins[i] != null)
                {
                    IPlugin p = PluginController.Plugins[i];
                    

                    MenuItem eitem;

                    lstPlugins.Items.Add(p);

                    eitem = PrintMenu.MenuItems.Add(p.Name);

                    
                    PItem[] items = p.getItems();

                    for (int k = 0; k < items.Length; k++)
                    {
                        if (items[k].isAction)
                        {
                            eitem.MenuItems.Add("Action: [" + p.ID + "." + items[k].Name + "]", new EventHandler(EMenu_Click));
                        }
                        else
                        {
                            eitem.MenuItems.Add("[" + p.ID + "." + items[k].Name + "]", new EventHandler(EMenu_Click));
                        }
                    }
                }
            }
            btnInsert.ContextMenu = PrintMenu;
            //btnInsertExecString.ContextMenu = ActionMenu;
        }
        /*
        private void AMenu_Click(object sender, EventArgs e)
        {
            MenuItem it = (MenuItem)sender;
            txtExecuteStr.Paste(it.Text);
        }
         */
/*
        private void EMenu_Click(object sender, EventArgs e)
        {
            MenuItem it = (MenuItem)sender;
            txtPrint.Paste(it.Text);
        }

        public void MyKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (this.Height > WINDOW_UP )
            {
                // ignore keys when editing
                return;
            }

            keybuffer  += e.KeyChar.ToString();
            this.Text = keybuffer;

            // clear the buffer on enter, as well as when it gets long
            if (e.KeyChar == 13)
            {
                keybuffer = "";
            }
            if (keybuffer.Length > 25)
            {
                keybuffer = keybuffer.Substring(keybuffer.Length - 20);
            }

            for (int i = 0; i < c.length(); i++)
            {
                if (c.get(i) != null)
                {
                    if (keybuffer.IndexOf(c.get(i).ActionString,StringComparison.CurrentCultureIgnoreCase) > -1)
                    {
                        keybuffer = "";
                        if (c.get(i).Backspace)
                        {
                            string bs = "";
                            for (int k = 0; k < c.get(i).ActionString.Length-1; k++)
                            {
                                bs += "{BS}";
                            }
                            e.Handled = true;
                            SendKeys.Send(bs);
                        }
                        cindex = i;
                        System.Threading.Thread t = new System.Threading.Thread(RunCommand);
                        t.Start();
                       return;
                    }
                }
            }
        }

        private void RunCommand()
        {
            // ensure UI thread
            if (InvokeRequired)
            {
                BeginInvoke(new cmdRun(RunCommand));
            } else {
                //Execute(c.get(cindex).ExecuteString, false);
                string s = ParsePrintString(
                    c.get(cindex).PrintString, false).Trim();

                if (s.Trim().Length > 0)
                {
                    SendKeys.Send(s);
                }
            }
        }

        private void Load_Commands()
        {
            lstCommands.Items.Clear();

            for (int i = 0; i < c.length(); i++)
            {
                if(c.get(i) != null) {
                    lstCommands.Items.Add(c.get(i));
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtActionStr.Text = "";
            //txtExecuteStr.Text = "";
            txtPrint.Text = "";
            chkBackspace.Checked = false;
            this.Height = WINDOW_DOWN;
            cur = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstCommands.SelectedItem != null)
            {
                txtActionStr.Text = ((Command)lstCommands.SelectedItem).ActionString;
                //txtExecuteStr.Text = ((Command)lstCommands.SelectedItem).ExecuteString ;
                txtPrint.Text = ((Command)lstCommands.SelectedItem).PrintString ;
                chkBackspace.Checked = ((Command)lstCommands.SelectedItem).Backspace;
                cur = (Command)lstCommands.SelectedItem;
                this.Height = WINDOW_DOWN;
            }
            else
            {
                MessageBox.Show("You must select a command to edit");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCommands.SelectedItem != null)
            {
                c.Delete((Command)lstCommands.SelectedItem);
                Load_Commands();
            }
            else
            {
                MessageBox.Show("You must select a cmmand to edit");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cur = null;
            this.Height = WINDOW_UP;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Command cmd = new Command();

            cmd.ActionString = txtActionStr.Text;
            //cmd.ExecuteString = txtExecuteStr.Text;
            cmd.PrintString = txtPrint.Text;
            cmd.Backspace = chkBackspace.Checked;


            c.Delete(cur);
            c.Add(cmd);
            this.Height = WINDOW_UP;
            Load_Commands();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            c.Save();
            Application.Exit();
        }

        private void btnViewInfo_Click(object sender, EventArgs e)
        {

            IPlugin p = (IPlugin)lstPlugins.SelectedItem;

            if (p != null)
            {
                string s  = "Name: " + p.Name + "\n\n" +
                    "Author: " + p.Author + "\n\n" +
                    "Version: " + p.Version + "\n\n" +
                    "Description: " + p.Description;
                MessageBox.Show(s, "Plugin Information");
            }
        }



        private void btnInsert_Click(object sender, EventArgs e)
        {
            btnInsert.ContextMenu.Show(btnInsert, new Point(0,0));
        }



        private string Execute(string s, bool verify_only)
        {
            if (s.Trim().Length > 0)
            {
                System.Diagnostics.Process.Start(s);
            }
            return "";
        }

        private string KeySafeString(string s)
        {
            s = s.Replace("+", "-1567-PLUS-CONTROL");
            s = s.Replace("^", "-1567-CARROT-CONTROL");
            s = s.Replace("%", "-1567-PCT-CONTROL");
            s = s.Replace("(", "-1567-PAR-RIGHT");
            s = s.Replace(")", "-1567-PAR-LEFT");


            s = s.Replace("~", "+(`)");
            s = s.Replace("!", "+(1)");
            s = s.Replace("@", "+(2)");
            s = s.Replace("#", "+(3)");
            s = s.Replace("$", "+(4)");
            s = s.Replace("&", "+(7)");
            s = s.Replace("*", "+(8)");
            s = s.Replace("_", "+(-)");

            s = s.Replace("-1567-PLUS-CONTROL", "+(=)");
            s = s.Replace("-1567-CARROT-CONTROL", "+(6)");
            s = s.Replace("-1567-PCT-CONTROL", "+(5)");
            s = s.Replace("-1567-PAR-RIGHT", "+(9)");
            s = s.Replace("-1567-PAR-LEFT", "+(0)");

            return s;
        }

        private string ParsePrintString(string s, bool verify_only)
        {
            bool in_ID = false;
            bool in_Directive = false;
            bool in_Command = false;
            string outBuffer = "";
            string idBuffer = "";
            string cmdBuffer = "";

            s = KeySafeString(s);

            for(int i=0; i< s.Length; i++) {
                if(s[i] == '[') {
                    if( i > 0 ) {
                        // not the first char in the string
                        if( s[i-1]== '\\') {
                            // not a directive, remove the \ from the buffer, and continue
                            outBuffer = outBuffer.Substring(0,outBuffer.Length -1);
                            outBuffer += "[";
                        } else {
                            // we have a directive
                            in_Directive = true;
                            in_ID = true;
                        }
                    } else {
                        // first char
                        // we have a diretive



                        in_Directive = true;
                        in_ID = true;
                    }
                } else if( s[i] == '.') {
                    if (in_ID)
                    {
                        in_ID = false;
                        in_Command = true;
                    }
                    else if (in_Command)
                    {
                        cmdBuffer += ".";
                    }
                    else
                    {
                        outBuffer += ".";
                    }


                
                } else if (s[i]== ']') {
                    // end directive?

                    if(in_Directive ) {
                        in_Directive = false;
                        in_ID = false;
                        in_Command = false;

                        IPlugin found_plugin = null;

                        for (int k = 0; k < PluginController.Plugins.Length; k++)
                        {
                            if (PluginController.Plugins[k] != null)
                            {
                                IPlugin p = PluginController.Plugins[k];
                                if(p.ID.Trim().ToLower() == idBuffer.Trim().ToLower()) {

                                    found_plugin = p;
                                    // this is our plugin!

                                    // ignore this, allow ANY command.
                                    // this will allow more flexability, and easy things like shell()
                                    /*
                                    PItem[] items = p.getItems();
 
                                    for(int j = 0; j < items.Length; j++) {
                                        if(items[j].Name.Trim().ToLower() == cmdBuffer.Trim().ToLower()) {
                                            found_command = true;
                                            j = items.Length;
                                        }
                                    }
                                    */
/*
                                    k = PluginController.Plugins.Length;
                                }
                            }
                        }

                        if(found_plugin == null) {
                            if (cmdBuffer == "")
                            {
                                outBuffer += "[" + idBuffer + "]";
                            }
                            else
                            {
                                outBuffer += "[" + idBuffer + "." + cmdBuffer + "]";
                            }
                        }
                        /*
                        if(!found_command) {
                            outBuffer += "[" + idBuffer + "." + cmdBuffer + "]";
                        }
                        */
                        // safe!
/*
                        if( !verify_only && found_plugin != null  )  {

                            outBuffer += found_plugin.ExecuteItem(cmdBuffer);
                        }
                        cmdBuffer = "";
                        idBuffer = "";
                        in_Directive = false;
                        in_Command = false;
                        in_ID = false;

                    } else {
                        outBuffer += "]";
                    }
                    
                } else {
                    if(in_Directive) {
                        if(in_ID) {
                            idBuffer += s[i];
                        }
                        if(in_Command) {
                            cmdBuffer += s[i];
                        }
                    } else {
                        outBuffer += s[i];
                    }
                }
            }
            return outBuffer;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnPreviewPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ParsePrintString(txtPrint.Text,false),"Preview Text");
        }



        private void groupBox3_Enter_1(object sender, EventArgs e)
        {

        }

        
    }
}
*/