using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace interworks_assignment.Migrations
{
    public partial class customerfield3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "CustomerFields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "CustomerFields",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "CustomerFields");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "CustomerFields");
        }
    }
}
