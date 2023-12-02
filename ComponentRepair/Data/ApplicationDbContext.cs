using ComponentRepair.Models;
using Microsoft.EntityFrameworkCore;

namespace ComponentRepair.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
                
        }
        public DbSet<Device> Device { get; set; }
        public DbSet<Component> Component { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
