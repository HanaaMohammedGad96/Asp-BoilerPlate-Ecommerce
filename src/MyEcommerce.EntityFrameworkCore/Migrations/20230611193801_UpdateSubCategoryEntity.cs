using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEcommerce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSubCategoryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslation_AppCategories_CoreId1",
                table: "CategoryTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTranslation",
                table: "CategoryTranslation");

            migrationBuilder.DropColumn(
                name: "DescriptionArabic",
                table: "AppSubCategories");

            migrationBuilder.DropColumn(
                name: "DescriptionEnglish",
                table: "AppSubCategories");

            migrationBuilder.DropColumn(
                name: "NameArabic",
                table: "AppSubCategories");

            migrationBuilder.DropColumn(
                name: "NameEnglish",
                table: "AppSubCategories");

            migrationBuilder.RenameTable(
                name: "CategoryTranslation",
                newName: "AppCategoryTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslation_CoreId1",
                table: "AppCategoryTranslations",
                newName: "IX_AppCategoryTranslations_CoreId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCategoryTranslations",
                table: "AppCategoryTranslations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppSubCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 65536, nullable: true),
                    CoreId = table.Column<int>(type: "int", nullable: false),
                    CoreId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSubCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSubCategoryTranslations_AppSubCategories_CoreId1",
                        column: x => x.CoreId1,
                        principalTable: "AppSubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppSubCategoryTranslations_CoreId1",
                table: "AppSubCategoryTranslations",
                column: "CoreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCategoryTranslations_AppCategories_CoreId1",
                table: "AppCategoryTranslations",
                column: "CoreId1",
                principalTable: "AppCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCategoryTranslations_AppCategories_CoreId1",
                table: "AppCategoryTranslations");

            migrationBuilder.DropTable(
                name: "AppSubCategoryTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCategoryTranslations",
                table: "AppCategoryTranslations");

            migrationBuilder.RenameTable(
                name: "AppCategoryTranslations",
                newName: "CategoryTranslation");

            migrationBuilder.RenameIndex(
                name: "IX_AppCategoryTranslations_CoreId1",
                table: "CategoryTranslation",
                newName: "IX_CategoryTranslation_CoreId1");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionArabic",
                table: "AppSubCategories",
                type: "nvarchar(max)",
                maxLength: 65536,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEnglish",
                table: "AppSubCategories",
                type: "nvarchar(max)",
                maxLength: 65536,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameArabic",
                table: "AppSubCategories",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEnglish",
                table: "AppSubCategories",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTranslation",
                table: "CategoryTranslation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslation_AppCategories_CoreId1",
                table: "CategoryTranslation",
                column: "CoreId1",
                principalTable: "AppCategories",
                principalColumn: "Id");
        }
    }
}
