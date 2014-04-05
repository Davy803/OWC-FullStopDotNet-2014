using FullStopDotNet2014.Data;

namespace FullStopDotNet2014.Services.Implementation
{
    public class ServiceBase
    {
        public ServiceBase(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; set; }


    }
}