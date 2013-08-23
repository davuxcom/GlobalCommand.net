using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GCUpdaterPlugin
{



    [Serializable]
    [XmlRootAttribute(ElementName = "MD5Files", IsNullable = true)]
    public class MD5Files
    {
        public List<KeyCollection> data = new List<KeyCollection>();

        public MD5Files() { }
        public void Add(string filename, string hash, string desc)
        {
            data.Add(new KeyCollection(filename, hash, desc));

        }
        public class KeyCollection
        {
            public string key;
            public string value;
            public string value2;

            public KeyCollection() { }
            public KeyCollection(string _key, string _value, string _value2)
            {
                key = _key;
                value = _value;
                value2 = _value2;
            }
        }
    }
}
