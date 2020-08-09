using Microsoft.EntityFrameworkCore.Migrations;

namespace RubiksCubeAlgorithmsWebApi.Migrations
{
    public partial class CaseEntity_Rename_ImagePath_To_ImageRelativePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Cases",
                newName: "ImageRelativePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageRelativePath",
                table: "Cases",
                newName: "ImagePath");
        }
    }
}
