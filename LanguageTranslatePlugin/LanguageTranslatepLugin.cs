using System;
using System.Collections.Generic;
using GCPluginFramework;


namespace LanguageTranslatePlugin
{
    [Plugin(PluginType.Default)]
    public class LanguageTranslatepLugin : IGCPlugin
    {
        string[] languages = new string[] 
        {"ChineseS", "ChineseT", "Dutch","French", "German", "Greek",
            "Italian","Japanese", "Korean","Portuguese","Russian","Spanish" };

        string[] lang_codes = new string[] 
        { "zhCN", "zhTW", "nl", "fr", "de", "el", "it", "ja", "ko", "pt", "ru", "es" };

        string[] mysettings;

        public bool ShowConfigDialog()
        {
            return false;
        }

        public gcCommand[] getCommands()
        {
            List<gcCommand> li = new List<gcCommand>();
            foreach(string l in languages) {
                li.Add(new gcCommand("Translate text to " + l,  l +" #"));
            }
            return li.ToArray();
        }

        public string ExecuteCommand(string cmd, string args)
        {

            for (int i = 0; i < languages.Length; i++)
            {
                if (cmd.Trim().ToLower() == languages[i].Trim().ToLower())
                {
                    return TranslateText(args, "en|" + lang_codes[i]);
                }
            }



            return TranslateText(args, cmd);
        }



        public string PreviewCommandOutput(string cmd, string args)
        {
            return "Translation: " + cmd;
        }


        public override string ToString()
        {
            return "Language Translator";
        }


        private string TranslateText(string input,string languagePair)
        {
            
            if (input == "") { return ""; }
            string url = String.Format(mysettings[0], input, languagePair);
            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.Encoding = System.Text.Encoding.Default;
            string result = webClient.DownloadString(url);
            result = result.Substring(result.IndexOf("id=result_box") + 24);
            result = result.Substring(0, result.IndexOf("</div"));
            result = result.Replace("&quot;", "\"");
            return result.Trim();
            
        }

        #region IGCPlugin Members

        public string Author
        {
            get { return "David Amenta"; }
        }

        public string Description
        {
            get { return "Simple Translation Library (Google Translate) provides easy translation into many unicode languages.  Supported: " + string.Join(", ",languages); }
        }

        public string FriendlyName
        {
            get { return "Translation Library"; }
        }

        public string ShortName
        {
            get { return "Translate"; }
        }

        public void LoadSettings(string[] settings)
        {

            try
            {
                if (settings[0] != "")
                {
                    mysettings = settings;
                }
            }
            catch (Exception)
            {
                mysettings = new string[] { "http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}" };

            }
        }

        public string[] SaveSettings()
        {
            return mysettings;
        }


        #endregion
    }
}
