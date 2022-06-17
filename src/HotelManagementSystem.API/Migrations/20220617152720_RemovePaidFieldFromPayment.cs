using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.API.Migrations
{
    public partial class RemovePaidFieldFromPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Payments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
