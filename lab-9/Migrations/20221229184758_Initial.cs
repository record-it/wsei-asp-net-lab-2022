using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lab9.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "first_name", "last_name", "pesel" },
                values: new object[,]
                {
                    { 1, "Robert", "Martin", "no" },
                    { 2, "Ewa", "Kowal", "1111111111" },
                    { 3, "Karol", "Matrix", "2222222222" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Created", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 29, 19, 47, 58, 729, DateTimeKind.Local).AddTicks(9993), new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET 6.0.0" },
                    { 2, new DateTime(2022, 12, 29, 19, 47, 58, 730, DateTimeKind.Local).AddTicks(27), new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# 10.0" },
                    { 3, new DateTime(2022, 12, 29, 19, 47, 58, 730, DateTimeKind.Local).AddTicks(32), new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java 19" },
                    { 4, new DateTime(2022, 12, 29, 19, 47, 58, 730, DateTimeKind.Local).AddTicks(36), new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript" },
                    { 5, new DateTime(2022, 12, 29, 19, 47, 58, 730, DateTimeKind.Local).AddTicks(41), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Node.js" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
