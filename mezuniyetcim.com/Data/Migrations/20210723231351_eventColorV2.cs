using Microsoft.EntityFrameworkCore.Migrations;

namespace mezuniyetcim.com.Data.Migrations
{
    public partial class eventColorV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_colors_events_eventsid",
                table: "colors");

            migrationBuilder.DropIndex(
                name: "IX_colors_eventsid",
                table: "colors");

            migrationBuilder.DropColumn(
                name: "color",
                table: "events");

            migrationBuilder.DropColumn(
                name: "eventsid",
                table: "colors");

            migrationBuilder.AddColumn<int>(
                name: "colorid",
                table: "events",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_colors_colorid",
                table: "events");

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

            migrationBuilder.AddColumn<int>(
                name: "eventsid",
                table: "colors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_colors_eventsid",
                table: "colors",
                column: "eventsid");

            migrationBuilder.AddForeignKey(
                name: "FK_colors_events_eventsid",
                table: "colors",
                column: "eventsid",
                principalTable: "events",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
