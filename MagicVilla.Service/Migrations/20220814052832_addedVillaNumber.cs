using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Service.Migrations
{
    public partial class addedVillaNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("27ee7595-1fb9-4678-b8bf-d19e7e1793c3"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("f7b65d2c-12e6-4fd7-a689-b2958119009f"));

            migrationBuilder.CreateTable(
                name: "VillaNumber",
                columns: table => new
                {
                    VillaNumber = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumber", x => x.VillaNumber);
                });

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("50e0f3f3-8c88-41f1-9fb4-2d29d756bb0c"), "Pool, Gym, Bar", 1000.00m, new DateTime(2022, 8, 14, 10, 58, 31, 900, DateTimeKind.Local).AddTicks(1775), "Moment Creating.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 14, 10, 58, 31, 900, DateTimeKind.Local).AddTicks(1776), "Mountain View", 3, 1000.00m });

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("c3f2a79f-5a39-4c28-9977-031f3c222efd"), "Pool, Gym, Bar", 750.00m, new DateTime(2022, 8, 14, 10, 58, 31, 900, DateTimeKind.Local).AddTicks(1761), "Unmatched authentic luxury.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 14, 10, 58, 31, 900, DateTimeKind.Local).AddTicks(1771), "Bliss View", 5, 500.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumber");

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("50e0f3f3-8c88-41f1-9fb4-2d29d756bb0c"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("c3f2a79f-5a39-4c28-9977-031f3c222efd"));

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("27ee7595-1fb9-4678-b8bf-d19e7e1793c3"), "Pool, Gym, Bar", 1000.00m, new DateTime(2022, 8, 10, 14, 29, 15, 717, DateTimeKind.Local).AddTicks(3638), "Moment Creating.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 10, 14, 29, 15, 717, DateTimeKind.Local).AddTicks(3638), "Mountain View", 3, 1000.00m });

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("f7b65d2c-12e6-4fd7-a689-b2958119009f"), "Pool, Gym, Bar", 750.00m, new DateTime(2022, 8, 10, 14, 29, 15, 717, DateTimeKind.Local).AddTicks(3623), "Unmatched authentic luxury.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 10, 14, 29, 15, 717, DateTimeKind.Local).AddTicks(3634), "Bliss View", 5, 500.00m });
        }
    }
}
