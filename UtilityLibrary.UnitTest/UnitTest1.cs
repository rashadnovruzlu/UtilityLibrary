using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilityLibrary.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string htmlText = string.Empty;

        [TestInitialize]
        public void Initialize()
        {
            htmlText = @"<span class=""_kao""><h1 id=""seo_h1_tag"">
            <a class=""_64-f"" href=""https://www.facebook.com/CProgramlashdirmaDili/"">
            <span>C# programlashdirma dili</span></a></h1></span>";
        }


        [TestMethod]
        public void TestMethod_int_Or()
        {
            int i = 10;

            Assert.AreEqual(i.Or(5, 7, 8, 10), true);

            Assert.AreEqual(i.Or(20, 60, 14, 75), false);
        }

        [TestMethod]
        public void TestMethod_string_Or()
        {
            string s = "BC";

            Assert.AreEqual(s.Or("AB", "BC", "CD", "DE"), true);

            Assert.AreEqual(s.Or("XB", "XC", "XD", "XE"), false);
        }

        [TestMethod]
        public void TestMethod_ToIntArray()
        {
            string s = "1, 2, 4 , 5";

            int[] array = s.ToIntArray();

            Assert.AreEqual(array.Length, 4);

            Assert.AreEqual(array[0], 1);

            Assert.AreEqual(array[3], 5);
        }

        [TestMethod]
        public void TestMethod_RemoveHTMLTags()
        {
            string plainText = htmlText.RemoveHTMLTags();

            Assert.AreEqual(plainText.IndexOf("<h1"), -1);

            Assert.AreEqual(plainText.IndexOf("</span>"), -1);

        }




    }
}
