using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Constants;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Seeds;

internal class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            (
                username: "administrator",
                password: "123-!@#-123-!@#",
                email: "admin@system.com",
                roleId: RoleConstants.Admin
            )
        );
    }
}
