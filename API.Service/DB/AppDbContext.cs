using API.Domain.Entity;
using API.Domain.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace API.Service.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SubElementConfiguration());
            builder.ApplyConfiguration(new WindowConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(builder);
        }

        public virtual DbSet<SubElement> SubElements { get; set; }
        public virtual DbSet<Window> Windows { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
