using Microsoft.EntityFrameworkCore.Migrations;

namespace YourDictionaries.EntityFramework.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Dictionaries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_UserId",
                table: "Dictionaries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dictionaries_Users_UserId",
                table: "Dictionaries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dictionaries_Users_UserId",
                table: "Dictionaries");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Dictionaries_UserId",
                table: "Dictionaries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dictionaries");
        }
    }
}
