using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaManagementSystem.Migrations
{
    public partial class trailerURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrailerURL",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrailerURL",
                table: "Movies");
        }
    }
}
