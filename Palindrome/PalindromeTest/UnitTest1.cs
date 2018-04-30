using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome;

namespace PalindromeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] str = { "racecar", "Racecar", "1221", "never Odd, or Even.", "1231"};
            bool expected = true;

            PalindromeCheck checkP = new PalindromeCheck();

            Assert.AreEqual(expected, checkP.IsPalindrome("1231"));

            //for (int i = 0; i < str.Length; i++)
            //{
            //    bool actual = checkP.IsPalindrome(str[i]);
            //    if (i == 4)
            //    {
            //        expected = false;
            //    }
            //    Assert.AreEqual(expected, actual);
            //}
        }
    }
}
