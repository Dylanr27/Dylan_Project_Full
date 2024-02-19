using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoptionMVC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OneCatAddedToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "Id", "AdoptionStatus", "Age", "Breed", "Description", "Gender", "Name", "Size", "Species" },
                values: new object[] { 1, "Available", 7, "Russian Blue", "Rescue", "Boy", "Gizmo", "M", "Cat" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
