using Microsoft.EntityFrameworkCore.Migrations;

namespace Labo.H05.RateAMovie.Web.Migrations
{
    public partial class MovieRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Ratings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Ratings");
        }
    }
}
