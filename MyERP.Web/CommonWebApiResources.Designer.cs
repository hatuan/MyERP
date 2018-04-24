﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyERP.Web {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CommonWebApiResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonWebApiResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyERP.Web.CommonWebApiResources", typeof(CommonWebApiResources).Assembly);
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
        ///   Looks up a localized string similar to Relative URI values are not supported: &apos;{0}&apos;. The URI must be absolute..
        /// </summary>
        internal static string ArgumentInvalidAbsoluteUri {
            get {
                return ResourceManager.GetString("ArgumentInvalidAbsoluteUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unsupported URI scheme: &apos;{0}&apos;. The URI scheme must be either &apos;{1}&apos; or &apos;{2}&apos;..
        /// </summary>
        internal static string ArgumentInvalidHttpUriScheme {
            get {
                return ResourceManager.GetString("ArgumentInvalidHttpUriScheme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value must be greater than or equal to {0}..
        /// </summary>
        internal static string ArgumentMustBeGreaterThanOrEqualTo {
            get {
                return ResourceManager.GetString("ArgumentMustBeGreaterThanOrEqualTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value must be less than or equal to {0}..
        /// </summary>
        internal static string ArgumentMustBeLessThanOrEqualTo {
            get {
                return ResourceManager.GetString("ArgumentMustBeLessThanOrEqualTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The argument &apos;{0}&apos; is null or empty..
        /// </summary>
        internal static string ArgumentNullOrEmpty {
            get {
                return ResourceManager.GetString("ArgumentNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to URI must not contain a query component or a fragment identifier..
        /// </summary>
        internal static string ArgumentUriHasQueryOrFragment {
            get {
                return ResourceManager.GetString("ArgumentUriHasQueryOrFragment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of argument &apos;{0}&apos; ({1}) is invalid for Enum type &apos;{2}&apos;..
        /// </summary>
        internal static string InvalidEnumArgument {
            get {
                return ResourceManager.GetString("InvalidEnumArgument", resourceCulture);
            }
        }
    }
}
