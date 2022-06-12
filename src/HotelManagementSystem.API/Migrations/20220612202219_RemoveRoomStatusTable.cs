using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.API.Migrations
{
    public partial class RemoveRoomStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomsStatus_RoomStatusId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomsStatus");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomStatusId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomStatusId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ReservationDate",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "PayTime",
                table: "Payments",
                newName: "PaymentDate");

            migrationBuilder.AddColumn<string>(
                name: "RoomStatus",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateCreated",
                table: "Guests",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomStatus",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Payments",
                newName: "PayTime");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomStatusId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "RoomsStatus",
                columns: table => new
                {
                    RoomStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomStatusName = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsStatus", x => x.RoomStatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomsStatus_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId",
                principalTable: "RoomsStatus",
                principalColumn: "RoomStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
