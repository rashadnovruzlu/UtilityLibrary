using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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


        //string s = "1, 2, 4, 5"; 
        //int[] array = s.ToIntArray();
        public static int[] ToIntArray(this string input)
        {
            return string.IsNullOrWhiteSpace(input) ?
            new int[] { 0 } :
            Regex.Matches(input, @"\d+").OfType<Match>().
            Select(m => int.Parse(m.Value)).ToArray();
        }



    }
}
