using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation;
using XCRI.Validation.Modules;
using XCRI.Validation.Logging;

namespace XCRI.Validator.App
{
    public class ValidateRunner
    {
        public ValidateRunner
            (
            ITimedLog log,
            IValidationService<Uri> validationService,
            IValidationModule validationModule,
            IInterpretationModule interpretationModule
            )
        {
            if (null == log)
                throw new ArgumentNullException("log");
            this.Log = log;
            if (null == validationService)
                throw new ArgumentNullException("validationService");
            this.ValidationService = validationService;
            if (null == validationModule)
                throw new ArgumentNullException("validationModule");
            this.ValidationModule = validationModule;
            if (null == interpretationModule)
                throw new ArgumentNullException("interpretationModule");
            this.InterpretationModule = interpretationModule;
        }
        public IValidationService<Uri> ValidationService { get; private set; }
        public ITimedLog Log { get; private set; }
        public IValidationModule ValidationModule { get; private set; }
        public IInterpretationModule InterpretationModule { get; private set; }
        public System.IO.FileInfo ValidationModuleLocation { get; set; }
        public System.IO.FileInfo InterpretationModuleLocation { get; set; }
        public System.IO.FileInfo FileToValidate { get; set; }
        public bool CanRun()
        {
            return false;
        }
        public void Run()
        {
            IList<ValidationResult> r = null;
            using (this.Log.Step("Validating"))
            {
                var moduleXDocument = System.Xml.Linq.XDocument.Load(this.ValidationModuleLocation.FullName);
                var validators = this.ValidationModule.ExtractValidators(moduleXDocument);
                if (null != validators)
                {
                    foreach (var validator in validators)
                        if (null != validator)
                            this.ValidationService.XmlContentValidators.Add(validator);
                }
                var interpreterXml = System.Xml.Linq.XDocument.Load(this.InterpretationModuleLocation.FullName);
                var interpreters = this.InterpretationModule.ExtractInterpreters(interpreterXml);
                if (null != interpreters)
                {
                    foreach (var interpreter in interpreters)
                        if (null != interpreter)
                            this.ValidationService.XmlExceptionInterpreters.Add(interpreter);
                }
                r = this.ValidationService.Validate
                    (
                    new Uri("file://" + this.FileToValidate.FullName.Replace("\\", "/"), UriKind.Absolute)
                    );
            }
            using (this.Log.Step("Writing output.html"))
            {
                this.Output(r);
            }
        }
        public void Output(IList<ValidationResult> list)
        {
            using (System.Xml.XmlTextWriter output = new System.Xml.XmlTextWriter("output.html", Encoding.Unicode))
            {
                output.WriteRaw("<html><head><title>results</title><style type=\"text/css\">.failedcount-0 { display: none; }</style></head><body>");
                output.WriteStartElement("h1");
                output.WriteRaw("Validation Results");
                output.WriteEndElement();
                
                output.WriteStartElement("h2");
                output.WriteRaw("Summary");
                output.WriteEndElement();

                output.WriteStartElement("ul");
                output.WriteAttributeString("class", "summary");
                foreach (var s in Enum.GetNames(typeof(XCRI.Validation.ContentValidation.ValidationStatus))
                    .Where(vg => vg.ToLower() != "unknown" && vg.ToLower() != "passed")
                    .Reverse())
                {
                    output.WriteStartElement("li");
                    output.WriteAttributeString("class", s.ToString().ToLower());
                    output.WriteRaw(String.Format("{0} ({1})", s, GetCount(list, s)));

                    var vgList = list
                        .Select(vr => vr.ValidationGroup)
                        .Distinct()
                        .OrderBy(vg => vg);

                    if (list.Where(vr => vr.Status.ToString() == s).Sum(x => x.FailedCount) > 0)
                    {

                        output.WriteStartElement("ul");

                        foreach (var vg in vgList)
                        {
                            var filteredModel = list.Where(vr => vr.ValidationGroup == vg).Where(vr => vr.Status.ToString() == s);
                            var filteredCount = filteredModel.Count();
                            if (filteredCount == 0)
                                continue;
                            output.WriteStartElement("li");
                            output.WriteRaw(String.Format("{0} {1} {2}", filteredModel.Count(), vg.ToLower(), (filteredCount == 1 ? s.ToLower() : s.ToLower() + "s")));
                            output.WriteEndElement(); // li
                        }

                        output.WriteEndElement(); // ul

                    }

                    output.WriteEndElement(); // li
                }
                output.WriteEndElement(); // ul
                
                output.WriteStartElement("h2");
                output.WriteRaw("Details");
                output.WriteEndElement();

                foreach (var s in Enum.GetNames(typeof(XCRI.Validation.ContentValidation.ValidationStatus))
                    .Where(vg => vg.ToLower() != "unknown"))
                {

                    if (list.Where(vr => vr.Status == (XCRI.Validation.ContentValidation.ValidationStatus)Enum.Parse(typeof(XCRI.Validation.ContentValidation.ValidationStatus), s)).Sum(x => x.FailedCount) == 0)
                        continue;

                    output.WriteStartElement("h3");
                    output.WriteRaw(s);
                    output.WriteEndElement();

                    foreach (var vg in list
                        .Select(vr => vr.ValidationGroup)
                    .Distinct())
                    {
                        var filteredModel = list
                            //.Where(vr => vr.FailedCount > 0)
                                .Where(vr => vr.ValidationGroup == vg && vr.Status == (XCRI.Validation.ContentValidation.ValidationStatus)Enum.Parse(typeof(XCRI.Validation.ContentValidation.ValidationStatus), s))
                                .OrderByDescending(vr => vr.Status);
                        var filteredCount = filteredModel.Count();
                        if (filteredCount == 0)
                            continue;

                        output.WriteStartElement("div");
                        output.WriteAttributeString("class", "failedcount-" + filteredModel.Sum(vr => vr.FailedCount).ToString());

                        output.WriteStartElement("h4");
                        output.WriteRaw(vg);
                        output.WriteEndElement();

                        output.WriteStartElement("ul");

                        foreach (var vr in filteredModel)
                        {

                            output.WriteStartElement("div");
                            output.WriteAttributeString("class", "failedcount-" + vr.FailedCount.ToString());

                            output.WriteStartElement("p");
                            output.WriteRaw(String.Format("{0} ({1} failed instance{2})", vr.Message, vr.FailedCount, (vr.FailedCount == 1 ? String.Empty : "s")));
                            output.WriteEndElement();

                            output.WriteRaw("<table cellspacing=\"0\"><thead><tr><th class=\"status\">Status</th><th class=\"numeric\">Line Number</th><th class=\"numeric\">Line Position</th><th>Details</th></tr></thead><tbody>");

                            foreach (var vi in vr.FailedInstances
                                            .OrderBy(vi => vi.LineNumber)
                                            .ThenBy(vi => vi.LinePosition))
                            {

                                output.WriteStartElement("tr");
                                output.WriteAttributeString("class", vi.Status.ToString().ToLower());

                                output.WriteRaw("<td class=\"status\">" + vi.Status.ToString() + "</td>");
                                output.WriteRaw("<td class=\"numeric\">" + (vi.LineNumber.HasValue ? vi.LineNumber.Value.ToString() : "N/A") + "</td>");
                                output.WriteRaw("<td class=\"numeric\">" + (vi.LinePosition.HasValue ? vi.LinePosition.Value.ToString() : "N/A") + "</td>");
                                output.WriteRaw("<td class=\"details\">" + (String.IsNullOrEmpty(vi.Details) ? "N/A" : vi.Details) + "</td>");

                                output.WriteEndElement();

                            }
                            output.WriteRaw("</tbody></table>");

                            output.WriteEndElement();

                        }

                        output.WriteEndElement();

                        output.WriteEndElement();

                    }
                }

                output.WriteRaw("</body></html>");
                output.Flush();
                output.Close();
            }
        }
        public int GetCount(IList<ValidationResult> list, string status)
        {
            return list.Count(vr => vr.Status.ToString().Equals(status, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
