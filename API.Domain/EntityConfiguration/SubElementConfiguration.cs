using API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.EntityConfiguration
{
    public class SubElementConfiguration : IEntityTypeConfiguration<SubElement>
    {
        public void Configure(EntityTypeBuilder<SubElement> builder)
        {
            builder.ToTable("SubElements");
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Id);
            builder.Property(t => t.Type).IsRequired().HasColumnType("int");
            builder.Property(t => t.Width).IsRequired().HasColumnType("int");
            builder.Property(t => t.Height).IsRequired().HasColumnType("int");

            builder.HasOne(t => t.Window)
                .WithMany(w => w.SubElements)
                .HasForeignKey(w => w.WindowId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
