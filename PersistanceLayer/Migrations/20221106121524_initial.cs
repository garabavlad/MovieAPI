using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistanceLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildMovieGenreId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentMovieId = table.Column<long>(type: "bigint", nullable: false),
                    ParentGenreId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_ParentGenreId",
                        column: x => x.ParentGenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_ParentMovieId",
                        column: x => x.ParentMovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentMovieId = table.Column<long>(type: "bigint", nullable: false),
                    ParentUserId = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_ParentMovieId",
                        column: x => x.ParentMovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ParentUserId",
                        column: x => x.ParentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "ChildMovieGenreId", "Name" },
                values: new object[,]
                {
                    { 1L, 0L, "Romance" },
                    { 2L, 0L, "Action" },
                    { 3L, 0L, "Mystery" },
                    { 4L, 0L, "Fantasy" },
                    { 5L, 0L, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1L, "Movie1" },
                    { 2L, "Movie2" },
                    { 3L, "Movie3" },
                    { 4L, "Movie4" },
                    { 5L, "Movie5" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username" },
                values: new object[,]
                {
                    { 1L, "Vlad" },
                    { 2L, "John" },
                    { 3L, "Alison" }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "Id", "ParentGenreId", "ParentMovieId" },
                values: new object[,]
                {
                    { 3L, 5L, 2L },
                    { 5L, 3L, 3L },
                    { 7L, 2L, 4L },
                    { 8L, 1L, 5L },
                    { 9L, 4L, 5L }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ParentMovieId", "ParentUserId", "Rating" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, 4m },
                    { 2L, 1L, 1L, 3m },
                    { 3L, 2L, 2L, 5m },
                    { 4L, 2L, 2L, 4m },
                    { 5L, 3L, 2L, 1m },
                    { 6L, 1L, 1L, 2m },
                    { 7L, 1L, 1L, 3m },
                    { 8L, 1L, 1L, 4m },
                    { 9L, 3L, 3L, 4m },
                    { 10L, 3L, 3L, 5m },
                    { 11L, 3L, 3L, 4m },
                    { 12L, 5L, 1L, 3m },
                    { 15L, 3L, 2L, 2m },
                    { 18L, 3L, 1L, 4m },
                    { 25L, 2L, 1L, 5m },
                    { 26L, 2L, 3L, 5m },
                    { 27L, 3L, 3L, 4m },
                    { 28L, 4L, 3L, 3m },
                    { 29L, 5L, 2L, 4m },
                    { 30L, 3L, 2L, 3m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_ParentGenreId",
                table: "MovieGenres",
                column: "ParentGenreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_ParentMovieId",
                table: "MovieGenres",
                column: "ParentMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ParentMovieId",
                table: "Reviews",
                column: "ParentMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ParentUserId",
                table: "Reviews",
                column: "ParentUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
