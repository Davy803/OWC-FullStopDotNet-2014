using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FullStopDotNet2014.Data.Models;
using FullStopDotNet2014.Services.Interfaces;
using FullStopDotNet2014.Web.Resources;
using FullStopDotNet2014.Web.ViewModels;
using FullStopDotNet2014.Web.Extensions;
using FullStopDotNet2014.Web.ViewModels.Admin;

namespace FullStopDotNet2014.Web.Areas.Admin.Controllers
{
    [RoutePrefix("TextResources")]
    public class TextResourcesController : AdminControllerBase
    {
        private readonly ITextResourceService _textResourceService;

        public TextResourcesController(TextResourceValues textResourceValues, ITextResourceService textResourceService) : base(textResourceValues)
        {
            _textResourceService = textResourceService;
        }

        [HttpGet]
        public ActionResult Edit(string name, string culture)
        {
            var resource = _textResourceService.GetTextResource(name, culture);
            var viewModel = new ModalEditViewModelBase<TextResourceViewModel>
            {
                ModalPostUrl = Url.Action("Edit"),
                ViewModel = new TextResourceViewModel().InjectFrom(resource)
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(TextResourceViewModel viewModel)
        {
            _textResourceService.SaveTextResource(viewModel.Name, viewModel.Culture, viewModel.Value);

            return Json(true);
        }
    }
}
