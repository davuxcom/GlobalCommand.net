using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Xml.Serialization;


namespace GlobalCommand
{
    [XmlRootAttribute(ElementName = "HotKey", IsNullable = true)]
    [Serializable]
    public class HotKey : System.Windows.Forms.NativeWindow, IDisposable
    {

        [DllImport("user32", SetLastError = true)]
        private static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32", SetLastError = true)]
        private static extern int UnregisterHotKey(IntPtr hwnd, int id);
        [DllImport("kernel32", SetLastError = true)]
        private static extern short GlobalAddAtom(string lpString);
        [DllImport("kernel32", SetLastError = true)]
        private static extern short GlobalDeleteAtom(short nAtom);

        public const int MOD_ALT = 1;
        public const int MOD_CONTROL = 2;
        public const int MOD_SHIFT = 4;
        public const int MOD_WIN = 8;

        short hotkeyID;

        private KeyPair HotKey_Key;


        public KeyPair TheHotKey
        {
            get
            {
                return HotKey_Key;
            }
            set
            {
                HotKey_Key = value;

                Register();
            }
        }




        public HotKey(KeyPair key)
        {
            HotKey_Key = key;
            this.CreateHandle(new System.Windows.Forms.CreateParams());
        }

        public HotKey()
        {
            this.CreateHandle(new System.Windows.Forms.CreateParams());
        }

        public static string ToString(System.Windows.Forms.Keys key, int modifiers)
        {
            string ret = "";
            int m = modifiers;
            if (m >= 8)
            {
                ret += "WIN + ";
                m -= 8;
            }
            if (m >= 4)
            {
                ret += "SHIFT + ";
                m -= 4;
            }
            if (m >= 2)
            {
                ret += "CTRL + ";
                m -= 2;
            }
            if (m >= 1)
            {
                ret += "ALT + ";
                m -= 1;
            }

            ret += key.ToString();

            return ret;
        }

        public override string ToString()
        {
            return ToString(TheHotKey.key, TheHotKey.modifiers);
        }


        private bool Register() 
        {
            try
            {
                // use the GlobalAddAtom API to get a unique ID (as suggested by MSDN docs)
                string atomName = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString("X8") + this.GetHashCode();
                hotkeyID = GlobalAddAtom(atomName);
                if (hotkeyID == 0)
                {
                    throw new Exception("Unable to generate unique hotkey ID. Error code: " +
                       Marshal.GetLastWin32Error().ToString());
                }


                if (RegisterHotKey(this.Handle, hotkeyID, HotKey_Key.modifiers , (int)HotKey_Key.key) == 0)
                {
                    throw new Exception("Unable to register hotkey. Error code: " + Marshal.GetLastWin32Error()
                       .ToString());
                }
                return true;
            }
            catch (Exception)
            {
                UnRegister();
                return false;
            }
        }


        public void UnRegister()
        {
            if (this.hotkeyID != 0)
            {
                UnregisterHotKey(this.Handle, hotkeyID);
                // clean up the atom list
                GlobalDeleteAtom(hotkeyID);
                hotkeyID = 0;
            }
            
        }

        public void Dispose()
        {
            UnRegister();
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            // let the base class process the message
            
            base.WndProc(ref m);

            // if this is a WM_HOTKEY message, notify the parent object
            const int WM_HOTKEY = 0x312;
            if (m.Msg == WM_HOTKEY)
            {
                // do whatever you wish to do when the hotkey is pressed
                // in this example we activate the form and display a messagebox
                HotKeyPump.newMessage(this.HotKey_Key);
            }
        }


    }

    [XmlRootAttribute(ElementName = "KeyPair", IsNullable = true)]
    [Serializable]
    public class KeyPair {

        public System.Windows.Forms.Keys key;
        public int modifiers;

        public KeyPair(System.Windows.Forms.Keys _key, int _modifiers) {
            key = _key;
            modifiers = _modifiers;
        }

        public KeyPair() { }
    }

    public class HotKeyPump
    {
        public static void newMessage(KeyPair key) {
            foreach (Command cmd in Command.Commands)
            {
                if (cmd.hkey != null)
                {
                    if (cmd.hkey.TheHotKey == key)
                    {
                        // found key

                        KeyFunctions.inCommand = cmd;
                        KeyFunctions.numToBackspace = 0;

                        System.Threading.Thread t = new System.Threading.Thread(Global.mainForm.mySendKeys);
                        t.Start();

                        return;
                    }
                }
            }
        }

    }

}
