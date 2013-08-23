using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using GCPluginFramework;
using System.IO;
using XML;

namespace GlobalCommand
{
    public class Plugin : IGCPlugin, IDisposable
    {
        // static
        #region Static state and methods

        public static List<Plugin> Plugins = new List<Plugin>();
        public static List<string> AllowedPlugins = new List<string>();

        public static Plugin[] Load()
        {
            return Load(System.Windows.Forms.Application.StartupPath);
        }

        public static Plugin[] Load(string folder)
        {
            List<Plugin> plugs = new List<Plugin>();

            if ( ! Directory.Exists(folder))
            {
                return null;
            }

            foreach (string f in Directory.GetFiles(System.Windows.Forms.Application.StartupPath))
            {
                FileInfo fi = new FileInfo(f);

                if (fi.Extension.Equals(".dll"))
                {
                    Plugin p;

                    try
                    {
                        p = new Plugin(f);
                    }
                    catch (Exception  e)
                    {
                        // couldn't load the plugin for whatever reason.
                        Log.WriteLine("Couldn't load assembly " + fi.Name);
                        Log.WriteLine(e);
                        p = null; 
                    }

                    if (p != null)
                    {
                        plugs.Add(p);
                    }
                }
            }

            return plugs.ToArray();
        }

        public static void SaveState()
        {
            try
            {
                XSerial.Save<List<string>>(Global.PluginSaveFileName, AllowedPlugins);
            }
            catch (Exception e)
            {
                Log.WriteLine("Could not save plugin file");
                Log.WriteLine(e);
            }
        }

        public static void LoadSate()
        {
            try
            {
                AllowedPlugins = XSerial.Load<List<string>>(Global.PluginSaveFileName);
            }
            catch (Exception e)
            {
                Log.WriteLine("Could not load plugin file");
                Log.WriteLine(e);

                AllowedPlugins = new List<string>();
            }
        }

        public static void DisposeAll() {
            foreach(Plugin p in Plugins) {
                p.Dispose();
            }
        }

        #endregion




        #region Instance state and methods

        private IGCPlugin _plugin = null;
        private Assembly _assembly = null;
        private string _SecurityKey = "";
        private string _FileName = "";
        private string _Publisher = "";
        private string _Version = "";
        private Type _PluginType;
        
        public Plugin(IGCPlugin p)
        {
            _plugin = p;
            _SecurityKey = Security.SecurityKey;
            _assembly = Assembly.GetAssembly(typeof(Program));
        }

        public Plugin(string filename) {

            if (!File.Exists(filename))
            {
                return;
            }

            _assembly = Assembly.LoadFile(filename);

            _FileName = System.IO.Path.GetFileName(filename);

            if (_assembly != null)
            {
                foreach (Type type in _assembly.GetTypes())
                {
                    if (type.IsAbstract) continue;
                    object[] attrs = type.GetCustomAttributes(typeof(PluginAttribute), true);
                    if (attrs.Length > 0)
                    {
                        foreach (PluginAttribute pa in attrs)
                        {
                            _PluginType = type;
                            return;
                        }
                    }
                }
            }

            throw new Exception("Invalid Plugin");
        }

        public vActivationState Activate()
        {
            if (_assembly == null)
            {
                return vActivationState.NoActivationRequired;
            }

            try
            {

                _plugin = Activator.CreateInstance(_PluginType) as IGCPlugin;


                foreach (Plugin p in Plugin.Plugins)
                {
                    if (p.ShortName.Trim().ToLower() == _plugin.ShortName.Trim().ToLower())
                    {
                        _plugin = null;
                        // the assembly is loaded, but there isn't any way to unload it
                        // without tearing down the appDomain, so we'll just have to leave 
                        // it until the user corrects it, if ever.
                        return vActivationState.NameConflict;
                    }
                }
                string[] o = null;
                try {
                    o = XSerial.Load<string[]>(Global.AppDataFolder + "\\PluginSettings." + _PluginType.Name + ".xml");

                } catch(Exception ex) {
                    Log.WriteLine("Couldn't load plugin settings (" + FriendlyName + ")");
                    Log.WriteLine(ex);
                }
                
                _plugin.LoadSettings(o);

                return vActivationState.Activated;
            }
            catch (Exception e)
            {
                Log.WriteLine("[ER] Could not avticate plugin");
                Log.WriteLine(e);
                return vActivationState.Error;
            }
        }

        public bool AlwaysAllowed
        {
            get
            {
                 return AllowedPlugins.Contains(_assembly.ToString());

            }
            set
            {
                if (value == true)
                {
                    if (!AlwaysAllowed)
                    {
                        AllowedPlugins.Add(_assembly.ToString());
                    }
                }
                else
                {
                    if (AlwaysAllowed)
                    {
                        AllowedPlugins.Remove(_assembly.ToString());
                    }
                }
                
            }
        }

        public string Publisher
        {
            get
            {
                if (_Publisher == "")
                {
                     AssemblyCompanyAttribute a =GetAssemblyAttribute<AssemblyCompanyAttribute>(_assembly);
                     if (a != null && a.Company != null && a.Company != "")
                     {
                         _Publisher = a.Company;
                     }
                     else
                     {
                         _Publisher = "Not Indicated";
                     }
                }
                return _Publisher;
            }
        }

