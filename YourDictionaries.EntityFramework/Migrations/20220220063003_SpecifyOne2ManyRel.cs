using Microsoft.EntityFrameworkCore.Migrations;

namespace YourDictionaries.EntityFramework.Migrations
{
    public partial class SpecifyOne2ManyRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phrases_Dictionaries_AssignedDictionaryId",
                table: "Phrases");

            migrationBuilder.DropIndex(
                name: "IX_Phrases_AssignedDictionaryId",
                table: "Phrases");

            migrationBuilder.DropColumn(
                name: "AssignedDictionaryId",
                table: "Phrases");

            migrationBuilder.AddColumn<int>(
                name: "DictionaryId",
                table: "Phrases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Phrases_DictionaryId",
                table: "Phrases",
                column: "DictionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phrases_Dictionaries_DictionaryId",
                table: "Phrases",
                column: "DictionaryId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phrases_Dictionaries_DictionaryId",
                table: "Phrases");

            migrationBuilder.DropIndex(
                name: "IX_Phrases_DictionaryId",
                table: "Phrases");

            migrationBuilder.DropColumn(
                name: "DictionaryId",
                table: "Phrases");

            migrationBuilder.AddColumn<int>(
                name: "AssignedDictionaryId",
                table: "Phrases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phrases_AssignedDictionaryId",
                table: "Phrases",
                column: "AssignedDictionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phrases_Dictionaries_AssignedDictionaryId",
                table: "Phrases",
                column: "AssignedDictionaryId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
