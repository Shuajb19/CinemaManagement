using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaManagementSystem.Migrations
{
    public partial class Coupon_Movie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Movies_MovieId",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_MovieId",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Coupons");

            migrationBuilder.CreateTable(
                name: "Coupons_Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons_Movies", x => new { x.CouponId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Coupons_Movies_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "CouponId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coupons_Movies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_Movies_MovieId",
                table: "Coupons_Movies",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons_Movies");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_MovieId",
                table: "Coupons",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Movies_MovieId",
                table: "Coupons",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
