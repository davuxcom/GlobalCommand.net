using System;
using System.IO;


namespace GlobalCommand
{
    class Global
    {
        public static string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GlobalCommand";

        public static bool SuppressErrors = false;

    }

public class Log
{
    public static void WriteLine(string text)
    {
        if(!Global.SuppressErrors)
        System.Windows.Forms.MessageBox.Show(text);
    }

    public static void WriteLine(Exception e)
    {
        string o = "";

        o = e.Message + "\n\n" + e.StackTrace;

        if (e.InnerException != null)
        {

            o += "\n\nInnerException: " + e.InnerException.Message;
            o += "\n\n" + e.InnerException.StackTrace;
        }
        if(!Global.SuppressErrors)
        System.Windows.Forms.MessageBox.Show(o);
    }
}
}