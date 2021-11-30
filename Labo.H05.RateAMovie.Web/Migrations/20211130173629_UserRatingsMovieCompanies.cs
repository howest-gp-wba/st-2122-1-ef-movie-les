using Microsoft.EntityFrameworkCore.Migrations;

namespace Labo.H05.RateAMovie.Web.Migrations
{
    public partial class UserRatingsMovieCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CompanyId",
                table: "Movies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Companies_CompanyId",
                table: "Movies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Companies_CompanyId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CompanyId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Movies");
        }
    }
}
