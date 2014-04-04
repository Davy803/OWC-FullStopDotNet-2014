using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FullStopDotNet2014.Data;
using Resources.Abstract;

namespace FullStopDotNet2014.Web.Controllers.Api
{
    [RoutePrefix("Api/TextResources")]
    public class TextResourcesApiController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public TextResourcesApiController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("Test")]
        [HttpGet]
        public void Test()
        {
            //return "Success";
        }

        [Route("Save", Name = "SaveTextResource")]
        [HttpPost]
        [HttpGet]
        public bool Save(string resouceKey, string value, string culture = null)
        {
            culture = culture ?? CultureInfo.CurrentUICulture.Name;
            var resource = _dbContext.TextResources.First(x => x.Name == resouceKey && x.Culture == culture);
            resource.Value = value;
            BaseResourceProvider.SetResourceCache(resouceKey, culture, value);
            _dbContext.SaveChanges();
            return true;
        }

    }
}