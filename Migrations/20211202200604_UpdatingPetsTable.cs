using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class UpdatingPetsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "colorType",
                table: "Pets",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "breedType",
                table: "Pets",
                newName: "breed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "color",
                table: "Pets",
                newName: "colorType");

            migrationBuilder.RenameColumn(
                name: "breed",
                table: "Pets",
                newName: "breedType");
        }
    }
}
