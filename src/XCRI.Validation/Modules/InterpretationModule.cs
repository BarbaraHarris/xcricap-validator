using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XCRI.Validation.Modules
{
    public class InterpretationModule : IInterpretationModule
    {
        public List<Logging.ILog> Logs { get; private set; }
        public List<Logging.ITimedLog> TimedLogs { get; private set; }
        public XmlExceptionInterpretation.IInterpreterFactory InterpreterFactory { get; set; }
        public InterpretationModule
            (
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs,
            XmlExceptionInterpretation.IInterpreterFactory interpreterFactory
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
            this.InterpreterFactory = interpreterFactory;
        }
        public IEnumerable<XmlExceptionInterpretation.IInterpreter> ExtractInterpreters
            (
            System.IO.FileInfo fi
            )
        {
            if (null == fi)
                throw new ArgumentNullException("fi");
            if (fi.Exists == false)
                throw new ArgumentException("The file must exist to be called in this manner", "fi");
            // Grab reference to doc
            var xdoc = XDocument.Load(fi.FullName);
            var xmlnsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            // Extract namespace details
            foreach (var node in xdoc.XPathSelectElements("/interpreters/namespaces/add"))
            {
                xmlnsmgr.AddNamespace
                    (
                    node.Attribute("prefix").Value,
                    node.Attribute("namespace").Value
                    );
            }
            // Extract interpreters
            foreach (var node in xdoc.XPathSelectElements("/interpreters/*"))
            {
                yield return this.ExtractInterpreter(node);
            }
        }
        public XmlExceptionInterpretation.IInterpreter ExtractInterpreter
            (
            XElement interpreterNode
            )
        {
            if (null == interpreterNode)
                throw new ArgumentNullException("validatorNode");
            if (null == this.InterpreterFactory)
                throw new InvalidOperationException("The InterpreterFactory property must not be null in order to extract interpreters from an XML file");
            XmlExceptionInterpretation.IInterpreter interpreter = null;
            switch (interpreterNode.Name.LocalName.ToLower())
            {
                case "regularexpressioninterpreter":
                    var regularExpressionInterpreter = this.InterpreterFactory.GetInterpreter<XmlExceptionInterpretation.RegularExpressionInterpreter>();
                    if (
                        (null != interpreterNode.Attribute("pattern"))
                        &&
                        (false == String.IsNullOrEmpty(interpreterNode.Attribute("pattern").Value))
                        )
                        regularExpressionInterpreter.Pattern = interpreterNode.Attribute("pattern").Value;
                    if (null != interpreterNode.Attribute("message"))
                        regularExpressionInterpreter.Message
                            = interpreterNode.Attribute("message").Value;
                    foreach (XElement e in interpreterNode.XPathSelectElements("./if"))
                    {
                        switch (e.Attribute("type").Value.ToLower())
                        {
                            case "match":
                                regularExpressionInterpreter.Conditions.Add(new XmlExceptionInterpretation.RegularExpressionInterpreter.IfMatch()
                                {
                                    FurtherInformation = e.XPathSelectElement("./FurtherInformation")
                                });
                                break;
                            case "group":
                                regularExpressionInterpreter.Conditions.Add(new XmlExceptionInterpretation.RegularExpressionInterpreter.IfGroup()
                                {
                                    GroupName = e.Attribute("groupName").Value,
                                    MatchValue = e.Attribute("equals").Value,
                                    FurtherInformation = e.XPathSelectElement("./FurtherInformation")
                                });
                                break;
                        }
                    }
                    interpreter = regularExpressionInterpreter;
                    break;
                case "invalidchildelementinterpreter":
                    var childElementInterpreter = this.InterpreterFactory.GetInterpreter<XmlExceptionInterpretation.InvalidChildElementInterpreter>();
                    childElementInterpreter.FurtherInformation_ElementNameCasingIncorrect = interpreterNode.XPathSelectElement("./FurtherInformation[@type='ElementNameCasingIncorrect']");
                    childElementInterpreter.FurtherInformation_ElementNamespaceIncorrect = interpreterNode.XPathSelectElement("./FurtherInformation[@type='ElementNamespaceIncorrect']");
                    // Now load in any expected element groups (expectedElements)
                    Dictionary<string, IEnumerable<XCRI.Validation.XmlExceptionInterpretation.InvalidChildElementInterpreter.ExpectedElement>> expectedElementGroups
                        = new Dictionary<string, IEnumerable<XmlExceptionInterpretation.InvalidChildElementInterpreter.ExpectedElement>>();
                    foreach (var eeg in interpreterNode.XPathSelectElements("./expectedElements"))
                    {
                        List<XCRI.Validation.XmlExceptionInterpretation.InvalidChildElementInterpreter.ExpectedElement> expectedElements
                            = new List<XmlExceptionInterpretation.InvalidChildElementInterpreter.ExpectedElement>();
                        string id = eeg.Attribute("id").Value;
                        foreach (var ee in eeg.XPathSelectElements("./expectedElement"))
                        {
                            expectedElements.Add(new XmlExceptionInterpretation.InvalidChildElementInterpreter.ExpectedElement
                                (
                                ee.Attribute("element").Value,
                                ee.Attribute("namespace").Value
                                ));
                            if (null != ee.Attribute("minimumNumber"))
                                expectedElements[expectedElements.Count - 1].MinimumNumber = Int32.Parse(ee.Attribute("minimumNumber").Value);
                            if (null != ee.Attribute("maximumNumber"))
                                expectedElements[expectedElements.Count - 1].MaximumNumber = Int32.Parse(ee.Attribute("maximumNumber").Value);
                        }
                        expectedElementGroups.Add(id, expectedElements);
                    }
                    // Now iterate over any expected elements themselves
                    foreach (var ee in interpreterNode.XPathSelectElements("./expectedElement"))
                    {
                        var elementName = ee.Attribute("element").Value;
                        var elementNamespace = ee.Attribute("namespace").Value;
                        List<XCRI.Validation.XmlExceptionInterpretation.InvalidChildElementInterpreter.ExpectedElement> expectedElements
                            = new List<XmlExceptionInterpretation.InvalidChildElementInterpreter.ExpectedElement>();
                        // Iterate over children in order
                        foreach (var child in ee.XPathSelectElements("./*"))
                        {
                            switch (child.Name.LocalName.ToLower())
                            {
                                case "expectedelements":
                                    string reference = child.Attribute("ref").Value;
                                    if (false == expectedElementGroups.ContainsKey(reference))
                                        throw new Exception("expectedElements element contained an undeclared ref attribute.");
                                    expectedElements.AddRange(expectedElementGroups[reference]);
                                    break;
                                case "expectedelement":
                                    expectedElements.Add(new XmlExceptionInterpretation.InvalidChildElementInterpreter.ExpectedElement
                                        (
                                        child.Attribute("element").Value,
                                        child.Attribute("namespace").Value
                                        ));
                                    if (null != child.Attribute("minimumNumber"))
                                        expectedElements[expectedElements.Count - 1].MinimumNumber = Int32.Parse(child.Attribute("minimumNumber").Value);
                                    if (null != child.Attribute("maximumNumber"))
                                        expectedElements[expectedElements.Count - 1].MaximumNumber = Int32.Parse(child.Attribute("maximumNumber").Value);
                                    break;
                            }
                        }
                        childElementInterpreter.ExpectedElements.Add(new XmlExceptionInterpretation.InvalidChildElementInterpreter.ExpectedElement
                            (
                            elementName,
                            elementNamespace,
                            expectedElements.ToArray()
                            ));
                    }
                    interpreter = childElementInterpreter;
                    break;
            }
            if (null == interpreter)
                throw new System.IO.InvalidDataException(String.Format
                    (
                    "The interpreter type {0} was not handled",
                    interpreterNode.Name
                    ));
            if (null != interpreterNode.Attribute("propertyName"))
                interpreter.PropertyName
                    = interpreterNode.Attribute("propertyName").Value;
            return interpreter;
        }
    }
}
