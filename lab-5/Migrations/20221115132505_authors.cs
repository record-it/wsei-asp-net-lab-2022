using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab5.Migrations
{
    /// <inheritdoc />
    public partial class authors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 25, 5, 45, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 25, 5, 45, DateTimeKind.Local).AddTicks(7603));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 25, 5, 45, DateTimeKind.Local).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 25, 5, 45, DateTimeKind.Local).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 11, 15, 14, 25, 5, 45, DateTimeKind.Local).AddTicks(7615));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 11, 15, 11, 22, 47, 165, DateTimeKind.Local).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 11, 15, 11, 22, 47, 165, DateTimeKind.Local).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 11, 15, 11, 22, 47, 165, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 11, 15, 11, 22, 47, 165, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 11, 15, 11, 22, 47, 165, DateTimeKind.Local).AddTicks(5922));
        }
    }
}
