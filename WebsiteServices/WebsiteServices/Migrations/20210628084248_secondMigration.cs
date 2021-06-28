using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteServices.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewDetails_CompanyProfiles_companyID",
                table: "ReviewDetails");

            migrationBuilder.AlterColumn<int>(
                name: "companyID",
                table: "ReviewDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewDetails_CompanyProfiles_companyID",
                table: "ReviewDetails",
                column: "companyID",
                principalTable: "CompanyProfiles",
                principalColumn: "companyID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewDetails_CompanyProfiles_companyID",
                table: "ReviewDetails");

            migrationBuilder.AlterColumn<int>(
                name: "companyID",
                table: "ReviewDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewDetails_CompanyProfiles_companyID",
                table: "ReviewDetails",
                column: "companyID",
                principalTable: "CompanyProfiles",
                principalColumn: "companyID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
