

using System.Globalization;
using Resources.Abstract;
using Resources.Concrete;

namespace FullStopDotNet2014.Web.Resources
{
    public static class TextResources 
    {
        private static readonly IResourceProvider resourceProvider = new DbResourceProvider(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=C:\Source\OWC-FullStopDotNet-2014\FullStopDotNet2014.Web\App_Data\aspnet-OWC-FullStopDotNet.mdf;Initial Catalog=aspnet-OWC-FullStopDotNet-2014;Integrated Security=True");

	    /// <summary>
        /// Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
        /// quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in 
        /// voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
        /// </summary>        
        public static string LoremIpsum 
        {
            get 
            {
                return (string) resourceProvider.GetResource("LoremIpsum", CultureInfo.CurrentUICulture.Name);
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