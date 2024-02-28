using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoption.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newEntryForListingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Listing",
                columns: new[] { "Id", "AnimalId", "Price", "ProductId" },
                values: new object[] { 2, null, 120.00m, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
