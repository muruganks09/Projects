using Microsoft.EntityFrameworkCore;

namespace PSD.API.Models
{
    public class PSDContext: DbContext
    {
        public PSDContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Company> Companys  { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
