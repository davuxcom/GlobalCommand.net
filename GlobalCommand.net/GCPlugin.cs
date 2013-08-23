using System.Collections.Generic;
using GCPluginFramework;


namespace GlobalCommand
{
    class GCPlugin : IGCPlugin 
    {



        public bool ShowConfigDialog()
        {
            return false;
        }

        public gcCommand[] getCommands()
        {
            List<gcCommand> li = new List<gcCommand>();


            li.Add(new gcCommand("Stop GlobalCommand", "Disable" ));
            li.Add(new gcCommand("Start GlobalCommand", "Enable" ));
            //   li.Add(new gcCommand("Plug GlobalCommand!", "Plug", true));
            li.Add(new gcCommand("Quit GlobalCommand", "Quit"));
            li.Add(new gcCommand("Show config window", "ShowConfig"));
            

            return li.ToArray();
        }



        public string ExecuteCommand(string cmd, string args)
        {
            switch (cmd.Trim().Substring(0, 5).ToLower())
            {
                case "enable":
                    Global.KeysDisabled = false;
                    return "";
                case "disable":
                    Global.KeysDisabled = true;
                    return "";
                case "plug":

                    return "I love using GlobalCommand (by David Amenta) - get it at http://dave.rh.rit.edu/";
                case "quit":
                    System.Windows.Forms.Application.Exit();
                    return "";
                case "showconfig":
                    if (frmMain.ActiveForm != null)
                    {
                        frmMain.ActiveForm.Show();
                    }

                    return "";
                default:
                    return "Not Recognized: " + cmd;
            }
        }


        public string PreviewCommandOutput(string cmd, string args)
        {
            return ""; // do not execute anything in preview mode.
        }


        public override string ToString()
        {
            return FriendlyName;
        }


        public string Author
        {
            get { return "David Amenta"; }
        }

        public string Description
        {
            get { return "Control key features of GlobalCommand via simple commands"; }
        }

        public string FriendlyName
        {
            get { return "GlobalCommand Internal"; }
        }

        public string ShortName
        {
            get { return "GC"; }
        }



        public void LoadSettings(string[] settings)
        {
            
        }

        public string[] SaveSettings()
        {
            return null;
        }

    }
}
