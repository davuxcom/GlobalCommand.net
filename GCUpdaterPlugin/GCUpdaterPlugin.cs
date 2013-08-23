using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GCPluginFramework;
using System.Xml.Serialization;


namespace GCUpdaterPlugin
{
    [Plugin(PluginType.Default)]
    public class GCUpdaterPlugin : IGCPlugin
    {
        public bool ShowConfigDialog()
        {
            frmUpdaterSettings f = new frmUpdaterSettings();
           f.ShowDialog();
           return true;
        }

        public override string ToString()
        {
            return FriendlyName;
        }

        public gcCommand[] getCommands()
        {
            return null;
        }




        #region IGCPlugin Members

        public string Author
        {
            get { return "David Amenta"; }
        }

        public string Description
        {
            get { return "This is a plugin that adds the ability for GlobalCommand to automatically update itself from a repository of your choosing."; }
        }

        public string FriendlyName
        {
            get { return "GlobalCommand Updater"; }
        }

        public string ShortName
        {
            get { return "{GCUpdate}"; }
        }

        public void LoadSettings(string[] settings)
        {
            if(settings != null) {
                Settings.Strings = settings;
            }
        }

        public string[] SaveSettings()
        {
            return Settings.Strings;
        }

        public string ExecuteCommand(string cmd, string args)
        {
            return "";
        }

        public string PreviewCommandOutput(string cmd, string args)
        {
            return "";
        }

        #endregion


    };
}

public class Settings
{
    public static string[] Strings = new string[3];
}