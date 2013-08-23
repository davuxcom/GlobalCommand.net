using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace GlobalCommand.net
{

    public class PluginState
    {
        public List<string> alwaysAllow = new List<string>();

        private static PluginState _inst = null;

        public static PluginState inst
        {
            get
            {
                return _inst;
            }
            set
            {
                _inst = value;
            }
        }
    }
}
