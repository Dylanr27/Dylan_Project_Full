using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoption.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeysToListingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Listing_AnimalId",
                table: "Listing",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_ProductId",
                table: "Listing",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Animal_AnimalId",
                table: "Listing",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Product_ProductId",
                table: "Listing",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Animal_AnimalId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Product_ProductId",
                table: "Listing");

            migrationBuilder.DropIndex(
                name: "IX_Listing_AnimalId",
                table: "Listing");

            migrationBuilder.DropIndex(
                name: "IX_Listing_ProductId",
                table: "Listing");
        }
    }
}
