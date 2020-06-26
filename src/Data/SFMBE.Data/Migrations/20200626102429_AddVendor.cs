using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFMBE.Data.Migrations
{
    public partial class AddVendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendor_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_BagId",
                table: "Vendor",
                column: "BagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
