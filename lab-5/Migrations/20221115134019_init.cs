using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab5.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 40, 18, 960, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 40, 18, 960, DateTimeKind.Local).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 40, 18, 960, DateTimeKind.Local).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 40, 18, 960, DateTimeKind.Local).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 40, 18, 960, DateTimeKind.Local).AddTicks(5083));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 25, 50, 3, DateTimeKind.Local).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 25, 50, 3, DateTimeKind.Local).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 25, 50, 3, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 25, 50, 3, DateTimeKind.Local).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 25, 50, 3, DateTimeKind.Local).AddTicks(6167));
        }
    }
}
