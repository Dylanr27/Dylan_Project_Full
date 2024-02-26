using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoption.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createListingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: true),
                    animalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Listing",
                columns: new[] { "Id", "Price", "animalId", "productId" },
                values: new object[] { 1, 100.00m, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listing");
        }
    }
}
