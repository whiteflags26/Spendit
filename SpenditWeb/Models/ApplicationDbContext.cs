using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SpenditWeb.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, one can rename the ASP.NET Identity table names and more.
            // Add customizations after calling base.OnModelCreating(builder);
        }


        //public DbSet<Transaction> Transactions { get; set; }
        //public DbSet<Category> Categories { get; set; }
    }
}