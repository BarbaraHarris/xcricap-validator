using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.XmlExceptionInterpretation
{
    [TestClass]
    public abstract class IInterpreter<A> : TestBase<XCRI.Validation.XmlExceptionInterpretation.IInterpreter, A>
        where A : XCRI.Validation.XmlExceptionInterpretation.IInterpreter
    {

        [TestMethod]
        public void TestDefaultConstructor()
        {
            var t = base.Instantiate();
                Assert.AreEqual<int>
                    (
                    t.Order,
                    0,
                    String.Format("The class {0} did not correctly default the order value to zero", base.ClassType.FullName)
                    );
        }

        [TestMethod]
        public void TestOrderPersistence()
        {
            var t = base.Instantiate();
            t.Order = 0;
            Assert.AreEqual<int>
                (
                t.Order,
                0,
                String.Format("The class {0} did not correctly persist the order information", base.ClassType.FullName)
                );
            t.Order = -1;
            Assert.AreEqual<int>
                (
                t.Order,
                -1,
                String.Format("The class {0} did not correctly persist the order information", base.ClassType.FullName)
                );
            t.Order = 1;
            Assert.AreEqual<int>
                (
                t.Order,
                1,
                String.Format("The class {0} did not correctly persist the order information", base.ClassType.FullName)
                );
        }

    }
}
