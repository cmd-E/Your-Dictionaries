using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourDictionaries.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DictionaryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phrases",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Phrase = table.Column<string>(nullable: false),
                    Definition = table.Column<string>(nullable: false),
                    Transcription = table.Column<string>(nullable: true),
                    Translation = table.Column<string>(nullable: true),
                    AssignedDictionaryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phrases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phrases_Dictionaries_AssignedDictionaryId",
                        column: x => x.AssignedDictionaryId,
                        principalTable: "Dictionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phrases_AssignedDictionaryId",
                table: "Phrases",
                column: "AssignedDictionaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phrases");

            migrationBuilder.DropTable(
                name: "Dictionaries");
        }
    }
}
