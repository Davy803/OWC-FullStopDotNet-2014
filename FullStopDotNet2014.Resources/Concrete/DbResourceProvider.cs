using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStopDotNet2014.Data;
using Resources.Abstract;
using Resources.Entities;

namespace Resources.Concrete
{
    public class DbResourceProvider : BaseResourceProvider
    {
        // Database connection string        
        private ApplicationDbContext _dbContext;

        public DbResourceProvider()
        {
            _dbContext = new ApplicationDbContext();
        }
        
        public DbResourceProvider(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public override IList<ResourceEntry> ReadResources()
        {
            return _dbContext
                .TextResources
                .Select(x => new ResourceEntry {Culture = x.Culture, Name = x.Name, Value = x.Value})
                .ToList();
        }

        public override ResourceEntry ReadResource(string name, string culture)
        {
            var resource = _dbContext
                .TextResources
                .First(x=>x.Name == name && x.Culture == culture);
            return new ResourceEntry {Culture = resource.Culture, Name = resource.Name, Value = resource.Value};
      
           
        }

       

       
    }
}
