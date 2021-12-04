using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp1;

namespace UnitTestProject2
{
    [TestClass]
    public class CeasarTests
    {
        [TestMethod]
        [DataRow("abcd", 3, "xyza")]
        [DataRow("nop", 3, "klm")]
        [DataRow("abcd", 13, "nopq")]
        [DataRow("abcd", 20, "ghij")]
        public void Execute_ShiftLettersLeft_ResultShiftedToLeft(string input, int shift, string output)
        {
            Ceasar ca = new Ceasar();
            string result;


            ca.SetShift(shift, true);
            result = ca.Cipher(input);

            Assert.AreEqual(output, result);
        }

        [TestMethod]
        [DataRow("abcd", 23, "xyza")]
        [DataRow("abcd", 10, "klmn")]
        [DataRow("abcd", 3, "defg")]
        [DataRow("xwz", 3, "azc")]
        [DataRow("xwz", 10, "hgj")]
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
            string input = "AbCdMzZ";
            string output = "XyZaJwW";
            string result;


            ca.SetShift(3, true);
            result = ca.Cipher(input);

            Assert.AreEqual(output, result);
        }


        [TestMethod]
        [DataRow("A@b.CdM12r3", "X@y.ZaJ12o3")]
        [DataRow("@/1B+-*~", "@/1Y+-*~")]
        [DataRow("@/M/Ba.,", "@/J/Yx.,")]
        public void Check_OtherSymbolsAsInput(string input, string output)
        {
            Ceasar ca = new Ceasar();
            string result;

            ca.SetShift(3, true);
            result = ca.Cipher(input);

            Assert.AreEqual(output, result);
        }

        [TestMethod]
        [DataRow("abcd", -1, "abcd")]
        [DataRow("abcd", 27, "abcd")]
        [DataRow("abcd", 20, "ghij")]
        [DataRow("abcd", 0, "abcd")]
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
