using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARPATicket.API.Migrations
{
    /// <inheritdoc />
    public partial class TicketsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_assignedUserID",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "assignedUserID",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_assignedUserID",
                table: "Tickets",
                column: "assignedUserID",
                principalTable: "Users",
                principalColumn: "userID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_assignedUserID",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "assignedUserID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_assignedUserID",
                table: "Tickets",
                column: "assignedUserID",
                principalTable: "Users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
