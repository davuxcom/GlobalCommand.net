using System;
using GCPluginFramework;

namespace GlobalCommand
{


    class KeyFunctions
    {
        // key buffer
        static string keybuffer = "";

        public static Command inCommand = null;

        public static string Arguments = "";
        public static int numToBackspace = 0;

        private static string KeySafeString(string s)
        {
            s = s.Replace("+", "-1567-PLUS-CONTROL");
            s = s.Replace("^", "-1567-CARROT-CONTROL");
            s = s.Replace("%", "-1567-PCT-CONTROL");
            s = s.Replace("(", "-1567-PAR-RIGHT");
            s = s.Replace(")", "-1567-PAR-LEFT");


            //s = s.Replace("~", "+(`)");
            //s = s.Replace("!", "+(1)");
            //s = s.Replace("@", "+(2)");
            //s = s.Replace("#", "+(3)");
            //s = s.Replace("$", "+(4)");
           // s = s.Replace("&", "+(7)");
           // s = s.Replace("*", "+(8)");
            //s = s.Replace("_", "+(-)");

            s = s.Replace("-1567-PLUS-CONTROL", "+(=)");
            s = s.Replace("-1567-CARROT-CONTROL", "+(6)");
            s = s.Replace("-1567-PCT-CONTROL", "+(5)");
            s = s.Replace("-1567-PAR-RIGHT", "+(9)");
            s = s.Replace("-1567-PAR-LEFT", "+(0)");

            return s;
        }



        public static string getOutputString()
        {
            return getOutputString(false, "");
        }

        public static string getOutputString(bool preview_only, string data)
        {
            string args = Arguments;
            Arguments = "";
            Command me = inCommand;
            inCommand = null;
            numToBackspace = 0;
            
            string outBuffer = "";
            string cmdBuffer = "";
            bool in_cmd = false;
            string s= "";
            if (preview_only)
            {
                s = data;
            }
            else
            {
                s = me.PrintString;
            }
            if (!preview_only)
            {

                s = KeySafeString(s);
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '[')
                {
                    if (in_cmd)
                    {
                        outBuffer += "[" + cmdBuffer;
                        cmdBuffer = "";
                    }

                    in_cmd = true;
                }
                else if (s[i] == ']')
                {
                    if (!in_cmd)
                    {
                        outBuffer += "]";
                        in_cmd = false;
                    }
                    else
                    {


                        if (cmdBuffer == "")
                        {
                            outBuffer += "[]";
                        }
                        else
                        {

                            if (cmdBuffer.IndexOf('.') == -1)
                            {
                                outBuffer += "[" + cmdBuffer + "]";
                            }
                            else
                            {
                                string ns = cmdBuffer.Substring(0, cmdBuffer.IndexOf('.'));

                                Plugin found = null;
                                foreach (Plugin p in Plugin.Plugins)
                                {
                                    if (p.ShortName.Trim().ToLower() == ns.Trim().ToLower())
                                    {
                                        found = p;
                                        break;
                                    }
                                }

                                if (found != null)
                                {

                                    string cb = cmdBuffer.Substring(cmdBuffer.IndexOf('.') + 1);

                                    if (cb.IndexOf('#') > -1)
                                    {
                                        cb = cb.Replace("#", "").Trim();

                                        if (preview_only)
                                        {
                                            outBuffer += found.PreviewCommandOutput(cb, args);
                                        }
                                        else
                                        {
                                            outBuffer += found.ExecuteCommand(cb, args);
                                        }
                                    }
                                    else
                                    {
                                        if (cb.IndexOf(' ') > -1)
                                        {
                                            args = cmdBuffer.Substring(cmdBuffer.IndexOf(' ') + 1);
                                            try
                                            {

                                                if (preview_only)
                                                {
                                                    outBuffer += found.PreviewCommandOutput(cb.Substring(0, cb.IndexOf(' ')), args);
                                                }
                                                else
                                                {
                                                    outBuffer += found.ExecuteCommand(cb.Substring(0, cb.IndexOf(' ')), args);
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                outBuffer += "PluginError " + e.Message;
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if (preview_only)
                                                {
                                                    outBuffer += found.PreviewCommandOutput(cb, "");
                                                }
                                                else
                                                {
                                                    outBuffer += found.ExecuteCommand(cb, "");
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                outBuffer += "PluginError " + e.Message;
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    outBuffer += "[" + cmdBuffer + "]";
                                }
                            }
                        }
                    }
                    in_cmd = false;
                    cmdBuffer = "";

                }
                else
                {
                    if (in_cmd)
                    {
                        cmdBuffer += s[i];
                    }
                    else
                    {
                        outBuffer += s[i];
                    }
                }
            }

            if (in_cmd)
            {
                outBuffer += "[" + cmdBuffer;
            }

            return outBuffer;
        }

        public static string getPreviewString(string s, string args)
        {
            Arguments = args;
            return getOutputString(true,s);
        }

        public static bool addKey(string key)
       {
            if (key.Length == 0)
            {
                return false;
            }

            if (key[0] == 8)
            {
                if (keybuffer.Length > 0)
                {
                    keybuffer = keybuffer.Substring(0, keybuffer.Length - 1);
                }
                else
                {
                    keybuffer = "";
                }

                return false;
            } else {
                keybuffer += key;
            }

            // clear the buffer on enter, as well as when it gets long
            if (key[0] == 13)
            {
                keybuffer = "";
                inCommand = null;
                return false;
            }
            if (keybuffer.Length > 24)
            {
                if (inCommand == null)  // only short the buffer if we are searching.
                {
                    keybuffer = keybuffer.Substring(keybuffer.Length - 16);
                }
            }

            if (inCommand != null)
            {
                if (key == inCommand.ActionEndString)
                {
                    Arguments = keybuffer.Substring(inCommand.ActionString.Length+ 1);
                    Arguments = Arguments.Substring(0, Arguments.Length - 1);
                    numToBackspace = keybuffer.Length;
                    keybuffer = "";

                    return true;
                }
                else
                {
                    // do nothing, wait for more keys
                }
            }
            else
            {

                foreach (Command cmd in Command.Commands)
                {
                    if (cmd != null)
                    {
                        if (cmd.ActionString != null && cmd.ActionString != "")
                        {
                            if (keybuffer.IndexOf(cmd.ActionString, StringComparison.CurrentCultureIgnoreCase) > -1)
                            {
                                inCommand = cmd;
                                if (inCommand.ActionEndString != null && inCommand.ActionEndString != "")
                                {
                                    Arguments = "";
                                    keybuffer = keybuffer.Substring(keybuffer.IndexOf(inCommand.ActionString, StringComparison.CurrentCultureIgnoreCase));
                                    return false;
                                }

                                keybuffer = "";
                                numToBackspace = inCommand.ActionString.Length;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static void PasteKey()
        {
            if( System.Windows.Forms.Clipboard.ContainsText()) {
                keybuffer+= System.Windows.Forms.Clipboard.GetText();
            }
        }

        public static string GetBackspaces()
        {
            string s = "";
            for (int i = 0; i < numToBackspace; i++)
            {
                s += "{BS}";
            }
            return s;
        }
    }
}
