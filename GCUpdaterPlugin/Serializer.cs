using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;


namespace GlobalCommand
{

    /// <summary>
    /// Serializer class.  Load and Save classes from/to XML files.
    /// </summary>
    public class Serializer
    {
        /// <summary>
        /// Load a class from a serialized XML file.
        /// </summary>
        /// <param name="filename">full path or path relative to the XML file</param>
        /// <param name="t">type of the class that is being retrieved (Use typeof(ClassName))</param>
        /// <returns>A populated version of the class, or null on failure</returns>
        /// <exception cref="Exception">Can throw several exceptions for IO and serialization loading</exception>
        public static T Load<T>(string filename)
        {
            T ob = default(T);
                using (Stream s = File.Open(filename, FileMode.Open))
                {
                    StreamReader sr = new StreamReader(s);
                    ob = (T)DeserializeObject(sr.ReadToEnd(), typeof(T));
                    s.Close();
                }
            return ob;
        }

        /// <summary>
        /// Save an instance of a class to an XML file
        /// </summary>
        /// <param name="filename">Full or relative path to the file</param>
        /// <param name="cls">Class to serialize and save.</param>
        /// <param name="t">Type of the class (use: typeof(ClassName)</param>
        /// <returns>True on success, False on failure</returns>
        public static void Save<T>(string filename, T cls)
        {
            using (Stream s = File.Open(filename, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write( SerializeObject(cls,typeof(T)) );
                    sw.Close();
                    s.Close();
                    return;
                }
            }
        }

        private static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        private static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        private static String SerializeObject(Object pObject, Type t )
        {
            String XmlizedString = null;
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(t);
            System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(memoryStream, Encoding.UTF8);
            xs.Serialize(xmlTextWriter, pObject);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
            return XmlizedString;
        }

        private static Object DeserializeObject(String pXmlizedString, Type t)
        {
            XmlSerializer xs = new XmlSerializer(t);
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
            System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(memoryStream, Encoding.UTF8);
            return xs.Deserialize(memoryStream);
        } 
    }
}
