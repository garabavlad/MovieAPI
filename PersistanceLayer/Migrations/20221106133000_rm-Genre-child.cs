using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistanceLayer.Migrations
{
    public partial class rmGenrechild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DropColumn(
                name: "ChildMovieGenreId",
                table: "Genres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
