﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dan_s_Big_Awesome_Acoustic_Songbook_Parser {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Dan_s_Big_Awesome_Acoustic_Songbook_Parser.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to &lt;!DOCTYPE html&gt;
        ///&lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;script language=&quot;javascript&quot; src=&quot;scrolling.js&quot;&gt;&lt;/script&gt;
        ///
        ///	&lt;script language=&quot;javascript&quot; src=&quot;jquery-1.12.0.min.js&quot;&gt;&lt;/script&gt;
        ///	&lt;script type=&quot;text/javascript&quot;&gt;
        ///
        ///var songLinks = [];
        ///
        ///$(window).load(function(){
        ///
        ///    // Find all links to songs in the TOC
        ///    $(&quot;a&quot;).each(function ()
        ///    {
        ///      if (this.href.includes(&quot;#s_&quot;))
        ///      {
        ///        songLinks.push(this.href);
        ///      }
        ///    });
        ///
        ///    $(window).keydown(handleKeyPress);
        ///    $(window).scroll(positionScrolle [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DansSongbook {
            get {
                return ResourceManager.GetString("DansSongbook", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!DOCTYPE html&gt;
        ///
        ///&lt;html lang=&quot;en&quot; xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;
        ///&lt;head&gt;
        ///	&lt;meta charset=&quot;utf-8&quot; /&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///
        ///	&lt;div class=sg_newsong&gt; &lt;/div&gt;
        ///	&lt;div class=sg_song data-key=&quot;A&quot; id=&quot;s_abbamammamia&quot;&gt;
        ///		&lt;h1 class=sg_title&gt;&lt;span style=&quot;vertical-align:middle;&quot;&gt;&lt;a href=&quot;#s_abbamammamia&quot; style=&quot;text-decoration:none;color:black;&quot;&gt;Abba - Mamma Mia&lt;/a&gt;&lt;/span&gt;&amp;nbsp;&amp;nbsp;&lt;span class=&quot;transbutton&quot;&gt;&lt;img style=&quot;vertical-align:middle;&quot; src=&quot;images/transpose_up_small.png&quot; onclick=&quot;transpo [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SingleSongTemplate {
            get {
                return ResourceManager.GetString("SingleSongTemplate", resourceCulture);
            }
        }
    }
}
