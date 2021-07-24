using Microsoft.EntityFrameworkCore.Migrations;

namespace mezuniyetcim.com.Data.Migrations
{
    public partial class ColorV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "color",
                table: "colors",
                newName: "colorName");

            migrationBuilder.AddColumn<string>(
                name: "colorCode",
                table: "colors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "colorCode",
                table: "colors");

            migrationBuilder.RenameColumn(
                name: "colorName",
                table: "colors",
                newName: "color");
        }
    }
}
