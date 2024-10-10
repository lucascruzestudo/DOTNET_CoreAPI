using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Constants;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Seeds;

internal class RoleSeed : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role
            (
                id: RoleConstants.Admin,
                name: "Admin"
            ),
            new Role
            (
                id: RoleConstants.User,
                name: "User"
            )
        );
    }
}
