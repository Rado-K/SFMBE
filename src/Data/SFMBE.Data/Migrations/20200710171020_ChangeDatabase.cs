using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFMBE.Data.Migrations
{
    public partial class ChangeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Bags_BagId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Gears_GearId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Bags_BagId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Gears_GearId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Bags");

            migrationBuilder.DropTable(
                name: "Gears");

            migrationBuilder.DropIndex(
                name: "IX_Items_BagId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_GearId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Characters_BagId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "BagId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "GearId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BagId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearId",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CharacterId",
                table: "Items",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Characters_CharacterId",
                table: "Items",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Characters_CharacterId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CharacterId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "BagId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GearId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BagId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GearId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gears", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_BagId",
                table: "Items",
                column: "BagId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_GearId",
                table: "Items",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BagId",
                table: "Characters",
                column: "BagId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearId",
                table: "Characters",
                column: "GearId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bags_IsDeleted",
                table: "Bags",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Bags_BagId",
                table: "Characters",
                column: "BagId",
                principalTable: "Bags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Gears_GearId",
                table: "Characters",
                column: "GearId",
                principalTable: "Gears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Bags_BagId",
                table: "Items",
                column: "BagId",
                principalTable: "Bags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Gears_GearId",
                table: "Items",
                column: "GearId",
                principalTable: "Gears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
