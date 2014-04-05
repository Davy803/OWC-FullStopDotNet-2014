

using System.Globalization;
using System.Web;
using Resources.Abstract;

namespace FullStopDotNet2014.Web.Resources
{
    public class TextResourceValues 
    {
        private readonly IResourceProvider _resourceProvider;

        public TextResourceValues(IResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;
        }
	    /// <summary>
        /// Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
        /// quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in 
        /// voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
        /// </summary>        
        public IHtmlString LoremIpsum 
        {
            get 
            {
                return new HtmlString((string)_resourceProvider.GetResource("LoremIpsum", CultureInfo.CurrentUICulture.Name));
            }
        }        
    }  

    public static class TextResourceKeys 
    {
	    /// <summary>
        /// Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
        /// quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in 
        /// voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
        /// </summary>        
        public const string LoremIpsum = "LoremIpsum";
    }  
}