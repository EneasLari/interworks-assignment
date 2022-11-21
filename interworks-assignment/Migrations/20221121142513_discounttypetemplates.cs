using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace interworks_assignment.Migrations
{
    public partial class discounttypetemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DiscountTypes");

            migrationBuilder.AddColumn<int>(
                name: "DiscountTypeTemplateId",
                table: "DiscountTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DiscountTypeTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountTypeTemplates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountTypes_DiscountTypeTemplateId",
                table: "DiscountTypes",
                column: "DiscountTypeTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountTypes_DiscountTypeTemplates_DiscountTypeTemplateId",
                table: "DiscountTypes",
                column: "DiscountTypeTemplateId",
                principalTable: "DiscountTypeTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountTypes_DiscountTypeTemplates_DiscountTypeTemplateId",
                table: "DiscountTypes");

            migrationBuilder.DropTable(
                name: "DiscountTypeTemplates");

            migrationBuilder.DropIndex(
                name: "IX_DiscountTypes_DiscountTypeTemplateId",
                table: "DiscountTypes");

            migrationBuilder.DropColumn(
                name: "DiscountTypeTemplateId",
                table: "DiscountTypes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DiscountTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
