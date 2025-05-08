using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ETicaret.Infrastructure_.NewFolder
{
    public static class NameOperations
    {
        public static string CharacterRegulator(string name)

          => name.Replace("\"","")
                .Replace("!", "")
                .Replace("'", "")
                .Replace("^", "")
                .Replace("#", "")
                .Replace("+", "")
                .Replace("%", "")
                .Replace("&", "")
                .Replace("/", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace("_", "")
                .Replace("@", "")
                .Replace("€", "")
                .Replace("$", "")
                .Replace("~", "")
                .Replace(":", "")
                .Replace(";", "")
                .Replace("Ö", "o")
                .Replace("ö", "o")
                .Replace("Ü", "u")
                .Replace("ü", "u")
                .Replace("ş", "s")
                .Replace("Ş", "s")
                .Replace("ç", "c")
                .Replace("Ç", "c")
                .Replace(".", "-")
                .Replace("Ğ", "g")
                .Replace("ğ", "g")
                .Replace("i", "i")
                .Replace("İ", "i");
        
    }
}
