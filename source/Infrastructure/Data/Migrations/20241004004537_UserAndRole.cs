using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_ROLE",
                columns: table => new
                {
                    PK_ROLEID = table.Column<Guid>(type: "uuid", nullable: false),
                    TX_NAME = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ROLE", x => x.PK_ROLEID);
                });

            migrationBuilder.CreateTable(
                name: "T_USER",
                columns: table => new
                {
                    PK_USERID = table.Column<Guid>(type: "uuid", nullable: false),
                    TX_USERNAME = table.Column<string>(type: "text", nullable: false),
                    TX_PASSWORD = table.Column<string>(type: "text", nullable: false),
                    TX_EMAIL = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER", x => x.PK_USERID);
                    table.ForeignKey(
                        name: "FK_USER_ROLE",
                        column: x => x.RoleId,
                        principalTable: "T_ROLE",
                        principalColumn: "PK_ROLEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "T_ROLE",
                columns: new[] { "PK_ROLEID", "CreatedAt", "IsDeleted", "TX_NAME", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), new DateTime(2024, 10, 4, 0, 45, 37, 193, DateTimeKind.Utc).AddTicks(1470), false, "Admin", null },
                    { new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), new DateTime(2024, 10, 4, 0, 45, 37, 193, DateTimeKind.Utc).AddTicks(1476), false, "User", null }
                });

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "CreatedAt", "TX_EMAIL", "TX_PASSWORD", "IsDeleted", "RoleId", "UpdatedAt", "TX_USERNAME" },
                values: new object[] { new Guid("d0ea3c5e-3d1b-4e39-87d6-662ec97f6dc5"), new DateTime(2024, 10, 4, 0, 45, 37, 193, DateTimeKind.Utc).AddTicks(1736), "admin@system.com", "$2a$11$HDSfiDwyjW0948KqxfDP7OaNM6Cc8x1yll7nliNNqLcVqR3cisyZm", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_T_USER_RoleId",
                table: "T_USER",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_USER");

            migrationBuilder.DropTable(
                name: "T_ROLE");
        }
    }
}
