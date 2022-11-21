using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistanceLayer.Migrations
{
    public partial class seedingupdated : Migration
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

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ParentMovieId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[] { 3L, 1L, 2m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[] { 5L, 1L, 3m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "ParentMovieId", "Rating" },
                values: new object[] { 1L, 5m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[] { 2L, 2L, 4m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[] { 3L, 2L, 1m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[] { 4L, 2L, 2m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "ParentMovieId", "ParentUserId" },
                values: new object[] { 5L, 2L });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11L,
                column: "ParentMovieId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "ParentUserId", "Rating" },
                values: new object[] { 3L, 4m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[] { 16L, 4L, 3L, 3m });
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

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ParentMovieId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[] { 2L, 2L, 5m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[] { 2L, 2L, 4m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "ParentMovieId", "Rating" },
                values: new object[] { 3L, 1m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[] { 1L, 1L, 2m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[] { 1L, 1L, 3m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[] { 1L, 1L, 4m });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "ParentMovieId", "ParentUserId" },
                values: new object[] { 3L, 3L });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11L,
                column: "ParentMovieId",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "ParentUserId", "Rating" },
                values: new object[] { 2L, 2m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[,]
                {
                    { 10L, 3L, 3L, 5m },
                    { 12L, 5L, 1L, 3m },
                    { 18L, 3L, 1L, 4m },
                    { 25L, 2L, 1L, 5m },
                    { 26L, 2L, 3L, 5m },
                    { 27L, 3L, 3L, 4m },
                    { 28L, 4L, 3L, 3m },
                    { 29L, 5L, 2L, 4m },
                    { 30L, 3L, 2L, 3m }
                });
        }
    }
}
