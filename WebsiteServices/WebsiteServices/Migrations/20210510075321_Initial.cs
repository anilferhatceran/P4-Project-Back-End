using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteServices.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "NamesGenerated",
                columns: table => new
                {
                    nameGenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    generatedName = table.Column<string>(nullable: true),
                    maleNames = table.Column<string>(nullable: true),
                    femaleNames = table.Column<string>(nullable: true),
                    userID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NamesGenerated", x => x.nameGenID);
                    table.ForeignKey(
                        name: "FK_NamesGenerated_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NamesGenerated_userID",
                table: "NamesGenerated",
                column: "userID");
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
