using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace TestProject.UnitTests.MessageInterpretation
{
    [TestClass]
    public abstract class IInterpretation<A> : TestBase<XCRI.Validation.MessageInterpretation.IInterpretation, A>
        where A : XCRI.Validation.MessageInterpretation.IInterpretation
    {

        [TestMethod]
        public void TestCulture()
        {
            var t = base.Instantiate();
            t.Culture = null;
            Assert.AreEqual<System.Globalization.CultureInfo>
                (
                t.Culture,
                null,
                String.Format("The class {0} did not correctly persist the culture information to null", typeof(A).FullName)
                );
            t.Culture = System.Globalization.CultureInfo.CreateSpecificCulture("de-de");
            Assert.AreEqual<System.Globalization.CultureInfo>
                (
                t.Culture,
                System.Globalization.CultureInfo.CreateSpecificCulture("de-de"),
                String.Format("The class {0} did not correctly persist the culture information to de-de", typeof(A).FullName)
            );
        }

        [TestMethod]
        public void TestHtmlInterpretation()
        {
            var t = base.Instantiate();
            t.HtmlInterpretation = null;
            Assert.AreEqual<string>
                (
                t.HtmlInterpretation,
                null,
                String.Format("The class {0} did not correctly persist the HTML interpretationto null", typeof(A).FullName)
                );
            t.HtmlInterpretation = String.Empty;
            Assert.AreEqual<string>
                (
                t.HtmlInterpretation,
                String.Empty,
                String.Format("The class {0} did not correctly persist the HTML interpretation to an empty string", typeof(A).FullName)
            );
            t.HtmlInterpretation = "<p>hello world</p>";
            Assert.AreEqual<string>
                (
                t.HtmlInterpretation,
                "<p>hello world</p>",
                String.Format("The class {0} did not correctly persist the HTML interpretation to '<p>hello world</p>'", typeof(A).FullName)
            );
        }

    }
}
