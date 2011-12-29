using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.ContentValidation
{
    public class ValidatorFactory : IValidatorFactory
    {

        public List<Logging.ILog> Logs { get; private set; }
        public List<Logging.ITimedLog> TimedLogs { get; private set; }

        public ValidatorFactory
            (
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs
            )
            : base()
        {
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

            if (typeof(T) == typeof(UrlValidator))
                return new UrlValidator(null, null, null, null, ValidationStatus.Exception, this.Logs, this.TimedLogs) as T;
            if (typeof(T) == typeof(UniqueValidator))
                return new UniqueValidator(null, null, null, null, ValidationStatus.Exception, this.Logs, this.TimedLogs) as T;
            if (typeof(T) == typeof(EmptyElementValidator))
                return new EmptyElementValidator(null, null, null, null, ValidationStatus.Exception, this.Logs, this.TimedLogs) as T;
            if (typeof(T) == typeof(NumberValidator))
                return new NumberValidator(null, null, null, null, ValidationStatus.Exception, this.Logs, this.TimedLogs) as T;
            if (typeof(T) == typeof(ManualValidator))
                return new ManualValidator(null, null, null, null, ValidationStatus.Exception, this.Logs, this.TimedLogs) as T;
            if (typeof(T) == typeof(StringLengthValidator))
                return new StringLengthValidator(null, null, null, null, ValidationStatus.Exception, this.Logs, this.TimedLogs) as T;
            if (typeof(T) == typeof(RegularExpressionValidator))
                return new RegularExpressionValidator(null, null, null, null, ValidationStatus.Exception, this.Logs, this.TimedLogs) as T;
            if (typeof(T) == typeof(AgeValidator))
                return new AgeValidator(null, null, null, null, ValidationStatus.Exception, this.Logs, this.TimedLogs) as T;

            throw new ArgumentException("The supplied validator type '" + typeof(T).FullName+ "' could not be loaded");
        }

        #endregion
    }
}
