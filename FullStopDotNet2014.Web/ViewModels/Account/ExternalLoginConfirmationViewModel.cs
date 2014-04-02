using System.ComponentModel.DataAnnotations;

namespace FullStopDotNet2014.Web.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}