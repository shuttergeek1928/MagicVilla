using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Service.Migrations
{
    public partial class addedUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("5b0ab470-03b9-4af1-be0e-f3f95e2d5362"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("a93c77ec-f40b-472c-a042-9e03f56a5660"));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("99e5f659-ee9d-4d07-b92b-f89002c8e3f6"), "Pool, Gym, Bar", 750.00m, new DateTime(2022, 8, 17, 0, 18, 34, 774, DateTimeKind.Local).AddTicks(3801), "Unmatched authentic luxury.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 17, 0, 18, 34, 774, DateTimeKind.Local).AddTicks(3811), "Bliss View", 5, 500.00m });

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("d387d603-0579-4d1f-97b1-b152f2ac3aee"), "Pool, Gym, Bar", 1000.00m, new DateTime(2022, 8, 17, 0, 18, 34, 774, DateTimeKind.Local).AddTicks(3814), "Moment Creating.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 17, 0, 18, 34, 774, DateTimeKind.Local).AddTicks(3815), "Mountain View", 3, 1000.00m });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNumber",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 8, 17, 0, 18, 34, 774, DateTimeKind.Local).AddTicks(3911), new DateTime(2022, 8, 17, 0, 18, 34, 774, DateTimeKind.Local).AddTicks(3911) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("99e5f659-ee9d-4d07-b92b-f89002c8e3f6"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("d387d603-0579-4d1f-97b1-b152f2ac3aee"));

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("5b0ab470-03b9-4af1-be0e-f3f95e2d5362"), "Pool, Gym, Bar", 750.00m, new DateTime(2022, 8, 14, 22, 51, 17, 75, DateTimeKind.Local).AddTicks(5631), "Unmatched authentic luxury.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 14, 22, 51, 17, 75, DateTimeKind.Local).AddTicks(5647), "Bliss View", 5, 500.00m });

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("a93c77ec-f40b-472c-a042-9e03f56a5660"), "Pool, Gym, Bar", 1000.00m, new DateTime(2022, 8, 14, 22, 51, 17, 75, DateTimeKind.Local).AddTicks(5650), "Moment Creating.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 14, 22, 51, 17, 75, DateTimeKind.Local).AddTicks(5651), "Mountain View", 3, 1000.00m });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNumber",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 8, 14, 22, 51, 17, 75, DateTimeKind.Local).AddTicks(5781), new DateTime(2022, 8, 14, 22, 51, 17, 75, DateTimeKind.Local).AddTicks(5782) });
        }
    }
}
