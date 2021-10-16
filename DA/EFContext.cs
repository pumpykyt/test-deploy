using DA.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DA
{
    public class EFContext : IdentityDbContext<User>
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }
        
        public virtual DbSet<Deal> Deals { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Deal>()
                .HasOne(t => t.Author)
                .WithMany(t => t.CreatedDeals)
                .HasForeignKey(t => t.AuthorId);

            builder
                .Entity<Deal>()
                .HasOne(t => t.Performer)
                .WithMany(t => t.PerformedDeals)
                .HasForeignKey(t => t.PerformerId);
            base.OnModelCreating(builder);
        }
    }
}