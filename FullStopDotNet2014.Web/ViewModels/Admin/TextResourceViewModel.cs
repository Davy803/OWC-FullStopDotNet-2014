using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FullStopDotNet2014.Web.ViewModels.Admin
{
    public class TextResourceViewModel 
    {
        public string Name { get; set; }
        public string Culture { get; set; }

        [AllowHtml]
        [UIHint("WysiwygString")]
        public string Value { get; set; }
    }
}