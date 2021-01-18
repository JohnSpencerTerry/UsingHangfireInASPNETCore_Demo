using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsingHangfireInASPNETCore_Demo.Data.Migrations
{
    public partial class CreateImageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OriginalImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspNetUserID = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ContainerOrDirectory = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginalImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageVariant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrginalImageId = table.Column<int>(nullable: false),
                    VariantDescription = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ContainerOrDirectory = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    OriginalImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageVariant_OriginalImage_OriginalImageId",
                        column: x => x.OriginalImageId,
                        principalTable: "OriginalImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageVariant_OriginalImageId",
                table: "ImageVariant",
                column: "OriginalImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageVariant");

            migrationBuilder.DropTable(
                name: "OriginalImage");
        }
    }
}
