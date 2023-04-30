using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westwind.Base64
{
    public  class Base64Converter
    {
        public static string Encode(byte[] data)
        {
            return Convert.ToBase64String(data);
        }


        public static string Encode(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException(filename + " not found for base64 Encoding.");
            }

            byte[] data =File.ReadAllBytes(filename);
            return Encode(data);
        }

        
        public static string EncodeFromString(string str,  Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            byte[] data = encoding.GetBytes(str);
            return Encode(data);
        }

        public static byte[] Decode(string base64)
        {
            return Convert.FromBase64String(base64);
        }

        public static string DecodeToString(string base64, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            
            var data = Decode(base64);
            return encoding.GetString(data);
        }



        public static bool DecodeToFile(string base64, string filename)
        {
            
            var data = Convert.FromBase64String(base64);
            File.WriteAllBytes(filename, data);
            
            return true;
        }

    }
}
