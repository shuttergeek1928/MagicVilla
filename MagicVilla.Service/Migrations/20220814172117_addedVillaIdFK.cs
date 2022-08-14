using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Service.Migrations
{
    public partial class addedVillaIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("1a78dc47-c1cc-46a6-ab80-206e01c7a1e7"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("66cdf66c-c35b-4c98-95ae-767ccd307882"));

            migrationBuilder.AddColumn<Guid>(
                name: "VillaId",
                table: "VillaNumber",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumber_VillaId",
                table: "VillaNumber",
                column: "VillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumber_Villa_VillaId",
                table: "VillaNumber",
                column: "VillaId",
                principalTable: "Villa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumber_Villa_VillaId",
                table: "VillaNumber");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumber_VillaId",
                table: "VillaNumber");

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("5b0ab470-03b9-4af1-be0e-f3f95e2d5362"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("a93c77ec-f40b-472c-a042-9e03f56a5660"));

            migrationBuilder.DropColumn(
                name: "VillaId",
                table: "VillaNumber");

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("1a78dc47-c1cc-46a6-ab80-206e01c7a1e7"), "Pool, Gym, Bar", 750.00m, new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4935), "Unmatched authentic luxury.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4946), "Bliss View", 5, 500.00m });

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenities", "Area", "CreatedDate", "Details", "ImageUrl", "LastUpdate", "Name", "Occupancy", "Rate" },
                values: new object[] { new Guid("66cdf66c-c35b-4c98-95ae-767ccd307882"), "Pool, Gym, Bar", 1000.00m, new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4950), "Moment Creating.", "https://e8rbh6por3n.exactdn.com/sites/uploads/2020/05/villa-la-gi-thumbnail.jpg?strip=all&lossy=1&ssl=1", new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(4951), "Mountain View", 3, 1000.00m });

            migrationBuilder.UpdateData(
                table: "VillaNumber",
                keyColumn: "VillaNumber",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(5078), new DateTime(2022, 8, 14, 22, 17, 29, 480, DateTimeKind.Local).AddTicks(5079) });
        }
    }
}
