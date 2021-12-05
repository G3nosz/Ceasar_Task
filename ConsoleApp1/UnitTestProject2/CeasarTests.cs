using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp1;

// a b c d e f g h i j  k  l  m  n  o  p  q  r  s  t  u  v  w  x  y  z
// 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25
namespace UnitTestProject2
{
    [TestClass]
    public class CeasarTests
    {
        [TestMethod]
        [DataRow("abcd", 3, "xyza")]
        [DataRow("nop", 3, "klm")]
        [DataRow("abcd", 13, "nopq")]
        [DataRow("ab   cd", 20, "gh   ij")]
        [DataRow("", 20, "")]
        public void Execute_ShiftLettersLeft_ResultShiftedToLeft(string input, int shift, string output)
        {
            Ceasar ca = new Ceasar();
            string result;

            ca.SetShift(shift, true);
            result = ca.Cipher(input);

            Assert.AreEqual(output, result);
        }

        [TestMethod]
        [DataRow("  abcd", 23, "  xyza")]
        [DataRow("ab cd", 10, "kl mn")]
        [DataRow("abcd ", 3, "defg ")]
        [DataRow("xwz", 3, "azc")]
        [DataRow("x wz", 10, "h gj")]
        public void Execute_ShiftLettersRight_ResultShiftedToRight(string input, int shift, string output)
        {
            Ceasar ca = new Ceasar();
            string result;

            ca.SetShift(shift, false);
            result = ca.Cipher(input);

            Assert.AreEqual(output, result);
        }

        [TestMethod]
        public void Check_LowerAndUpperInputs()
        {
            Ceasar ca = new Ceasar();
            string input = "AbC dMzZ  ";
            string output = "XyZ aJwW  ";
            string result;


            ca.SetShift(3, true);
            result = ca.Cipher(input);

            Assert.AreEqual(output, result);
        }


        [TestMethod]
        [DataRow(" A@b. CdM1 2r3", " X@y. ZaJ1 2o3")]
        [DataRow("@/1B+-*~", "@/1Y+-*~")]
        [DataRow("@/M/Ba.   ,", "@/J/Yx.   ,")]
        public void Check_OtherSymbolsAsInput(string input, string output)
        {
            Ceasar ca = new Ceasar();
            string result;

            ca.SetShift(3, true);
            result = ca.Cipher(input);

            Assert.AreEqual(output, result);
        }

        [TestMethod]
        [DataRow("ab cd", -1, "ab cd")]
        [DataRow("abcd", 27, "abcd")]
        [DataRow("a bcd ", 20, "g hij ")]
        [DataRow("abc d ", 0, "abc d ")]
        public void Check_Boundries_ReturnsSameAsInput(string input, int shift, string output)
        {
            Ceasar ca = new Ceasar();
            string result;

            ca.SetShift(shift, true);
            result = ca.Cipher(input);

            Assert.AreEqual(output, result);
        }


    }
}
