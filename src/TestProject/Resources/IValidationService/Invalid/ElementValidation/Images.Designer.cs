﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestProject.Resources.IValidationService.Invalid.ElementValidation {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Images {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Images() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TestProject.Resources.IValidationService.Invalid.ElementValidation.Images", typeof(Images).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;catalog xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns=&quot;http://xcri.org/profiles/1.2/catalog&quot; xmlns:xcri12terms=&quot;http://xcri.org/profiles/1.2/catalog/terms&quot; xmlns:dc=&quot;http://purl.org/dc/elements/1.1/&quot; xmlns:dcterms=&quot;http://purl.org/dc/terms/&quot; xmlns:mlo=&quot;http://purl.org/net/mlo&quot; xmlns:geo=&quot;http://www.w3.org/2003/01/geo/wgs84_pos&quot; xmlns:credit=&quot;http://purl.org/net/cm&quot; xmlns:xhtml=&quot;http://www.w3.org/1999/xhtml&quot; xsi:schemaLocation=&quot;http://xcri.org/profiles/1 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ImageWithoutAltAttribute {
            get {
                return ResourceManager.GetString("ImageWithoutAltAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;catalog xmlns=&quot;http://xcri.org/profiles/1.2/catalog&quot;&gt;
        ///  &lt;provider&gt;
        ///    &lt;image src=&quot;http://www.myinstitution.ac.uk/images/logo.jpg&quot; title=&quot;MyInstitution Logo&quot; alt=&quot;MyInstitution Logo&quot;&gt;hello world&lt;/image&gt;
        ///  &lt;/provider&gt;
        ///&lt;/catalog&gt;.
        /// </summary>
        internal static string NotEmpty {
            get {
                return ResourceManager.GetString("NotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;catalog xmlns=&quot;http://xcri.org/profiles/1.2/catalog&quot;&gt;
        ///  &lt;provider&gt;
        ///    &lt;image src=&quot;http://www.myinstitution.ac.uk/images/logo.eps&quot; /&gt;
        ///  &lt;/provider&gt;
        ///&lt;/catalog&gt;.
        /// </summary>
        internal static string SourceEps {
            get {
                return ResourceManager.GetString("SourceEps", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;catalog xmlns=&quot;http://xcri.org/profiles/1.2/catalog&quot;&gt;
        ///  &lt;provider&gt;
        ///    &lt;image src=&quot;http://www.myinstitution.ac.uk/images/logo&quot; /&gt;
        ///  &lt;/provider&gt;
        ///&lt;/catalog&gt;.
        /// </summary>
        internal static string SourceNoExtension {
            get {
                return ResourceManager.GetString("SourceNoExtension", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;catalog xmlns=&quot;http://xcri.org/profiles/1.2/catalog&quot;&gt;
        ///  &lt;provider&gt;
        ///    &lt;image src=&quot;hello world&quot; /&gt;
        ///  &lt;/provider&gt;
        ///&lt;/catalog&gt;.
        /// </summary>
        internal static string SourceNotValidUri {
            get {
                return ResourceManager.GetString("SourceNotValidUri", resourceCulture);
            }
        }
    }
}
