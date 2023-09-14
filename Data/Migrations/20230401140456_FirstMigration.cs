    using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Capstone1.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { "4b10ae32-133c-4de1-8e2a-fa8b1ac5fca9", "Private Panio Lessons", 18L, "Private Piano Lessons (0 to 4 Years)" },
                    { "8e812948-eac1-4aec-b740-8d3265cfe3df", "Early Years Music", 18L, "Early Years Music" },
                    { "a451ec1c-a5dc-4fea-a671-0374cf9b9894", "PreSchool Piano Foundation", 18L, "PreSchool Piano Foundation (2 to 4 Years)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
