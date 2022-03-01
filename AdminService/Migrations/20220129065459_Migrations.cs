using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminService.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Offer",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "Admins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Offer",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
