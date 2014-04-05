using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FullStopDotNet2014.Common.Utilities;
using FullStopDotNet2014.Data.Models;
using FullStopDotNet2014.Services.Interfaces;
using FullStopDotNet2014.Web.Controllers;
using FullStopDotNet2014.Web.Resources;
using Omu.ValueInjecter;

namespace FullStopDotNet2014.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize(Roles = RoleNames.EditContentRole)]
    public class AdminControllerBase : CommonControllerBase
    {
        protected AdminControllerBase(TextResources textResources) : base(textResources)
        {
        }
    }

    
    [RoutePrefix("TextResources")]
    public class TextResourcesController : AdminControllerBase
    {
        private readonly ITextResourceService _textResourceService;

        public TextResourcesController(TextResources textResources, ITextResourceService textResourceService) : base(textResources)
        {
            _textResourceService = textResourceService;
        }

        [HttpGet]
        public ActionResult Edit(string name, string culture)
        {
            var resource = _textResourceService.GetTextResource(name, culture);

            return View(new TextResourceViewModel().InjectFrom(resource));
        }
        [HttpPost]
        public ActionResult Edit(TextResourceViewModel viewModel)
        {
            _textResourceService.SaveTextResource(viewModel.Name, viewModel.Culture, viewModel.Value);

            return Json(true);
        }
    }

    public class TextResourceViewModel 
    {
        public string Name { get; set; }
        public string Culture { get; set; }
        [AllowHtml]
        public string Value { get; set; }
    }
}
