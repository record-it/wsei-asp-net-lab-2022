using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab9.Migrations
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
                value: new DateTime(2022, 12, 29, 19, 49, 55, 753, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 12, 29, 19, 49, 55, 753, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 12, 29, 19, 49, 55, 753, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 12, 29, 19, 49, 55, 753, DateTimeKind.Local).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 12, 29, 19, 49, 55, 753, DateTimeKind.Local).AddTicks(6370));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 12, 29, 19, 47, 58, 729, DateTimeKind.Local).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 12, 29, 19, 47, 58, 730, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 12, 29, 19, 47, 58, 730, DateTimeKind.Local).AddTicks(32));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 12, 29, 19, 47, 58, 730, DateTimeKind.Local).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 12, 29, 19, 47, 58, 730, DateTimeKind.Local).AddTicks(41));
        }
    }
}
