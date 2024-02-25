using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetAdoption.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "AvailableQuantity", "Description", "Name", "PhotoUrl", "Type" },
                values: new object[,]
                {
                    { 1, 50, "Raw pork cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.", "Wild Coast Raw Pork", "/lib/Images/wild-coast-raw-pork.png", "Cat Food" },
                    { 2, 65, "Raw chicken cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.", "Wild Coast Raw Chicken", "/lib/Images/wild-coast-raw-chicken.jpg", "Cat Food" },
                    { 3, 45, "Raw beef cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.", "Wild Coast Raw Beef", "/lib/Images/wild-coast-raw-beef.jpg", "Cat Food" },
                    { 4, 30, "Raw turkey cat food. Freeze until ready to use. Good refrigerated for 3 days after inital thaw.", "Wild Coast Raw Turkey", "/lib/Images/wild-coast-raw-turkey.jpg", "Cat Food" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
