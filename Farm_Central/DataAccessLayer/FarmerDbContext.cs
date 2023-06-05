using Farm_Central.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace Farm_Central.DataAccessLayer
{
    public class FarmerDbContext :DbContext
    {
        public FarmerDbContext(DbContextOptions<FarmerDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Farmer> Farmers { get; set; }
    }
}
