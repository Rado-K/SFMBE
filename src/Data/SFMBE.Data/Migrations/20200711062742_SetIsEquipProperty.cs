using Microsoft.EntityFrameworkCore.Migrations;

namespace SFMBE.Data.Migrations
{
    public partial class SetIsEquipProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEquip",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEquip",
                table: "Items");
        }
    }
}
