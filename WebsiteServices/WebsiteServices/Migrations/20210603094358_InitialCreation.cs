using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteServices.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NamesGenerated",
                columns: table => new
                {
                    nameGenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maleNames = table.Column<string>(nullable: true),
                    femaleNames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NamesGenerated", x => x.nameGenID);
                });

            migrationBuilder.CreateTable(
                name: "TextsGenerated",
                columns: table => new
                {
                    wordID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    word = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextsGenerated", x => x.wordID);
                });

            migrationBuilder.CreateTable(
                name: "TypingSessions",
                columns: table => new
                {
                    sessionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    charactersTyped = table.Column<int>(nullable: false),
                    wordsPerMin = table.Column<int>(nullable: false),
                    time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypingSessions", x => x.sessionID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userEmail = table.Column<string>(nullable: true),
                    passwordHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NamesGenerated");

            migrationBuilder.DropTable(
                name: "TextsGenerated");

            migrationBuilder.DropTable(
                name: "TypingSessions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
