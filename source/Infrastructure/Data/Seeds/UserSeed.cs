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
            ),
            new User
            (
                username: "lucascruzestudo",
                password: "123-!@#-123-!@#",
                email: "lucascruzestudo@gmail.com",
                roleId: RoleConstants.Admin
            ),
            new User
            (
                username: "lucascruztrabalho",
                password: "123-!@#-123-!@#",
                email: "lucascruztrabalho@gmail.com",
                roleId: RoleConstants.User
            )
        );
    }
}
