using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace URLshortner.Models
{
    public class Model
    {
        private string path = @"~\App_Data\URLinfo.txt";
        public string ConvertNSave(string longURL)
        {
            string result = ReadNExtract(longURL);
            if(result == "Not Found")
            {
                path = System.Web.HttpContext.Current.Server.MapPath(path);
                MD5 obj = MD5.Create();
                byte[] URLbytes = Encoding.ASCII.GetBytes(longURL);
                byte[] MD5hash = obj.ComputeHash(URLbytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < MD5hash.Length;i++)
                {
                    sb.Append(MD5hash[i].ToString("X2"));
                }
                File.AppendAllText(path,longURL + "\t" + sb.ToString()+Environment.NewLine);
                return sb.ToString();
            }
            else
            {
                return result;
            }
        }

        public string ReadNExtract(string shortURL)
        {
            foreach(string line in File.ReadLines(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                if(line.Contains(shortURL))
                {
                    string matched = line.Replace(shortURL, "");
                    return matched;
                }
            }
            return "Not Found";
        }
    }
}