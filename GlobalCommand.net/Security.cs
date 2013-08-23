using System;
using System.Reflection;

namespace GlobalCommand
{
    class Security
    {


        private static string _ProgramKey = "";

        public static string SecurityKey
        {
            get
            {
                if (_ProgramKey == "")
                {
                    _ProgramKey = Security.getKey(typeof(Program));
                }
                return _ProgramKey;
            }
        }

        public static string getKey(Type t)
        {
            Assembly asm = Assembly.GetAssembly(t);
            return getKey(asm);
        }

        public static string getKey(Assembly asm)
        {
            if (asm != null)
            {
                AssemblyName asmName = asm.GetName();
                byte[] key = asmName.GetPublicKey();
                string s = "";
                for (int i = 0; i < key.Length; i++)
                {
                    s += key[i];
                }
                return s;

            }
            return "";
        }
    }
}
