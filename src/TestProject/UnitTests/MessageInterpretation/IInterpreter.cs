using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCRI.Validation.MatchEvaluators;

namespace TestProject.UnitTests.MessageInterpretation
{
    [TestClass]
    public abstract class IInterpreter<A> : TestBase<XCRI.Validation.MessageInterpretation.IInterpreter, A>
        where A : XCRI.Validation.MessageInterpretation.IInterpreter
    {

        [TestMethod]
        public void TestDefaultConstructor()
        {
            var t = base.Instantiate();
                Assert.AreEqual<int>
                    (
                    t.Order,
                    0,
                    String.Format("The class {0} did not correctly default the order value to zero", typeof(A).FullName)
                    );
                Assert.IsNotNull
                    (
                    t.Interpretations,
                    String.Format("The class {0} incorrectly defaulted the interpretations collection to null", typeof(A).FullName)
                    );
                Assert.AreEqual<int>
                    (
                    t.Interpretations.Count,
                    0,
                    String.Format("The class {0} did not default the interpretations collection to empty", typeof(A).FullName)
                    );
                Assert.IsNotNull
                    (
                    t.MatchEvaluators,
                    String.Format("The class {0} incorrectly defaulted the evaluators collection to null", typeof(A).FullName)
                    );
                Assert.AreEqual<int>
                    (
                    t.MatchEvaluators.Count,
                    0,
                    String.Format("The class {0} did not default the evaluators collection to empty", typeof(A).FullName)
                    );
        }

        [TestMethod]
        public void TestInjectableConstructor()
        {
            List<XCRI.Validation.MatchEvaluators.IMatchEvaluator> matchEvaluators
                = new List<XCRI.Validation.MatchEvaluators.IMatchEvaluator>();
            matchEvaluators.Add(new XCRI.Validation.MatchEvaluators.NumberMatchEvaluator(0, NumberMatchType.EqualTo));
            List<XCRI.Validation.MessageInterpretation.IInterpretation> interpreters
                = new List<XCRI.Validation.MessageInterpretation.IInterpretation>();
            interpreters.Add(new XCRI.Validation.MessageInterpretation.Interpretation());
            var t = base.Instantiate(matchEvaluators, interpreters);
            Assert.IsNotNull(t);
            Assert.IsNotNull(t.MatchEvaluators);
            Assert.IsNotNull(t.Interpretations);
            Assert.AreEqual<int>(t.Order, 0);
            Assert.AreEqual<int>(t.MatchEvaluators.Count, matchEvaluators.Count);
            Assert.AreEqual<int>(t.Interpretations.Count, interpreters.Count);
        }

        [TestMethod, ExpectedException(typeof(System.Reflection.TargetInvocationException))]
        public void TestInjectableConstructor_MatchEvaluatorsNull()
        {
            List<XCRI.Validation.MessageInterpretation.IInterpretation> interpreters
                = new List<XCRI.Validation.MessageInterpretation.IInterpretation>();
            interpreters.Add(new XCRI.Validation.MessageInterpretation.Interpretation());
            var t = base.Instantiate
                (
                (List<XCRI.Validation.MatchEvaluators.IMatchEvaluator>)null, 
                interpreters
                );
        }

        [TestMethod, ExpectedException(typeof(System.Reflection.TargetInvocationException))]
        public void TestInjectableConstructor_InterpretationsNull()
        {
            List<XCRI.Validation.MatchEvaluators.IMatchEvaluator> matchEvaluators
                = new List<XCRI.Validation.MatchEvaluators.IMatchEvaluator>();
            matchEvaluators.Add(new XCRI.Validation.MatchEvaluators.NumberMatchEvaluator(0, NumberMatchType.EqualTo));
            var t = base.Instantiate
                (
                matchEvaluators,
                (List<XCRI.Validation.MessageInterpretation.IInterpretation>)null
                );
        }

        [TestMethod]
        public void TestOrder()
        {
            var t = base.Instantiate();
            t.Order = 0;
            Assert.AreEqual<int>
                (
                t.Order,
                0,
                String.Format("The class {0} did not correctly persist the order information", typeof(A).FullName)
                );
            t.Order = -1;
            Assert.AreEqual<int>
                (
                t.Order,
                -1,
                String.Format("The class {0} did not correctly persist the order information", typeof(A).FullName)
                );
            t.Order = 1;
            Assert.AreEqual<int>
                (
                t.Order,
                1,
                String.Format("The class {0} did not correctly persist the order information", typeof(A).FullName)
                );
        }

    }
}
