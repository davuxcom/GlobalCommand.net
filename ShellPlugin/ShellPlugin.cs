using System;
using System.Collections.Generic;
using System.Text;
using GCPluginFramework;


[Plugin(PluginType.Default)]
public class ShellPlugin : IGCPlugin
{


    public bool ShowConfigDialog()
    {
        return false;
    }

    public gcCommand[] getCommands()
    {
        List<gcCommand> li = new List<gcCommand>();


        li.Add(new gcCommand("Start an application with normal focus", "Start"));

        return li.ToArray();
    }



    public string ExecuteCommand(string cmd, string args)
    {
        switch (cmd.ToLower())
        {
            case "start":
                try {
                    System.Diagnostics.Process.Start(args);

                } catch(Exception) {}
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
        return "Application Launcher";
    }


    #region IGCPlugin Members

    public string Author
    {
        get { return "David Amenta"; }
    }

    public string Description
    {
        get { return "Launch applications as if they were executed from the Run prompt"; }
    }

    public string FriendlyName
    {
        get { return "Application Launcher"; }
    }

    public string ShortName
    {
        get { return "App"; }
    }

    public void LoadSettings(string[] settings)
    {
        return ;
    }

    public string[] SaveSettings()
    {
        return null;
    }

    #endregion
};
