using Microsoft.EntityFrameworkCore.Migrations;

namespace RubiksCubeAlgorithmsWebApi.Migrations
{
    public partial class MethodAndStep_AddDescriptionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Steps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Methods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Methods");
        }
    }
}
