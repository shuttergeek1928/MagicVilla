using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Service.Migrations
{
    public partial class seededVillaNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new Guid("1a78dc47-c1cc-46a6-ab80-206e01c7a1e7"), "Pool, Gym, Bar", 750.00m, new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4935), "Unmatched authentic luxury.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4946), "Bliss View", 5, 500.00m });

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("66cdf66c-c35b-4c98-95ae-767ccd307882"), "Pool, Gym, Bar", 1000.00m, new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4950), "Moment Creating.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4951), "Mountain View", 3, 1000.00m });

            migrationBuilder.InsertData(
                table: "VillaNumber",
                columns: new[] { "VillaNumber", "CreatedDate", "LastUpdated", "SpecialDetails" },
                values: new object[] { 1, new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(5078), new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(5079), "Luxury." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("1a78dc47-c1cc-46a6-ab80-206e01c7a1e7"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("66cdf66c-c35b-4c98-95ae-767ccd307882"));

            migrationBuilder.DeleteData(
                table: "VillaNumber",
                keyColumn: "VillaNumber",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("50e0f3f3-8c88-41f1-9fb4-2d29d756bb0c"), "Pool, Gym, Bar", 1000.00m, new DateTime(2022, 8, 14, 10, 58, 31, 900, DateTimeKind.Local).AddTicks(1775), "Moment Creating.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 14, 10, 58, 31, 900, DateTimeKind.Local).AddTicks(1776), "Mountain View", 3, 1000.00m });

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("c3f2a79f-5a39-4c28-9977-031f3c222efd"), "Pool, Gym, Bar", 750.00m, new DateTime(2022, 8, 14, 10, 58, 31, 900, DateTimeKind.Local).AddTicks(1761), "Unmatched authentic luxury.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 14, 10, 58, 31, 900, DateTimeKind.Local).AddTicks(1771), "Bliss View", 5, 500.00m });
        }
    }
}
