using System;
using System.Collections.Generic;
using System.Configuration;
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
        private static string connectionString = null;
        private ApplicationDbContext _dbContext;

        public DbResourceProvider(){
            
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public DbResourceProvider(string connection)
        {
            connectionString = connection;
            _dbContext = new ApplicationDbContext(connection);
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
