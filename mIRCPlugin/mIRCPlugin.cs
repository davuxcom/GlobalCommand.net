using System;
using System.Collections.Generic;
using System.Text;
using GCPluginFramework;



[Plugin(PluginType.Default)]
public class mIRCPlugin : IGCPlugin
{


    public bool ShowConfigDialog()
    {
        return false;
    }

    public override string ToString()
    {
        return "mIRC Output Plugin";
    }

    public gcCommand[] getCommands()
    {
        List<gcCommand> li = new List<gcCommand>();


        li.Add(new gcCommand("mIRC Foreground Color White", "ColorWhite"));
        li.Add(new gcCommand("mIRC Foreground Color Black", "ColorBlack"));
        li.Add(new gcCommand("mIRC Foreground Color Blue", "ColorBlue"));
        li.Add(new gcCommand("mIRC Foreground Color Green", "ColorGreen"));
        li.Add(new gcCommand("mIRC Foreground Color Light Red", "ColorLightRed"));
        li.Add(new gcCommand("mIRC Foreground Color Brown", "ColorBrown"));
        li.Add(new gcCommand("mIRC Foreground Color Purple", "ColorPurple"));
        li.Add(new gcCommand("mIRC Foreground Color Orange", "ColorOrange"));
        li.Add(new gcCommand("mIRC Foreground Color Yellow", "ColorYellow"));
        li.Add(new gcCommand("mIRC Foreground Color Green", "ColorLightGreen"));
        li.Add(new gcCommand("mIRC Foreground Color Cyan", "ColorCyan"));
        li.Add(new gcCommand("mIRC Foreground Color Light Cyan", "ColorLightCyan"));
        li.Add(new gcCommand("mIRC Foreground Color Light Blue", "ColorLightBlue"));
        li.Add(new gcCommand("mIRC Foreground Color Pink", "ColorPink"));
        li.Add(new gcCommand("mIRC Foreground Color Grey", "ColorGrey"));
        li.Add(new gcCommand("mIRC Foreground Color Light Grey", "ColorLightGrey"));
        li.Add(new gcCommand("Press Enter Key", "Enter"));

        li.Add(new gcCommand("mIRC Bold Text", "Bold"));
        li.Add(new gcCommand("mIRC Underlined Text", "Underline"));
        li.Add(new gcCommand("mIRC Plain Text", "Plain"));
        li.Add(new gcCommand("mIRC Reversed Text", "Reverse"));
        li.Add(new gcCommand("Insert /me text", "Me"));

        return li.ToArray();
    }



    public string PreviewCommandOutput(string cmd, string args)
    {
        try
        {
            switch (cmd.ToLower())
            {

                // values

                case "colorwhite":
                    return "<font color=\"white\">";
                case "colorblack":
                    return "<font color=\"black\">";
                case "colorblue":
                    return "<font color=\"blue\">";
                case "colorgreen":
                    return "<font color=\"green\">";
                case "colorlightred":
                    return "<font color=\"lightred\">";
                case "colorbrown":
                    return "<font color=\"brown\">";
                case "colorpurple":
                    return "<font color=\"purple\">";
                case "colororange":
                    return "<font color=\"orange\">";
                case "coloryellow":
                    return "<font color=\"yellow\">";
                case "colorlightgreen":
                    return "<font color=\"lightgreen\">";
                case "colorcyan":
                    return "<font color=\"cyan\">";
                case "colorlightcyan":
                    return "<font color=\"lightcyan\">";
                case "colorlightblue":
                    return "<font color=\"lightblue\">";
                case "colorpink":
                    return "<font color=\"pink\">";
                case "colorgrey":
                    return "<font color=\"grey\">";
                case "colorlightgrey":
                    return "<font color=\"lightgrey\">";
                case "bold":
                    return "</strong><strong>";
                case "underline":
                    return "</u><u>";
                case "reverse":
                    return ""; // unsupported
                case "plain":
                    return "</u></strong><font color=\"black\">"; ;
                case "me":
                    return "NickName ";
                case "enter":
                    return "<br />";
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

    public string ExecuteCommand(string cmd, string args)
    {
        try
        {
            switch (cmd.ToLower())
            {

                // values

                case "colorwhite":
                    return "^(k)0";
                case "colorblack":
                    return "^(k)1";
                case "colorblue":
                    return "^(k)2";
                case "colorgreen":
                    return "^(k)3";
                case "colorlightred":
                    return "^(k)4";
                case "colorbrown":
                    return "^(k)5";
                case "colorpurple":
                    return "^(k)6";
                case "colororange":
                    return "^(k)7";
                case "coloryellow":
                    return "^(k)8";
                case "colorlightgreen":
                    return "^(k)9";
                case "colorcyan":
                    return "^(k)10";
                case "colorlightcyan":
                    return "^(k)11";
                case "colorlightblue":
                    return "^(k)12";
                case "colorpink":
                    return "^(k)13";
                case "colorgrey":
                    return "^(k)14";
                case "colorlightgrey":
                    return "^(k)15";
                case "bold":
                    return "^(b)";
                case "underline":
                    return "^(u)";
                case "reverse":
                    return "^(r)";
                case "plain":
                    return "^(o)";
                case "me":
                    return "/me ";
                case "enter":
                    return "{ENTER}";
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






    #region IGCPlugin Members

    public string Author
    {
        get { return "David Amenta"; }
    }

    public string Description
    {
        get { return "Library for mIRC color codes."; }
    }

    public string FriendlyName
    {
        get { return "mIRC Output"; }
    }

    public string ShortName
    {
        get { return "mIRC"; }
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
