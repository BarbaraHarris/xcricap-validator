The latest version of the Validation Rules for XCRI-CAP 1.2 can be found at http://code.google.com/p/xcricap-validator/source/browse/src/XCRI.Validation/xml%20files/ValidationModules/XCRICAP12.xml

The rulebase basically defines a set of validators (each a combination of a validator type, an xpath selector and some optional attributes) that are run across the document to test its validity.  These validators are either defined within "document" scope (documentValidation), in which case the  validators are excecuted once per document, or within "element" scope (elementValidation), in which case the  validators are executed once per matching element.

Each rule refers to one of a small number of validators.  They're aimed to be generic although some "shorthand" validators exist (e.g. [AgeValidator](http://code.google.com/p/xcricap-validator/source/browse/src/XCRI.Validation/ContentValidation/AgeValidator.cs)) in order to make things more clear.  Each validator has a number of attributes that are common (`message`, `status`, `validationGroup`) which are used to structure the report back to the user. The available validators are:
  * [NumberValidator](http://code.google.com/p/xcricap-validator/source/browse/src/XCRI.Validation/ContentValidation/NumberValidator.cs) (validates whether the result of the xpath selector is greater than or equal to an optional minimum and less than or equal to an optional maximum)
  * [UrlValidator](http://code.google.com/p/xcricap-validator/source/browse/src/XCRI.Validation/ContentValidation/UrlValidator.cs) (validates whether the result of the xpath selector is a valid url)
  * [UniqueValidator](http://code.google.com/p/xcricap-validator/source/browse/src/XCRI.Validation/ContentValidation/UniqueValidator.cs) (validates whether the result of the xpath selector is valid within the supplied context)
  * [ManualValidator](http://code.google.com/p/xcricap-validator/source/browse/src/XCRI.Validation/ContentValidation/ManualValidator.cs) (currently highlights a manual test that the user must perform - this may need to be discussed)
  * [EmptyElementvalidator](http://code.google.com/p/xcricap-validator/source/browse/src/XCRI.Validation/ContentValidation/EmptyElementValidator.cs) (validates whether an element is - or is not - empty)
  * [StringLengthValidator](http://code.google.com/p/xcricap-validator/source/browse/src/XCRI.Validation/ContentValidation/StringLengthValidator.cs) (validates whether the length of an element's value is less than or equal to a maximum and greater than or equal to a minimum)
  * [RegularExpressionValidator](http://code.google.com/p/xcricap-validator/source/browse/src/XCRI.Validation/ContentValidation/RegularExpressionValidator.cs) (validates whether the result of an xpath selector matches a given regular expression - used for email, phone number, etc)
  * [AgeValidator](http://code.google.com/p/xcricap-validator/source/browse/src/XCRI.Validation/ContentValidation/AgeValidator.cs) (validates whether the result of an xpath selector matches the valid age element values in the wiki)