using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Service.Migrations
{
    public partial class seededVilla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("27ee7595-1fb9-4678-b8bf-d19e7e1793c3"), "Pool, Gym, Bar", 1000.00m, new DateTime(2022, 8, 10, 14, 29, 15, 717, DateTimeKind.Local).AddTicks(3638), "Moment Creating.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 10, 14, 29, 15, 717, DateTimeKind.Local).AddTicks(3638), "Mountain View", 3, 1000.00m });

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("f7b65d2c-12e6-4fd7-a689-b2958119009f"), "Pool, Gym, Bar", 750.00m, new DateTime(2022, 8, 10, 14, 29, 15, 717, DateTimeKind.Local).AddTicks(3623), "Unmatched authentic luxury.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 10, 14, 29, 15, 717, DateTimeKind.Local).AddTicks(3634), "Bliss View", 5, 500.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("27ee7595-1fb9-4678-b8bf-d19e7e1793c3"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("f7b65d2c-12e6-4fd7-a689-b2958119009f"));
        }
    }
}
