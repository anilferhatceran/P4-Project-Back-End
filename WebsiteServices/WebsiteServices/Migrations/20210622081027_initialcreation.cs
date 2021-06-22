using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteServices.Migrations
{
    public partial class initialcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                columns: table => new
                {
                    companyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(nullable: true),
                    companyURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.companyID);
                });

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

            migrationBuilder.CreateTable(
                name: "NameGenUsers",
                columns: table => new
                {
                    nameGenUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameGenID = table.Column<int>(nullable: true),
                    userID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameGenUsers", x => x.nameGenUserID);
                    table.ForeignKey(
                        name: "FK_NameGenUsers_NamesGenerated_nameGenID",
                        column: x => x.nameGenID,
                        principalTable: "NamesGenerated",
                        principalColumn: "nameGenID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NameGenUsers_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewDetails",
                columns: table => new
                {
                    reviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyID = table.Column<int>(nullable: true),
                    userID = table.Column<int>(nullable: true),
                    reviewTitle = table.Column<string>(nullable: true),
                    reviewText = table.Column<string>(nullable: true),
                    reviewDate = table.Column<string>(nullable: true),
                    reviewRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewDetails", x => x.reviewID);
                    table.ForeignKey(
                        name: "FK_ReviewDetails_CompanyProfiles_companyID",
                        column: x => x.companyID,
                        principalTable: "CompanyProfiles",
                        principalColumn: "companyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDetails_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NameGenUsers_nameGenID",
                table: "NameGenUsers",
                column: "nameGenID");

            migrationBuilder.CreateIndex(
                name: "IX_NameGenUsers_userID",
                table: "NameGenUsers",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDetails_companyID",
                table: "ReviewDetails",
                column: "companyID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDetails_userID",
                table: "ReviewDetails",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NameGenUsers");

            migrationBuilder.DropTable(
                name: "ReviewDetails");

            migrationBuilder.DropTable(
                name: "TextsGenerated");

            migrationBuilder.DropTable(
                name: "TypingSessions");

            migrationBuilder.DropTable(
                name: "NamesGenerated");

            migrationBuilder.DropTable(
                name: "CompanyProfiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
