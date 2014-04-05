using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FullStopDotNet2014.Web.Resources;

namespace FullStopDotNet2014.Web.ViewModels
{
    public class ViewModelBase
    {
        public TextResources TextResources { get; set; }

        public ViewModelBase(TextResources textResources)
        {
            TextResources = textResources;
        }
    }
}