using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoptionMVC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateGenderToSexInAnimalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Animal",
                newName: "Sex");

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PhotoUrl", "Sex" },
                values: new object[] { "/lib/Images/pexels-monica-oprea-9718154.jpg", "Male" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Animal",
                newName: "Gender");

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Gender", "PhotoUrl" },
                values: new object[] { "Boy", "\"C:\\Renton-Technical-College\\Winter-2024\\CSI-340\\pexels-nothing-ahead-17987994 (1).jpg\"" });
        }
    }
}
