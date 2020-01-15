using Microsoft.EntityFrameworkCore;

namespace RestTest2.Models
{
    public class LeadsContext : DbContext
    {
        public DbSet<Lead> Lead { get; set; }
        public LeadsContext(DbContextOptions<LeadsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
