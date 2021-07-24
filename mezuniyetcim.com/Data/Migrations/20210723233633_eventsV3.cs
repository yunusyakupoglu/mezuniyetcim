using Microsoft.EntityFrameworkCore.Migrations;

namespace mezuniyetcim.com.Data.Migrations
{
    public partial class eventsV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_colors_colorid",
                table: "events");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropIndex(
                name: "IX_events_colorid",
                table: "events");

            migrationBuilder.DropColumn(
                name: "colorid",
                table: "events");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "events");

            migrationBuilder.AddColumn<int>(
                name: "colorid",
                table: "events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_events_colorid",
                table: "events",
                column: "colorid");

            migrationBuilder.AddForeignKey(
                name: "FK_events_colors_colorid",
                table: "events",
                column: "colorid",
                principalTable: "colors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
