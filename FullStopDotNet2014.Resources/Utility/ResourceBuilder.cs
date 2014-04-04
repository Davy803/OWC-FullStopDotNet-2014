using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Entities;

namespace Resources.Utility
{
    public class ResourceBuilder
    {
        /// <summary>
        /// Generates a class with properties for each resource key
        /// </summary>
        /// <param name="provider">Resource provider instance</param>
        /// <param name="namespaceName">Name of namespace containing the resource class</param>
        /// <param name="className">Name of the class</param>
        /// <param name="filePath">Where to generate the source file</param>
        /// <param name="summaryCulture">If not null, adds a &lt;summary&gt; tag to each property using the specified culture.</param>
        /// <returns>Generated class file full path</returns>
        public string Create(BaseResourceProvider provider, string namespaceName = "Resources", string className = "Resources", string filePath = null, string summaryCulture = null)
        {
            if (provider.ReadResources() == null || provider.ReadResources().Count == 0)
                throw new Exception(string.Format("No resources were found in {0}", provider.GetType().Name));
            var resources = provider.ReadResources();

            // Get a unique list of resource names (keys)
            var keys = resources.Select(r => r.Name).Distinct();

            #region Templates
            const string header =
@"using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace {0} 
{{
    public class {1} 
    {{
        private static readonly IResourceProvider resourceProvider = new {2}();

        {3}
    }}        
}}"; // {0}: namespace {1}:class name   {2}:provider class name   {3}: body  

            const string property =
@"
        {1}
        public static {2} {0} 
        {{
            get 
            {{
                return ({2}) resourceProvider.GetResource(""{0}"", CultureInfo.CurrentUICulture.Name);
            }}
        }}"; // {0}: key

            const string summary =
                @"
        /// <summary>
        /// {0}
        /// </summary>";
            const string summaryNewLine = @"
        /// ";
            #endregion


            // store keys in a string builder
            var sbKeys = new StringBuilder();

            foreach (string key in keys)
            {
                var resource = resources.Where(r => (summaryCulture == null ? true : r.Culture.ToLowerInvariant() == summaryCulture.ToLowerInvariant()) && r.Name == key).FirstOrDefault();
                if (resource == null)
                {
                    throw new Exception(string.Format("Could not find resource {0}", key));
                }

                sbKeys.Append(new String(' ', 12)); // indentation
                sbKeys.AppendFormat(property, key,
                    summaryCulture == null ? string.Empty : string.Format(summary, resource.Value.Replace(Environment.NewLine, summaryNewLine)),
                    resource.Type);
                sbKeys.AppendLine();
            }
            var result = string.Format(header, namespaceName, className, provider.GetType().Name, sbKeys.ToString());

            return result;

        }
    }
}
