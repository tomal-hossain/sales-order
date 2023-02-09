using API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasColumnType("nvarchar(150)");
            builder.Property(t => t.State).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(t => t.CreationDate).IsRequired().HasColumnType("datetime");
        }
    }
}
