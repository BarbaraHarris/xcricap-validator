﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.MessageInterpretation;
using XCRI.Validation.ContentValidation;

namespace XCRI.Validation.ExtensionMethods
{
    public static class IEnumerableInterpreterExtensionMethods
    {
        public static ValidationResult Interpret
            (
            this IEnumerable<IInterpreter> interpreters,
            string validationGroup, 
            Exception exception
            )
        {
            if (null == interpreters)
                return null;
            if (null == exception)
                throw new ArgumentNullException("exception");
            var r = new ValidationResult()
            {
                Exception = exception,
                Interpretation = exception.Message,
                ValidationGroup = validationGroup
            };
            foreach (var i in interpreters)
            {
                if (null == i)
                    continue;
                string interpretation = String.Empty;
                if (
                    i.Interpret(exception, out interpretation) == InterpretationStatus.Interpreted
                    &&
                    false == String.IsNullOrWhiteSpace(interpretation)
                    )
                {
                    r.Interpretation = interpretation;
                    return r;
                }
            }
            return r;
        }
    }
}
