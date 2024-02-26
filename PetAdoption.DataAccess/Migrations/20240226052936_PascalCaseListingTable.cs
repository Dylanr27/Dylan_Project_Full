using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoption.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PascalCaseListingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Listing",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "animalId",
                table: "Listing",
                newName: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Listing",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "AnimalId",
                table: "Listing",
                newName: "animalId");
        }
    }
}
