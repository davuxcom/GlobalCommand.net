
/*
 * 
 * To start:
 * Create a new project.
 * Add a reference to GCPluginFramework.dll via project-> add reference.
 * Add "using GCPluginFramework;" to the class
 * Implement the IGCPlugin interface.
 * Right click on IGCPlugin and select "implement interface"
 * 
 * In order to run:
 * Go to project properties -> build -> output
 * Specify a folder where the gloalcommand binary is, and specify 
 * to run that exe on successful build.
 */



using System;
using System.Collections.Generic;
using System.Text;

// this line will include the GCPluginFramework library, and give you access to the interfaces
// and tools provided by the framework.
using GCPluginFramework;

// this line specify's the plugin type, leave it as deafult for proper detection
[Plugin(PluginType.Default)]
// remember to implement IGCPlugin in your class.
public class SamplePlugin : IGCPlugin
{



    // this method returns a list of all the commands that are to be shown on the pop up
    // menu on the Add Command dialog.
    // It is suggested that you create a list and add cmds to it using new gcCommand()
    // but the return value must be an array.
    public gcCommand[] getCommands()
    {
        List<gcCommand> li = new List<gcCommand>();

        // this is just an output line, no action is done.
        // an example of this would be to read the currently playing song
        // from some media player.
        li.Add(new gcCommand("Output something", "Out"));

        // this line does an action.
        // an example of this would be to press 'play' on a media player
        li.Add(new gcCommand("Instruct the sample plugin to do some action", "Do"));

        return li.ToArray();
    }

    // this gets called when an cmd is requested.
    // if this app was passed [Sample.DoCommand arg1] then cmd would be equal to:
    // DoCommand arg1
    // all data after the NameSpace. will be passed to this routine.  (So Sample. in this case)
    public string ExecuteCommand(string cmd, string args)
    {
        try
        {
            // it is important to ignore case here, if you wish.
            // text will come in as it is entered [Sample.DO] is not equal to [Sample.do],
            // you must evaluate how you see fit.
            switch (cmd.ToLower())
            {
                case "out":
                    return "Something";
                case "do":
                    // do some action here.
                    // maybe run a program, open a cd drive, connect to the internet

                    // you can still return text on an action, though it isn't standard.
                    return "";

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

    // this method is for preview on the command dialog.
    // most output values can just be passed on to executecmd
    // but it is VERY important to NOT execute actions here
    // since it will be called every second while the dialog is open.

    // anything that can be displayed graphically, should be done so using HTML markup.
    // output strings should be HTML safe.
    public string PreviewCommandOutput(string cmd, string args)
    {
        // do is an action, so we don't want to execute it
        if (cmd.Trim().ToLower() != "do")
        {
            return ExecuteCommand(cmd,args);
        }
        else
        {
            return "";
        }
    }

    // we don't have a configuration dialog with this plugin, so return false and
    // let the host know.
    public bool ShowConfigDialog()
    {
        return false;
    }


    public string Author
    {
        get { return "David Amenta"; }
    }


    public string Description
    {
        get { return "Short Description"; }
    }

    public string FriendlyName
    {
        get { return "Sample Plugin Name"; }
    }

    public string ShortName
    {
        get { return "Sample"; }
    }

    public void LoadSettings(string[] settings)
    {
        return;
    }

    public string[] SaveSettings()
    {
        return null;
    }
};
