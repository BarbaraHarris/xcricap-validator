using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class RegularExpressionValidator
    {
        [TestMethod]
        public void Valid_SubjectOnlyOneKeywordOrPhrase_SingleWord()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "hello",
                Resources.ContentValidation.RegularExpressionValidator.Common.SubjectOnlyOneKeywordOrPhrase
                ));
        }
        [TestMethod]
        public void Valid_SubjectOnlyOneKeywordOrPhrase_SingleWordWithNumbers()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "H600",
                Resources.ContentValidation.RegularExpressionValidator.Common.SubjectOnlyOneKeywordOrPhrase
                ));
        }
        [TestMethod]
        public void Valid_SubjectOnlyOneKeywordOrPhrase_TwoWordsWithSpace()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "hello world",
                Resources.ContentValidation.RegularExpressionValidator.Common.SubjectOnlyOneKeywordOrPhrase
                ));
        }
        [TestMethod]
        public void Invalid_SubjectOnlyOneKeywordOrPhrase_TwoWordsWithCommaSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "hello, world",
                Resources.ContentValidation.RegularExpressionValidator.Common.SubjectOnlyOneKeywordOrPhrase
                ));
        }
        [TestMethod]
        public void Invalid_SubjectOnlyOneKeywordOrPhrase_TwoWordsWithComma()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "hello,world",
                Resources.ContentValidation.RegularExpressionValidator.Common.SubjectOnlyOneKeywordOrPhrase
                ));
        }
        [TestMethod]
        public void Invalid_SubjectOnlyOneKeywordOrPhrase_TwoWordsWithSemiColonSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "hello; world",
                Resources.ContentValidation.RegularExpressionValidator.Common.SubjectOnlyOneKeywordOrPhrase
                ));
        }
        [TestMethod]
        public void Invalid_SubjectOnlyOneKeywordOrPhrase_TwoWordsWithSemiColon()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "hello;world",
                Resources.ContentValidation.RegularExpressionValidator.Common.SubjectOnlyOneKeywordOrPhrase
                ));
        }
        [TestMethod]
        public void Invalid_SubjectOnlyOneKeywordOrPhrase_TwoWordsWithPipeSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "hello| world",
                Resources.ContentValidation.RegularExpressionValidator.Common.SubjectOnlyOneKeywordOrPhrase
                ));
        }
        [TestMethod]
        public void Invalid_SubjectOnlyOneKeywordOrPhrase_TwoWordsWithPipe()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "hello|world",
                Resources.ContentValidation.RegularExpressionValidator.Common.SubjectOnlyOneKeywordOrPhrase
                ));
        }
    }
}
