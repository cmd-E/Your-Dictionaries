using Microsoft.EntityFrameworkCore.Migrations;

namespace YourDictionaries.EntityFramework.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phrases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expression = table.Column<string>(nullable: false),
                    Meaning = table.Column<string>(nullable: false),
                    Translation = table.Column<string>(nullable: true),
                    Transcription = table.Column<string>(nullable: true),
                    AssignedDictionaryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phrases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phrases_Dictionaries_AssignedDictionaryId",
                        column: x => x.AssignedDictionaryId,
                        principalTable: "Dictionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
