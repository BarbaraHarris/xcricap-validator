using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.XmlRetrieval;
using System.Xml;

namespace XCRI.Validation.ContentValidation
{
    public class ValidatorFactory : IValidatorFactory
    {

        public Logging.ILog Log { get; private set; }
        public ISource<Uri> UriSource { get; protected set; }

        public ValidatorFactory
            (
            Logging.ILog log,
            ISource<Uri> uriSource
            )
            : base()
        {
            if (null == uriSource)
                throw new ArgumentNullException("uriSource");
            this.UriSource = uriSource;
                this.Log = log;
        }

        #region IValidatorFactory Members

        public T GetValidator<T>
            (
            )
            where T : class, IValidator
        {
            IValidator v = null;
            if (typeof(T) == typeof(PositiveIntegerValidator))
                v = new PositiveIntegerValidator(this.Log);
            if (typeof(T) == typeof(UrlValidator))
                v = new UrlValidator(this.Log);
            if (typeof(T) == typeof(UniqueValidator))
                v = new UniqueValidator(this.Log);
            if (typeof(T) == typeof(EmptyElementValidator))
                v = new EmptyElementValidator(this.Log);
            if (typeof(T) == typeof(NumberValidator))
                v = new NumberValidator(this.Log);
            if (typeof(T) == typeof(ManualValidator))
                v = new ManualValidator(this.Log);
            if (typeof(T) == typeof(StringLengthValidator))
                v = new StringLengthValidator(this.Log);
            if (typeof(T) == typeof(RegularExpressionValidator))
                v = new RegularExpressionValidator(this.Log);
            if (typeof(T) == typeof(PostCodeValidator))
                v = new PostCodeValidator(this.Log);
            if (typeof(T) == typeof(UKTelephoneNumberValidator))
                v = new UKTelephoneNumberValidator(this.Log);
            if (typeof(T) == typeof(AgeValidator))
                v = new AgeValidator(this.Log);
            if (typeof(T) == typeof(EmailAddressValidator))
                v = new EmailAddressValidator(this.Log);
            if (typeof(T) == typeof(VDEXValidator))
                v = new VDEXValidator(this.Log, this.UriSource);
            if (typeof(T) == typeof(LanguageValidator))
                v = new LanguageValidator(this.Log);
            if (typeof(T) == typeof(NumberPerLanguageValidator))
                v = new NumberPerLanguageValidator(this.Log);
            if (typeof(T) == typeof(DurationValidator))
                v = new DurationValidator(this.Log);
            if(v == null)
                throw new ArgumentException("The supplied validator type '" + typeof(T).FullName+ "' could not be loaded");
            return v as T;
        }

        #endregion
    }
}
