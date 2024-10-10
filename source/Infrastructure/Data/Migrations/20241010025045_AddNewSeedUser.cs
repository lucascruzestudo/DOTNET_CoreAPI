using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewSeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("376de265-379a-4dcb-bbe3-956fa3a6f7c7"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("c3278072-3254-45b9-9c18-48ef7fdfe0ac"));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 10, 2, 50, 45, 245, DateTimeKind.Utc).AddTicks(6451));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 10, 2, 50, 45, 245, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("1832cdd0-ed35-4a6c-bc7b-3d6d104b6c36"), new DateTime(2024, 10, 10, 2, 50, 45, 360, DateTimeKind.Utc).AddTicks(1116), "lucascruzestudo@gmail.com", "$2a$11$moRhq6j4UrriJM/MqBdBmuCoep5.exC79fOYxzHkDGXllMA0ux1Wi", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "lucascruzestudo" },
                    { new Guid("61a864df-b35c-470d-8e8d-e1b025f3b1d1"), new DateTime(2024, 10, 10, 2, 50, 45, 475, DateTimeKind.Utc).AddTicks(3673), "lucascruztrabalho@gmail.com", "$2a$11$KxH9z7sXaK4SsoA0N3L5N.b9RU/x/F1JplZhFNLg7fhWwb.MdFgf2", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "lucascruztrabalho" },
                    { new Guid("c1fc3f80-866a-44a4-a33f-21445909de1e"), new DateTime(2024, 10, 10, 2, 50, 45, 245, DateTimeKind.Utc).AddTicks(6611), "admin@system.com", "$2a$11$udfkrLZ89y5yF055EkYgReShrlaASxyCvo4uQUDwm87Uzz.XSiaWC", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "administrator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("1832cdd0-ed35-4a6c-bc7b-3d6d104b6c36"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("61a864df-b35c-470d-8e8d-e1b025f3b1d1"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("c1fc3f80-866a-44a4-a33f-21445909de1e"));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 10, 2, 40, 26, 795, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 10, 2, 40, 26, 795, DateTimeKind.Utc).AddTicks(1304));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("376de265-379a-4dcb-bbe3-956fa3a6f7c7"), new DateTime(2024, 10, 10, 2, 40, 26, 912, DateTimeKind.Utc).AddTicks(1848), "lucascruzestudo@gmail.com", "$2a$11$B3M8rnpjjbFmWV6noB6UveT6/cypAZL0iKmE.tXU6wlxs0h7EVY92", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "lucascruzestudo" },
                    { new Guid("c3278072-3254-45b9-9c18-48ef7fdfe0ac"), new DateTime(2024, 10, 10, 2, 40, 26, 795, DateTimeKind.Utc).AddTicks(1461), "admin@system.com", "$2a$11$6fR3srh9tMATUjIfg6qe.eg6Q/oSV4JI4IPhjyh/PGr3szBk3BgFu", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "administrator" }
                });
        }
    }
}
