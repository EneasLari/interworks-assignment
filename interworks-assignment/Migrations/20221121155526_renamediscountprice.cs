using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace interworks_assignment.Migrations
{
    public partial class renamediscountprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscounPrice",
                table: "Discounts",
                newName: "DiscountedPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountedPrice",
                table: "Discounts",
                newName: "DiscounPrice");
        }
    }
}
