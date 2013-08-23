using System;
using System.Collections.Generic;
using System.Text;
using GCPluginFramework;


    [Plugin(PluginType.Default)]
    public class WinampPlugin : IGCPlugin
    {



        public bool ShowConfigDialog()
        {
            return false;
        }

        public gcCommand[] getCommands()
        {
            List<gcCommand> li = new List<gcCommand>();


            li.Add(new gcCommand("Get the currently playing song", "Song"));

            return li.ToArray();
        }




        public string ExecuteCommand(string cmd, string args)
        {
            switch (cmd.Trim().ToLower())
            {
                case "song":
                    return WinampApp.GetSongTitle();
                default:
                    return "Not Recognized: " + cmd;
            }
        }

        public string PreviewCommandOutput(string cmd, string args)
        {
            return ExecuteCommand(cmd,args);
        }


        public override string ToString()
        {
            return "Winamp Control & Output Plugin";
        }


        #region IGCPlugin Members

        public string Author
        {
            get { return "David Amenta"; }
        }

        public string Description
        {
            get { return "Get the currently playing song in Winamp"; }
        }

        public string FriendlyName
        {
            get { return "Winamp Output"; }
        }

        public string ShortName
        {
            get { return "Winamp"; }
        }

        public void LoadSettings(string[] settings)
        {
            return;
        }

        public string[] SaveSettings()
        {
            return null;
        }

        #endregion
    };
