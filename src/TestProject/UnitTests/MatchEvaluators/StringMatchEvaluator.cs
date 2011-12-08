using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using me = XCRI.Validation.MatchEvaluators;


namespace TestProject.UnitTests.MatchEvaluators
{
    [TestClass]
    public class StringMatchEvaluator
    {

        #region Equal to

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestStringEqualTo_InvalidNullValue()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Exact);
            nme.IsMatch(null);
        }

        [TestMethod]
        public void TestStringEqualTo_InvalidNullMatchToValue()
        {
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(null, me.StringMatchType.Exact);
            Assert.IsFalse(nme.IsMatch(String.Empty));
        }

        [TestMethod]
        public void TestStringEqualTo_ValidStringCaseSensitive()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Exact);
            nme.CaseSensitive = true;
            Assert.IsTrue(nme.IsMatch(checkFor));
        }

        [TestMethod]
        public void TestStringEqualTo_InValidStringCaseSensitive()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Exact);
            nme.CaseSensitive = true;
            Assert.IsFalse(nme.IsMatch(checkFor.ToUpper()));
            Assert.IsFalse(nme.IsMatch(checkFor.ToLower()));
        }

        [TestMethod]
        public void TestStringEqualTo_ValidStringCaseInsensitive()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Exact);
            nme.CaseSensitive = false;
            Assert.IsTrue(nme.IsMatch(checkFor));
        }

        [TestMethod]
        public void TestStringEqualTo_InValidStringCaseInsensitive()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Exact);
            nme.CaseSensitive = false;
            Assert.IsTrue(nme.IsMatch(checkFor.ToUpper()));
            Assert.IsTrue(nme.IsMatch(checkFor.ToLower()));
        }

        [TestMethod]
        public void TestStringEqualTo_InvalidString()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Exact);
            Assert.IsFalse(nme.IsMatch(checkFor + "boo"));
        }

        #endregion

        #region Prefix

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestStringPrefix_InvalidNullValue()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Prefix);
            nme.IsMatch(null);
        }

        [TestMethod]
        public void TestStringPrefix_InvalidNullMatchToValue()
        {
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(null, me.StringMatchType.Prefix);
            Assert.IsFalse(nme.IsMatch(String.Empty));
        }

        [TestMethod]
        public void TestStringPrefix_ValidStringCaseSensitive()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Prefix);
            nme.CaseSensitive = true;
            Assert.IsTrue(nme.IsMatch(checkFor.Substring(0, 10)));
        }

        [TestMethod]
        public void TestStringPrefix_InvalidStringCaseSensitive()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Prefix);
            nme.CaseSensitive = true;
            Assert.IsFalse(nme.IsMatch(checkFor.ToUpper().Substring(0, 10)));
        }

        [TestMethod]
        public void TestStringPrefix_ValidStringCaseInsensitive()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Prefix);
            nme.CaseSensitive = false;
            Assert.IsTrue(nme.IsMatch(checkFor.Substring(0, 10)));
            Assert.IsTrue(nme.IsMatch(checkFor.ToLower().Substring(0, 10)));
            Assert.IsTrue(nme.IsMatch(checkFor.ToUpper().Substring(0, 10)));
        }

        #endregion

        #region Suffix

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestStringSuffix_InvalidNullValue()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Suffix);
            nme.IsMatch(null);
        }

        [TestMethod]
        public void TestStringSuffix_InvalidNullMatchToValue()
        {
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(null, me.StringMatchType.Suffix);
            Assert.IsFalse(nme.IsMatch(String.Empty));
        }

        [TestMethod]
        public void TestStringSuffix_ValidStringCaseSensitive()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            var checkAgainst = "to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Suffix);
            nme.CaseSensitive = true;
            Assert.IsTrue(nme.IsMatch(checkAgainst));
        }

        [TestMethod]
        public void TestStringSuffix_InvalidStringCaseSensitive()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            var checkAgainst = "to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Suffix);
            nme.CaseSensitive = true;
            Assert.IsFalse(nme.IsMatch(checkAgainst.ToUpper()));
        }

        [TestMethod]
        public void TestStringSuffix_ValidStringCaseInsensitive()
        {
            var checkFor = "hello world, I am a string to be tested against!";
            var checkAgainst = "to be tested against!";
            me.StringMatchEvaluator nme = new me.StringMatchEvaluator(checkFor, me.StringMatchType.Suffix);
            nme.CaseSensitive = false;
            Assert.IsTrue(nme.IsMatch(checkAgainst));
            Assert.IsTrue(nme.IsMatch(checkAgainst.ToLower()));
            Assert.IsTrue(nme.IsMatch(checkAgainst.ToUpper()));
        }

        #endregion

    }
}
