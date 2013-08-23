using System;
using System.IO;


namespace GlobalCommand
{
    class Global
    {
        public static bool KeysDisabled;
        public static bool Closing;
        public static frmMain mainForm;
        public static string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GlobalCommand";
        public static string PluginSaveFileName = AppDataFolder + "\\GCPluginData.xml";
        public static string CommandSaveFileName = AppDataFolder + "\\GCCommandData.xml";
        public static string LogSaveFileName = AppDataFolder + "\\log.txt";

    }

    public class Log
    {
        private static string file = "";

        public static bool Setup(string filename)
        {
            file = filename;



            try {
                if(!System.IO.Directory.Exists(Global.AppDataFolder)) {
                    System.IO.Directory.CreateDirectory(Global.AppDataFolder);
                }
                System.IO.File.Delete(filename);
                
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public static void WriteLine(string w)
        {
            try
            {
                using(TextWriter t = new StreamWriter(file, true)) {
                    
                    t.WriteLine(w + "\n");
                    t.Close();
                }

            }
            catch (Exception)
            {
                // the user knows logging is broken after setup->false;
            }
        }

        public static void WriteLine(Exception e)
        {
            WriteLine(e.Message);
            WriteLine(e.StackTrace);
            WriteLine("\n");
            if (e.InnerException != null)
            {
                WriteLine(e.InnerException.Message);
                WriteLine(e.InnerException.StackTrace);
            }
            WriteLine("\n\n\n");
        }
    }
}
