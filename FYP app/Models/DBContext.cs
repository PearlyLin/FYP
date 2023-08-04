using Microsoft.EntityFrameworkCore;

namespace FYPfinalWEBAPP.Models
{
    public class RDSContext : DbContext
    {
        public RDSContext()
          : base(GetRDSConnectionString())
        {
        }

        private static DbContextOptions GetRDSConnectionString()
        {
            throw new NotImplementedException();
        }

        public static RDSContext Create()
        {
            return new RDSContext();
        }
    }
}