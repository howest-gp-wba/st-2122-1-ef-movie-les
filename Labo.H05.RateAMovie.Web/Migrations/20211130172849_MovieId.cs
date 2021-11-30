using Microsoft.EntityFrameworkCore.Migrations;

namespace Labo.H05.RateAMovie.Web.Migrations
{
    public partial class MovieId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Ratings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
