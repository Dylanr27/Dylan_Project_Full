using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoption.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RollbackProductUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Wild Coast Raw Pork");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Wild Coast Raw Chicken");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Wild Coast Raw Beef");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Wild Coast Raw Turkey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Name" },
                values: new object[] { "Wild Coast", "Raw Pork" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "Name" },
                values: new object[] { "Wild Coast", "Raw Chicken" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "Name" },
                values: new object[] { "Wild Coast", "Raw Beef" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Brand", "Name" },
                values: new object[] { "Wild Coast", "Raw Turkey" });
        }
    }
}
