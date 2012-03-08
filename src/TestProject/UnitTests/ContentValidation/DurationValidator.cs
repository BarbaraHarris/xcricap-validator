using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class DurationValidator : IValidator<XCRI.Validation.ContentValidation.DurationValidator>
    {
        public override XCRI.Validation.ContentValidation.DurationValidator CreateValidator()
        {
            return new XCRI.Validation.ContentValidation.DurationValidator();
        }
        public void TestExpectedDurationParse
            (
            string input,
            bool expectedPass,
            decimal years = 0,
            decimal months = 0,
            decimal weeks = 0,
            decimal days = 0,
            decimal hours = 0,
            decimal minutes = 0,
            decimal seconds = 0
            )
        {
            decimal outYears, outMonths, outWeeks, outDays, outHours, outMinutes, outSeconds;
            Assert.AreEqual<bool>
                (
                expectedPass,
                XCRI.Validation.ContentValidation.DurationValidator.TryParse(input, out outYears, out outMonths, out outWeeks, out outDays, out outHours, out outMinutes, out outSeconds)
                );
            if (false == expectedPass)
                return;
            Assert.AreEqual<decimal>(years, outYears);
            Assert.AreEqual<decimal>(months, outMonths);
            Assert.AreEqual<decimal>(weeks, outWeeks);
            Assert.AreEqual<decimal>(days, outDays);
            Assert.AreEqual<decimal>(hours, outHours);
            Assert.AreEqual<decimal>(minutes, outMinutes);
            Assert.AreEqual<decimal>(seconds, outSeconds);
        }
    }
}
