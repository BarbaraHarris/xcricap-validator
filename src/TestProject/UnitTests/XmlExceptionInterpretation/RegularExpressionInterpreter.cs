using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.XmlExceptionInterpretation
{
    [TestClass]
    public class RegularExpressionInterpreter : IInterpreter<XCRI.Validation.XmlExceptionInterpretation.RegularExpressionInterpreter>
    {
        [TestMethod]
        public void TestPatternPersistence()
        {
            var t = base.Instantiate();
            t.Pattern = null;
            Assert.AreEqual<string>
                (
                t.Pattern,
                null,
                String.Format("The class {0} did not correctly persist the pattern information", base.ClassType.FullName)
                );
            t.Pattern = "test pattern";
            Assert.AreEqual<string>
                (
                t.Pattern,
                "test pattern",
                String.Format("The class {0} did not correctly persist the pattern information", base.ClassType.FullName)
                );
            t.Pattern = "test pattern 2";
            Assert.AreEqual<string>
                (
                t.Pattern,
                "test pattern 2",
                String.Format("The class {0} did not correctly persist the pattern information", base.ClassType.FullName)
                );
        }

        [TestMethod]
        public void TestInvertPersistence()
        {
            var t = base.Instantiate();
            t.Invert = false;
            Assert.AreEqual<bool>
                (
                t.Invert,
                false,
                String.Format("The class {0} did not correctly persist the invert information", base.ClassType.FullName)
                );
            t.Invert = true;
            Assert.AreEqual<bool>
                (
                t.Invert,
                true,
                String.Format("The class {0} did not correctly persist the invert information", base.ClassType.FullName)
                );
            t.Invert = false;
            Assert.AreEqual<bool>
                (
                t.Invert,
                false,
                String.Format("The class {0} did not correctly persist the invert information", base.ClassType.FullName)
                );
        }

        [TestMethod]
        public void WillFail()
        {
            Assert.Fail("This failure is to make sure I don't forget to sort out the XmlExceptionInterpretation priot to committing");
        }
    }
}
