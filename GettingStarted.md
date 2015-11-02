# Introduction #

The validator library is a .NET 4.0 library that can be used to validate feeds that are being developed.  You can download the library either using one of the release versions within the [Downloads](http://code.google.com/p/xcricap-validator/downloads/list) section or by getting a local copy of the project from the [Source](http://code.google.com/p/xcricap-validator/source/checkout) section.

However, by far and away the easiest way to use the validator library is to use the online version at http://validator.xcri.co.uk.  This does not require any programming experience and can be run against both feeds in development (e.g. allowing you to upload them from a PC) and online feeds (e.g. a live URL).

# Example applications #

Within both the source code and downloadable versions there are example applications that show how to instantiate the validation objects, load them with a validation rule base, then validate a feed.  It is recommended that these applications are the starting point for most applications.

# Validation Overview #

The validator library validates an XCRI-CAP document in three stages:
  1. Checking the validity of the XML document
  1. Checking the structure of the XCRI-CAP document against the published schemas
  1. Executing one or more **validation rulebase(s)** against the document

## Document Validity ##

Basic XML structural issues are found at this stage.  Typical items caught include:
  * Incorrect tag nesting
  * Incorrect character encoding (e.g. "<", ">", "&", etc)

Structural issues such as incorrect tag nesting often mean that the following levels of validation fail; validation failures at this level will often mean other validation rules fail to run.  These issues will normally mean that your feed cannot be read by most tools.

## XML Schema Validity ##

This validates that elements are referenced from the correct namespaces and formatting for values are correctly applied.  If your XML document provides the `schemaLocation` attribute then XSD files are loaded from the locations indicated, otherwise they are loaded from http://www.xcri.co.uk/bindings:
  * http://www.xcri.co.uk/bindings/xcri_cap_1_2.xsd
  * http://www.xcri.co.uk/bindings/xcri_cap_terms_1_2.xsd
  * http://www.xcri.co.uk/bindings/dc.xsd
  * http://www.xcri.co.uk/bindings/dcmitype.xsd
  * http://www.xcri.co.uk/bindings/dcterms.xsd
  * http://www.xcri.co.uk/bindings/educationalcredit.xsd
  * http://www.xcri.co.uk/bindings/mlo-strict.xsd
  * http://www.xcri.co.uk/bindings/mlo_xcri_profile.xsd
  * http://www.xcri.co.uk/bindings/types.xsd

Please note that the currently-published XML schema files require elements in certain orders and the validator will enforce this requirement.  This is a limitation of the current schema files and is not a requirement of the XCRI-CAP 1.2 standard itself.

## Validation Rulebase(s) ##

Validation rulebases catch additional formatting and structural issues to the first two stages and multiple rulebases can be executed to ensure that a feed is compatible with multiple consumers.

Example items that can be caught include:
  * Including an "url" element that does not contain an element
  * Ensuring that certain elements contain other specific elements
  * Checking element value length

The latest version of the XCRI-CAP 1.2 validation module is [available in the source repository](http://code.google.com/p/xcricap-validator/source/browse/src/XCRI.Validation/xml%20files/ValidationModules/XCRICAP12.xml).  Rules are structured into either `document`-level rules (run across matching elements within the entire document) or `element`-level rules (run across matching elements).

Each "Validator" within these sections contains attributes that provide it with information needed to run and instructions that should be shown to the user if they fail.

### Document-level rules ###

Document-level rules are run against matching elements regardless of their position within the XCRI-CAP document.  An example would be a validator that ensures that all `url` elements contain a text value which can be converted to a Uri.

### Element-level rules ###

Element-level rules are run within the context of every element that matches the parent selector.  An example would be a rule that states that all `course` elements must contain at least one `title` element.  Whilst these individual rules could be matched by complicated document-level rules, element-level rules allow simple grouping for administration and ease of readability.

# Making changes #

This project is open-source and, as such, can be downloaded and modified by anyone.  However, patches or modifications can be submitted back into the project by authorised "contributors".  This is especially useful for modifications that resolve bugs or add additional features or vocabularies.

If you would like to become a contributor then please post a message on the [XCRI forum](http://www.xcri.org/forum/) where a project administrator will aim to contact you.