using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Entities;

namespace Resources.Abstract
{
    public abstract class BaseResourceProvider: IResourceProvider
    {
        // Cache list of resources
        private static Dictionary<string, ResourceEntry> resources = null;
        private static object lockResources = new object();

        public BaseResourceProvider() {
            Cache = true; // By default, enable caching for performance
        }

        protected bool Cache { get; set; } // Cache resources ?

        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resorce name (ie key)</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        public object GetResource(string name, string culture)
        {
            var resource = InternalGetResource(name, culture) //resource as requested
                           ?? InternalGetResource(name, culture.Substring(0, 2))  //language only, without country
                           ?? InternalGetResource(name, "en-us") //English US
                           ?? InternalGetResource(name, "en"); //English
            return resource;
        }

        public static void SetResourceCache(string name, string culture, string value)
        {
            if (resources != null)
            {
                var cacheKey = GetCacheKey(name, culture);
                if (resources.ContainsKey(cacheKey))
                {
                    resources[cacheKey].Value = value;
                }
            }
    }

        private object InternalGetResource(string name, string culture)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Resource name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(culture))
                throw new ArgumentException("Culture name cannot be null or empty.");

            // normalize
            culture = culture.ToLowerInvariant();

            if (Cache && resources == null)
            {
                // Fetch all resources

                lock (lockResources)
                {
                    if (resources == null)
                    {
                        resources =
                            ReadResources().ToDictionary(r => string.Format("{0}.{1}", r.Culture.ToLowerInvariant(), r.Name));
                    }
                }
            }

            if (Cache)
            {
                var cacheKey = GetCacheKey(name, culture);
                if (resources.ContainsKey(cacheKey))
                {
                    return resources[cacheKey].Value;
                }
                return null;
            }

            return ReadResource(name, culture).Value;
        }

        private static string GetCacheKey(string name, string culture)
        {
            return string.Format("{0}.{1}", culture.ToLower(), name);
        }


        /// <summary>
        /// Returns all resources for all cultures. (Needed for caching)
        /// </summary>
        /// <returns>A list of resources</returns>
        public abstract IList<ResourceEntry> ReadResources();


        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resorce name (ie key)</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        public abstract ResourceEntry ReadResource(string name, string culture);
        
    }
}
