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
            }
            if (null == interpreter)
                throw new System.IO.InvalidDataException(String.Format
                    (
                    "The interpreter type {0} was not handled",
                    interpreterNode.Name
                    ));
            interpreter.PropertyName
                = interpreterNode.Attribute("propertyName").Value;
            return interpreter;
        }
    }
}
