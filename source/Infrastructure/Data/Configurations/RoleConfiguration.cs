using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations;
internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("T_ROLE");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
                .HasColumnType("uuid")
                .HasColumnName("PK_ROLEID")
                .ValueGeneratedOnAdd();

        builder.Property(r => r.Name)
                .HasColumnName("TX_NAME")
                .IsRequired();

        builder.Property(t => t.CreatedAt)
                .HasColumnName("DT_CREATEDAT")
                .IsRequired();

        builder.Property(t => t.UpdatedAt)
                .HasColumnName("DT_UPDATEDAT");
                        
        builder.Property(t => t.IsDeleted)
                .HasColumnName("FL_DELETED")
                .IsRequired();
    }
}
