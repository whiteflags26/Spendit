using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spendit.Models;

namespace Spendit.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, one can rename the ASP.NET Identity table names and more.
            // Add customizations after calling base.OnModelCreating(builder);

            builder.Entity<Membership>()
            .HasKey(m => new { m.MemberId, m.GroupId });

            builder.Entity<Membership>()
                .HasOne(m => m.Member)
                .WithMany(u => u.Memberships)
                .HasForeignKey(m => m.MemberId);

            builder.Entity<Membership>()
                .HasOne(m => m.Group)
                .WithMany(g => g.Memberships)
                .HasForeignKey(m => m.GroupId);
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SpenditUser> SpenditUsers { get; set;}
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupCategory> GroupCategories { get; set; }
        public DbSet<GroupTransaction> GroupTransactions { get; set; }
        public DbSet<Membership> Memberships { get; set; }
    }
}