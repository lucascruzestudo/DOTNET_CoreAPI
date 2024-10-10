using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations;
internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("T_USER");

        builder.HasKey(ac => ac.Id);

        builder.Property(x => x.Id)
                .HasColumnType("uuid")
                .HasColumnName("PK_USERID")
                .ValueGeneratedOnAdd();

        builder.Property(t => t.Username)
                .HasColumnName("TX_USERNAME")
                .IsRequired();

        builder.Property(t => t.HashedPassword)
                .HasColumnName("TX_PASSWORD")
                .IsRequired();

        builder.Property(t => t.Email)
                .HasColumnName("TX_EMAIL")
                .IsRequired();

        builder.Property(t => t.RoleId)
                .HasColumnName("FK_ROLEID")
                .IsRequired();

        builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .HasConstraintName("FK_USER_ROLE");

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