        public string Version
        {
            get
            {
                if (_Version == "")
                {
                    AssemblyFileVersionAttribute a = GetAssemblyAttribute<AssemblyFileVersionAttribute>(_assembly);
                    if (a != null && a.Version != null && a.Version != "")
                    {
                        _Version = a.Version;
                    }
                    else
                    {
                        _Version = "Not Indicated";
                    }
                }
                return _Version;
            }
        }

        public string SecurityKey
        {
            get
            {
                if(_SecurityKey == "") {
                    if(_assembly != null) {
                        _SecurityKey = Security.getKey(_assembly);
                    }
                }
                return _SecurityKey;
            }
        }

        public vSignature Signature
        {
            get
            {
                if (SecurityKey == Security.SecurityKey)
                {
                    return vSignature.Verified;
                }
                else if (SecurityKey.Trim().Length == 0)
                {
                    return vSignature.NotPresent;
                }
                else
                {
                    return vSignature.Persent;
                }
            }
        }

        public string FileName
        {
            get
            {
                return _FileName;
            }
        }

        public enum vActivationState
        {
            Activated, NameConflict, Error, NoActivationRequired
        }

        public enum vSignature
        {
            Persent, NotPresent, Verified
        }

        private static T GetAssemblyAttribute<T>(Assembly assembly) where T : Attribute
        {
            if (assembly == null) return null;
            object[] attributes = assembly.GetCustomAttributes(typeof(T), true);
            if (attributes == null) return null;
            if (attributes.Length == 0) return null;
            return (T)attributes[0];
        }


        #region Error-Safe IGCPlugin Methods

        /*
        public string Author
        {
            get {
                try
                {
                    return _plugin.Author;
                }
                catch (Exception ex)
                {
                    Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (Author)"); Log.WriteLine(ex);
                    return "";
                }
            }
        }
        */

        public string Description
        {
            get
            {
                try
                {
                    return _plugin.Description;
                }
                catch (Exception ex)
                {
                    Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (Description)"); Log.WriteLine(ex);
                    return "";
                }
            }
        }

        public string FriendlyName
        {
            get
            {
                try
                {
                    return _plugin.FriendlyName;
                }
                catch (Exception ex)
                {
                    Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (FriendlyName)"); Log.WriteLine(ex);
                    return "";
                }
            }
        }


        public string Author
        {
            get
            {
                try
                {
                    return _plugin.Author;
                }
                catch (Exception ex)
                {
                    Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (Author)"); Log.WriteLine(ex);
                    return "";
                }
            }
        }

        public string ShortName
        {
            get
            {
                try
                {
                    return _plugin.ShortName;
                }
                catch (Exception ex)
                {
                    Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (ShortName)"); Log.WriteLine(ex);
                    return "";
                }
            }
        }





        public gcCommand[] getCommands()
        {
            try
            {
                return _plugin.getCommands();
            }
            catch (Exception ex)
            {
                Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (getCommands)"); Log.WriteLine(ex);
                return null;
            }
        }

        public string ExecuteCommand(string cmd, string args)
        {
            try
            {
                return _plugin.ExecuteCommand(cmd, args);
            }
            catch (Exception ex)
            {
                Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (Executecommand)"); Log.WriteLine(ex);
                return "";
            }
        }

        public string PreviewCommandOutput(string cmd, string args)
        {
            try
            {
                return _plugin.PreviewCommandOutput(cmd, args);
            }
            catch (Exception ex)
            {
                Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (PreviewCommandOutput)"); Log.WriteLine(ex);
                return "";
            }
        }

        public override string ToString()
        {
            try
            {
                if (_plugin == null)
                {
                    return FileName;
                }
                else
                {
                    return _plugin.ToString();
                }

            }
            catch (Exception ex)
            {
                Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (ToString)"); Log.WriteLine(ex);
                return "";
            }
        }

        public bool ShowConfigDialog()
        {
            try
            {
               return  _plugin.ShowConfigDialog();
            }
            catch (Exception ex)
            {
                Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (ShowConfigDialog)"); Log.WriteLine(ex);
                return false;
            }
        }




        public void LoadSettings(string[] settings)
        {
            try
            {
                 _plugin.LoadSettings(settings);
            }
            catch (Exception ex)
            {
                Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (LoadSettings)"); Log.WriteLine(ex);
            }
        }

        public string[] SaveSettings()
        {
            try
            {
                return _plugin.SaveSettings();
            }
            catch (Exception ex)
            {
                Log.WriteLine("[EX] Plugin Error (" + this.FileName + "): (SaveSettings)"); Log.WriteLine(ex);
                return null;
            }
        }

        #endregion
        #endregion



        #region IDisposable Members

        public void Dispose()
        {
            
            try
            {
                string[] o = SaveSettings();

                XSerial.Save<string[]>(Global.AppDataFolder + "\\PluginSettings." + _PluginType.Name + ".xml", o);
            }
            catch (Exception ex)
            {
                Log.WriteLine("Couldn't save plugin settings (" + FriendlyName + ")");
                Log.WriteLine(ex);
            }
        }

        #endregion
    }
}
