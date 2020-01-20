using Microsoft.EntityFrameworkCore.Migrations;

namespace YPS.Persistence.Migrations
{
    public partial class SecondInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "UpcomingEvents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tytle",
                table: "UpcomingEvents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "UpcomingEvents");

            migrationBuilder.DropColumn(
                name: "Tytle",
                table: "UpcomingEvents");
        }
    }
}
