using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MediaTinLanh.Control
{
    public static class Control_Util
    {
        public static string RemoveSpecialCharacters(string Input)
        {
            return Regex.Replace(Input, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

        public static string[] StringSplit(string Content)
        {
            return Content.Split('\n');
        }
        public static string FixFormat(string Content)
        {
            return Content;
        }
        public static bool AsBool(this object item, bool defaultBool = default(bool))
        {
            if (item == null)
                return defaultBool;

            return new List<string>() { "yes", "y", "true" }.Contains(item.ToString().ToLower());
        }
    }
}
