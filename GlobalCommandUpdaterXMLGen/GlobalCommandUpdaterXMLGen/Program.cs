using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;


using XMLSerial;

namespace GlobalCommandUpdaterXMLGen
{
    class Program
    {
        static void Main(string[] args)
        {
            bool createDesc = false;
            if (args.Contains("/?"))
            {
                Console.WriteLine(" XML Updater Script Generator \n\n");
                Console.WriteLine(" by David Amenta \n\n");
                Console.WriteLine(" For use with GlobalCommand 3 (.net)\n\n");
                Console.WriteLine(" Switches:\n ");
                Console.WriteLine(" /c - Create .txt files for all files that don't have them.");
                Console.WriteLine("      This will allow you to easily fill in the description.");
                Console.WriteLine(" /? - Displys this help information.");

                return;
            }

            if(args.Contains("/c")) {
                createDesc = true;
            }

            MD5Files m = new MD5Files();

            foreach (string fn in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                string hash = "";
                try
                {
                    File.Copy(fn, "temp");
                    hash = GetMD5("temp");
                    File.Delete("temp");
                    string desc = "";
                    if(File.Exists(fn + ".txt")) {
                        desc = File.ReadAllText(fn + ".txt");

                        if(desc.Trim() == "") {
                            Console.WriteLine("Description for " + System.IO.Path.GetFileName(fn) + " is empty.");
                        } else {

                        m.Add(System.IO.Path.GetFileName(fn), hash,desc);
                        Console.WriteLine(System.IO.Path.GetFileName(fn) + " " + hash);
                        }
                    } else {
                        if(createDesc) {
                            File.Open(fn + ".txt",FileMode.Create).Close();

                        } 
                        //Console.WriteLine("No description for " + System.IO.Path.GetFileName(fn) + " - not added");

                    }
                }
                catch (Exception)
                {
                    hash = "I/O Error";
                }
                
                
                
                
            }

            if (! Serializer.Save("update.xml", m, typeof(MD5Files)))
            {
                Console.Error.WriteLine("I/O Error");
            }
        }




        private static string GetMD5(string filename)
        {
            StringBuilder sb = new StringBuilder();
            FileStream fs = new FileStream(filename, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(fs);
            fs.Close();
            foreach (byte hex in hash)
            {
                sb.Append(hex.ToString("x2"));
            }
            return sb.ToString();
        }
    }


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
