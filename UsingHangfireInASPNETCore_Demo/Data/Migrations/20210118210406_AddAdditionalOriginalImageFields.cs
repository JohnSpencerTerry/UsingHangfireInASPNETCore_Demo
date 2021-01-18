using Microsoft.EntityFrameworkCore.Migrations;

namespace UsingHangfireInASPNETCore_Demo.Data.Migrations
{
    public partial class AddAdditionalOriginalImageFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "OriginalImage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MD5Hash",
                table: "OriginalImage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MD5Hash",
                table: "ImageVariant",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "OriginalImage");

            migrationBuilder.DropColumn(
                name: "MD5Hash",
                table: "OriginalImage");

            migrationBuilder.DropColumn(
                name: "MD5Hash",
                table: "ImageVariant");
        }
    }
}
