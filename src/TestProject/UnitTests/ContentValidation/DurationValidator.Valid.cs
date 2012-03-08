using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class DurationValidator : IValidator<XCRI.Validation.ContentValidation.DurationValidator>
    {

        #region PnYnMnDTnHnMnS

        [TestMethod]
        public void Valid_P3Y6M4DT12H30M5S()
        {
            this.TestExpectedDurationParse
                (
                "P3Y6M4DT12H30M5S",
                true,
                years: 3,
                months: 6,
                days: 4,
                hours: 12,
                minutes: 30,
                seconds: 5
                );
        }
        [TestMethod]
        public void Valid_P23DT23H()
        {
            this.TestExpectedDurationParse
                (
                "P23DT23H",
                true,
                days: 23,
                hours: 23
                );
        }
        [TestMethod]
        public void Valid_P4Y()
        {
            this.TestExpectedDurationParse
                (
                "P4Y",
                true,
                years: 4
                );
        }
        [TestMethod]
        public void Valid_PT1M()
        {
            this.TestExpectedDurationParse
                (
                "PT1M",
                true,
                minutes: 1
                );
        }
        [TestMethod]
        public void Valid_PT36H()
        {
            this.TestExpectedDurationParse
                (
                "PT36H",
                true,
                hours: 36
                );
        }
        [TestMethod]
        public void Valid_P1DT12H()
        {
            this.TestExpectedDurationParse
                (
                "P1DT12H",
                true,
                days: 1,
                hours: 12
                );
        }
        [TestMethod]
        public void Valid_HalfYearFullStop()
        {
            this.TestExpectedDurationParse
                (
                "P0.5Y",
                true,
                years: 0.5M
                );
        }
        [TestMethod]
        public void Valid_HalfYearComma()
        {
            this.TestExpectedDurationParse
                (
                "P0,5Y",
                true,
                years: 0.5M
                );
        }

        #endregion

        #region PnW

        [TestMethod]
        public void Valid_P5W()
        {
            this.TestExpectedDurationParse
                (
                "P5W",
                true,
                weeks: 5M
                );
        }
        [TestMethod]
        public void Valid_HalfWeekFullStop()
        {
            this.TestExpectedDurationParse
                (
                "P0.5W",
                true,
                weeks: 0.5M
                );
        }
        [TestMethod]
        public void Valid_HalfWeekComma()
        {
            this.TestExpectedDurationParse
                (
                "P0,5W",
                true,
                weeks: 0.5M
                );
        }

        #endregion

        #region P[YYYY]-[MM]-[DD]T[hh]:[mm]:[ss]

        [TestMethod]
        public void Valid_P00030604T123005Extended()
        {
            this.TestExpectedDurationParse
                (
                "P0003-06-04T12:30:05",
                true,
                years: 3,
                months: 6,
                days: 4,
                hours: 12,
                minutes: 30,
                seconds: 5
                );
        }
        [TestMethod]
        public void Valid_P00030604T123005()
        {
            this.TestExpectedDurationParse
                (
                "P00030604T123005",
                true,
                years: 3,
                months: 6,
                days: 4,
                hours: 12,
                minutes: 30,
                seconds: 5
                );
        }

        #endregion

        #region P<date>T<time>

        #region Date on its own

        [TestMethod]
        public void P00020101()
        {
            this.TestExpectedDurationParse
                (
                "P00020101",
                true,
                years: 2,
                months: 1,
                days: 1
                );
        }

        [TestMethod]
        public void P00020101_Dashes()
        {
            this.TestExpectedDurationParse
                (
                "P0002-01-01",
                true,
                years: 2,
                months: 1,
                days: 1
                );
        }

        [TestMethod]
        public void P000201_Dashes()
        {
            this.TestExpectedDurationParse
                (
                "P0002-01",
                true,
                years: 2,
                months: 1
                );
        }

        [TestMethod]
        public void P0001W01_Dashes()
        {
            this.TestExpectedDurationParse
                (
                "P0001-W01",
                true,
                years: 1,
                weeks: 1
                );
        }

        [TestMethod]
        public void P0001W01()
        {
            this.TestExpectedDurationParse
                (
                "P0001W01",
                true,
                years: 1,
                weeks: 1
                );
        }

        [TestMethod]
        public void P0001W012_Dashes()
        {
            this.TestExpectedDurationParse
                (
                "P0001-W01-2",
                true,
                years: 1,
                weeks: 1,
                days: 2
                );
        }

        [TestMethod]
        public void P0001W012()
        {
            this.TestExpectedDurationParse
                (
                "P0001W012",
                true,
                years: 1,
                weeks: 1,
                days: 2
                );
        }

        #endregion

        #endregion

    }
}
