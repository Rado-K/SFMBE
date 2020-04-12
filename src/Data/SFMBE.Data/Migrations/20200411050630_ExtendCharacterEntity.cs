using Microsoft.EntityFrameworkCore.Migrations;

namespace SFMBE.Data.Migrations
{
    public partial class ExtendCharacterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Character",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Character");
        }
    }
}
