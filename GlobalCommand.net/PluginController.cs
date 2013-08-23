using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using GCPluginFramework;


namespace GlobalCommand.net
{
    class PluginController
    {
        public static List<Plugin> Plugins = new List<Plugin>();
        public static List<string> AllowedPlugins = new List<string>();

        public static void Load_plugins()
        {
            try {


            if (!Directory.Exists(Application.StartupPath))
            {
                return;
            }

            foreach (string f in Directory.GetFiles(Application.StartupPath))
            {
                FileInfo fi = new FileInfo(f);

                if (fi.Extension.Equals(".dll"))
                {
                    Plugin p = new Plugin(f);

                    

                    if (p != null)
                    {
                        Plugins.Add(p);
                    }
                }
            }

            PluginState.Save(Global.PluginSaveFileName);
        }

        public static IGCPlugin SetPlugin(string PluginFile)
        {

                if (! Security.matchKey(Security.getKey(asm)))
                {
                    if(! PluginState.inst.alwaysAllow.Contains(asm.ToString()) ) {
                        
                        sec.setSigned( (Security.getKey(asm) != "") );
                        sec.setPlugin(asm.ManifestModule.Name);
                        DialogResult d = DialogResult.None;
                        try
                        {
                            Global.mainForm.Show();
                            d = sec.ShowDialog(Global.mainForm);
                        }
                        catch (Exception) { 
                            // exception here if the program is closed from the
                            // tray while waiting for a dialog.
                        }
                        switch (d)
                        {
                            case DialogResult.Abort:       // do not load asm
                               return null;
                            case DialogResult.OK:           // temp allow
                                //
                            break;
                            case DialogResult.Yes:          // always allow
                                PluginState.inst.alwaysAllow.Add(asm.ToString());
                            break;
                            default:
                                return null;
                        }
                    } else {
                        // already in list.
                    }
                }
                IGCPlugin plug = null;

                try
                {

                    plug = Activator.CreateInstance(PluginClass) as IGCPlugin;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Plugin Error: " + e.InnerException.Message, "Plugin Error");
                    return null;
                }

                if (plug == null)
                {
                    return null;
                }


                foreach(IGCPlugin p in Plugins) {
                    if (p.getInfo().NameSpace.Trim().ToLower() == plug.getInfo().NameSpace.Trim().ToLower())
                    {
                        MessageBox.Show("Plugin '" + p.getInfo().Name + "' is already loaded with namespace '" + p.getInfo().NameSpace +
                            "'\n\n" + "Plugin '" + plug.getInfo().Name + "' with namespace '" + plug.getInfo().NameSpace + "' cannot be loaded because they are equal", "Plugin Load Error");


                        return null;
                    }

                 }

                //MessageBox.Show( asm.FullName + " " + Security.getKey(asm));
                
                AsmList.Add(plug, asm);

                return plug;
            }
            return null;
        }






    }
}