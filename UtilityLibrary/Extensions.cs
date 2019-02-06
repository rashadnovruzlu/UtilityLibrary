using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace UtilityLibrary
{
    static public class Extensions
    {
        //Example: 
        //Standard ==> IF (i == 1 || i == 2 || i == 3 || i == 4) {...}
        //With this method ==> IF (i.Or(1,2,3,4)) {...}
        public static bool Or(this int j, params int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (j == array[i]) return true;
            }

            return false;
        }

        //Standard ==> IF (s == "AB" || s == "BC" || s == "CD" || s == "DE") {...}
        //With this method ==> IF (s.Or("AB","BC","CD","DE")) {...}
        public static bool Or(this string j, params string[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (j == array[i]) return true;
            }

            return false;
        }

        //Standard ==> IF (s != "AB" && s !=  "BC" && s != "CD" && s != "DE") {...}
        //With this method ==> IF (s.Not("AB","BC","CD","DE")) {...}
        public static bool Not(this int? j, params int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (j == array[i]) return false;
            }

            return true;
        }

        //string s = "1, 2, 4, 5"; 
        //int[] array = s.ToIntArray();
        public static int[] ToIntArray(this string input)
        {
            return string.IsNullOrWhiteSpace(input) ?
            new int[] { 0 } :
            Regex.Matches(input, @"\d+").OfType<Match>().
            Select(m => int.Parse(m.Value)).ToArray();
        }

        //string s="<span class="_kao"><h1 id="seo_h1_tag"><a class="_64-f" href="https://www.facebook.com/CProgramlashdirmaDili/"><span>C# programlashdirma dili</span></a></h1></span>"
        //string plainText = htmlText.RemoveHTMLTags();
        //plainText is equal "C# proqramlasdirma dili"
        public static string RemoveHTMLTags(this string content)
        {
            var cleaned = string.Empty;
            try
            {
                StringBuilder textOnly = new StringBuilder();
                using (var reader = System.Xml.XmlReader.Create(new StringReader("<xml>" + content + "</xml>")))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == System.Xml.XmlNodeType.Text)
                            textOnly.Append(reader.ReadContentAsString());
                    }
                }
                cleaned = textOnly.ToString();
            }
            catch
            {
                string textOnly = string.Empty;
                Regex tagRemove = new Regex(@"<[^>]*(>|$)");
                Regex compressSpaces = new Regex(@"[\s\r\n]+");
                textOnly = tagRemove.Replace(content, string.Empty);
                textOnly = compressSpaces.Replace(textOnly, " ");
                cleaned = textOnly;
            }
            cleaned = cleaned.Replace("&nbsp;", " ");

            return cleaned;
        }

    }
}
