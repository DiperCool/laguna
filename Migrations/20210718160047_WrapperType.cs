using Microsoft.EntityFrameworkCore.Migrations;

namespace Laguna.Migrations
{
    public partial class WrapperType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WrapperType",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WrapperType",
                table: "Products");
        }
    }
}
