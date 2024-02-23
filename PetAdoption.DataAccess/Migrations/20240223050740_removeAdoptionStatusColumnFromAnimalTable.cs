using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoption.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeAdoptionStatusColumnFromAnimalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdoptionStatus",
                table: "Animal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdoptionStatus",
                table: "Animal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdoptionStatus",
                value: "Available");
        }
    }
}
