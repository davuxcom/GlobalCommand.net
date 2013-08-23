using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using GlobalCommand;
using XML;

public class Command :IDisposable
{
    public static List<Command> Commands;

    public static void LoadState()
    {
        try
        {
            Commands = XSerial.Load<List<Command>>(Global.CommandSaveFileName);
        } catch ( Exception e) {
            Log.WriteLine("Error loading commands");
            Log.WriteLine(e);
            Commands = new List<Command>();
        }
    }

    public static void SaveState()
    {
        try
        {
            XSerial.Save<List<Command>>(Global.CommandSaveFileName, Commands);
        }
        catch (Exception e)
        {
            Log.WriteLine("Error saving commands");
            Log.WriteLine(e);
        }
    }

    public string ActionString = "";
    public string ActionEndString = "";
    public string PrintString = "";
    public HotKey hkey = null;
    public bool Backspace;
    public bool Enabled = true;

    public override string ToString()
    {
        if (hkey != null)
        {
            return hkey.ToString();
        }
        return ActionString;
    }

    public string getBackspaces()
    {
        string bs = "";
        for (int k = 0; k < ActionString.Length; k++)
        {
            bs += "{BS}";
        }
        return bs;
    }

    public void Dispose()
    {
        if (hkey != null)
        {
            hkey.UnRegister();
        }
    }

}
