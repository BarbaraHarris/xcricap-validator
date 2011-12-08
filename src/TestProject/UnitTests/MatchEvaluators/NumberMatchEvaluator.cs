using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using me = XCRI.Validation.MatchEvaluators;

namespace TestProject.UnitTests.MatchEvaluators
{
    [TestClass]
    public class NumberMatchEvaluator
    {

        #region Equal to

        [TestMethod]
        public void TestNumberEqualTo_ValidInteger()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.EqualTo);
            Assert.IsTrue(nme.IsMatch("1"));
        }
        [TestMethod]
        public void TestNumberEqualTo_ValidDecimal()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.EqualTo);
            Assert.IsTrue(nme.IsMatch("1.0"));
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestNumberEqualTo_InvalidNullValue()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.EqualTo);
            nme.IsMatch(null);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestNumberEqualTo_InvalidBlankStringValue()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.EqualTo);
            nme.IsMatch("");
        }
        [TestMethod]
        public void TestNumberEqualTo_InvalidInteger()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.EqualTo);
            Assert.IsFalse(nme.IsMatch("2"));
        }
        [TestMethod]
        public void TestNumberEqualTo_InvalidDecimal()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.EqualTo);
            Assert.IsFalse(nme.IsMatch("2.0"));
        }

        #endregion

        #region Less than

        [TestMethod]
        public void TestNumberLessThan_ValidInteger()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.LessThan);
            Assert.IsTrue(nme.IsMatch("0"));
        }
        [TestMethod]
        public void TestNumberLessThan_ValidDecimal()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.LessThan);
            Assert.IsTrue(nme.IsMatch("0.9"));
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestNumberLessThan_InvalidNullValue()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.LessThan);
            nme.IsMatch(null);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestNumberLessThan_InvalidBlankStringValue()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.LessThan);
            nme.IsMatch("");
        }
        [TestMethod]
        public void TestNumberLessThan_InvalidInteger()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.LessThan);
            Assert.IsFalse(nme.IsMatch("2"));
        }
        [TestMethod]
        public void TestNumberLessThan_InvalidDecimal()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.LessThan);
            Assert.IsFalse(nme.IsMatch("1.1"));
        }

        #endregion

        #region Less than

        [TestMethod]
        public void TestNumberGreaterThan_ValidInteger()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.GreaterThan);
            Assert.IsTrue(nme.IsMatch("2"));
        }
        [TestMethod]
        public void TestNumberGreaterThan_ValidDecimal()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.GreaterThan);
            Assert.IsTrue(nme.IsMatch("1.9"));
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestNumberGreaterThan_InvalidNullValue()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.GreaterThan);
            nme.IsMatch(null);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestNumberGreaterThan_InvalidBlankStringValue()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.GreaterThan);
            nme.IsMatch("");
        }
        [TestMethod]
        public void TestNumberGreaterThan_InvalidInteger()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.GreaterThan);
            Assert.IsFalse(nme.IsMatch("1"));
        }
        [TestMethod]
        public void TestNumberGreaterThan_InvalidDecimal()
        {
            me.NumberMatchEvaluator nme = new me.NumberMatchEvaluator(1m, me.NumberMatchType.GreaterThan);
            Assert.IsFalse(nme.IsMatch("0.9"));
        }

        #endregion
    }
}
