using Farm_Central.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace Farm_Central.DataAccessLayer
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
