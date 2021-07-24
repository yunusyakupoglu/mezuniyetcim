using Microsoft.EntityFrameworkCore.Migrations;

namespace mezuniyetcim.com.Data.Migrations
{
    public partial class eventColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_colors_events_eventsid",
                table: "colors");

            migrationBuilder.DropIndex(
                name: "IX_colors_eventsid",
                table: "colors");

            migrationBuilder.DropColumn(
                name: "eventsid",
                table: "colors");
        }
    }
}
