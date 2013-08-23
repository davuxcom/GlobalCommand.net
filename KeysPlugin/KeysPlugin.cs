using System;
using System.Collections.Generic;
using System.Text;
using GCPluginFramework;


[Plugin(PluginType.Default)]
public class KeysPlugin : IGCPlugin 
{



    public bool ShowConfigDialog()
    {
        return false;
    }

    public gcCommand[] getCommands()
    {
        List<gcCommand> li = new List<gcCommand>();


        li.Add(new gcCommand("Enter Key", "Enter"));
        li.Add(new gcCommand("Bold", "Bold"));

        li.Add(new gcCommand("Windows Key", "WinFlag"));

        li.Add(new gcCommand("Up Arrow", "Up"));
        li.Add(new gcCommand("Down Arrow", "Down"));
        li.Add(new gcCommand("Left Arrow", "Left"));
        li.Add(new gcCommand("Right Arrow", "Right"));

        return li.ToArray();
    }


    public string ExecuteCommand(string cmd, string args)
    {
        try
        {
            switch (cmd.ToLower())
            {

                // values

                case "bold":
                    return "^(b)";
                case "enter":
                    return "{ENTER}";
                case "up":
                    return "{UP}";
                case "winflag":
                    return "^{ESC}";
                case "down":
                    return "{DOWN}";
                case "left":
                    return "{LEFT}";
                case "right":
                    return "{RIGHT}";
                case "backspace":
                    return "{BS}";


                default:
                    break;
            }
            return "";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string PreviewCommandOutput(string cmd, string args)
    {
        return ExecuteCommand(cmd, args);
    }


    #region IGCPlugin Members

    public string Author
    {
        get { return "David Amenta"; }
    }

    public string Description
    {
        get { return "Key Output Library"; }
    }

    public string FriendlyName
    {
        get { return "Key Output"; }
    }

    public string ShortName
    {
        get { return "Keys"; }
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
