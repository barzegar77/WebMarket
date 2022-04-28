using Microsoft.EntityFrameworkCore;
using WebMarket.Models;

namespace WebMarket.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CoverType> CoverTypes { get; set; }
    }
}
