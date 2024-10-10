using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedUsersAndRoles : Migration
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
                    DT_CREATEDAT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DT_UPDATEDAT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FL_DELETED = table.Column<bool>(type: "boolean", nullable: false)
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
                    FK_ROLEID = table.Column<Guid>(type: "uuid", nullable: false),
                    DT_CREATEDAT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DT_UPDATEDAT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FL_DELETED = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER", x => x.PK_USERID);
                    table.ForeignKey(
                        name: "FK_USER_ROLE",
                        column: x => x.FK_ROLEID,
                        principalTable: "T_ROLE",
                        principalColumn: "PK_ROLEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "T_ROLE",
                columns: new[] { "PK_ROLEID", "DT_CREATEDAT", "FL_DELETED", "TX_NAME", "DT_UPDATEDAT" },
                values: new object[,]
                {
                    { new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), new DateTime(2024, 10, 10, 2, 40, 26, 795, DateTimeKind.Utc).AddTicks(1301), false, "Admin", null },
                    { new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), new DateTime(2024, 10, 10, 2, 40, 26, 795, DateTimeKind.Utc).AddTicks(1304), false, "User", null }
                });

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("376de265-379a-4dcb-bbe3-956fa3a6f7c7"), new DateTime(2024, 10, 10, 2, 40, 26, 912, DateTimeKind.Utc).AddTicks(1848), "lucascruzestudo@gmail.com", "$2a$11$B3M8rnpjjbFmWV6noB6UveT6/cypAZL0iKmE.tXU6wlxs0h7EVY92", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "lucascruzestudo" },
                    { new Guid("c3278072-3254-45b9-9c18-48ef7fdfe0ac"), new DateTime(2024, 10, 10, 2, 40, 26, 795, DateTimeKind.Utc).AddTicks(1461), "admin@system.com", "$2a$11$6fR3srh9tMATUjIfg6qe.eg6Q/oSV4JI4IPhjyh/PGr3szBk3BgFu", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "administrator" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_USER_FK_ROLEID",
                table: "T_USER",
                column: "FK_ROLEID");
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
