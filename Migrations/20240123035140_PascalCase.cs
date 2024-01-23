using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoptionMVC.Migrations
{
    /// <inheritdoc />
    public partial class PascalCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "species",
                table: "Animal",
                newName: "Species");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "Animal",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Animal",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Animal",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "breed",
                table: "Animal",
                newName: "Breed");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Animal",
                newName: "Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Species",
                table: "Animal",
                newName: "species");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Animal",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Animal",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Animal",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Breed",
                table: "Animal",
                newName: "breed");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Animal",
                newName: "age");
        }
    }
}
