using System.Data.Entity;

namespace HatsStore.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Hat> Hats { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
