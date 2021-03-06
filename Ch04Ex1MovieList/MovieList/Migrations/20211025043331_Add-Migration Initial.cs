using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieList.Migrations
{
    public partial class AddMigrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Name", "Rating", "Year" },
                values: new object[] { 1, "Cashblanca", 3, 1942 });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Name", "Rating", "Year" },
                values: new object[] { 2, "Wonder Woman", 3, 2017 });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Name", "Rating", "Year" },
                values: new object[] { 3, "Moonstruck", 4, 1988 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
