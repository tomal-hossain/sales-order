using API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.EntityConfiguration
{
    public class WindowConfiguration : IEntityTypeConfiguration<Window>
    {
        public void Configure(EntityTypeBuilder<Window> builder)
        {
            builder.ToTable("Windows");
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasColumnType("nvarchar(150)");
            builder.Property(t => t.Quantity).IsRequired().HasColumnType("int");

            builder.HasOne(t => t.Order)
                .WithMany(o => o.Windows)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
