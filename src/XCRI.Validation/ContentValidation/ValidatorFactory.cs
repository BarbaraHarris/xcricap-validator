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

        public List<Logging.ILog> Logs { get; private set; }
        public List<Logging.ITimedLog> TimedLogs { get; private set; }
        public ISource<Uri> UriSource { get; protected set; }

        public ValidatorFactory
            (
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs,
            ISource<Uri> uriSource
            )
            : base()
        {
            if (null == uriSource)
                throw new ArgumentNullException("uriSource");
            this.UriSource = uriSource;
            if (null == logs)
                this.Logs = new List<Logging.ILog>();
            else
                this.Logs = new List<Logging.ILog>(logs);
            if (null == timedLogs)
                this.TimedLogs = new List<Logging.ITimedLog>();
            else
                this.TimedLogs = new List<Logging.ITimedLog>(timedLogs);
        }

        #region IValidatorFactory Members

        public T GetValidator<T>
            (
            )
            where T : class, IValidator
        {
            IValidator v = null;
            if (typeof(T) == typeof(PositiveIntegerValidator))
                v = new PositiveIntegerValidator();
            if (typeof(T) == typeof(UrlValidator))
                v = new UrlValidator();
            if (typeof(T) == typeof(UniqueValidator))
                v = new UniqueValidator();
            if (typeof(T) == typeof(EmptyElementValidator))
                v = new EmptyElementValidator();
            if (typeof(T) == typeof(NumberValidator))
                v = new NumberValidator();
            if (typeof(T) == typeof(ManualValidator))
                v = new ManualValidator();
            if (typeof(T) == typeof(StringLengthValidator))
                v = new StringLengthValidator();
            if (typeof(T) == typeof(RegularExpressionValidator))
                v = new RegularExpressionValidator();
            if (typeof(T) == typeof(PostCodeValidator))
                v = new PostCodeValidator();
            if (typeof(T) == typeof(UKTelephoneNumberValidator))
                v = new UKTelephoneNumberValidator();
            if (typeof(T) == typeof(AgeValidator))
                v = new AgeValidator();
            if (typeof(T) == typeof(EmailAddressValidator))
                v = new EmailAddressValidator();
            if (typeof(T) == typeof(VDEXValidator))
                v = new VDEXValidator(this.UriSource);
            if (typeof(T) == typeof(LanguageValidator))
                v = new LanguageValidator();
            if (typeof(T) == typeof(NumberPerLanguageValidator))
                v = new NumberPerLanguageValidator();
            if (typeof(T) == typeof(DurationValidator))
                v = new DurationValidator();
            if(v == null)
                throw new ArgumentException("The supplied validator type '" + typeof(T).FullName+ "' could not be loaded");
            if (null != this.Logs)
                foreach (var l in this.Logs)
                    v.Logs.Add(l);
            if (null != this.TimedLogs)
                foreach (var l in this.TimedLogs)
                    v.TimedLogs.Add(l);
            return v as T;
        }

        #endregion
    }
}
