using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addattendancestatusintran : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendanceStatusId",
                table: "TransactionAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionAttendances_AttendanceStatusId",
                table: "TransactionAttendances",
                column: "AttendanceStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionAttendances_AttendanceStatus_AttendanceStatusId",
                table: "TransactionAttendances",
                column: "AttendanceStatusId",
                principalTable: "AttendanceStatus",
                principalColumn: "AttendanceStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionAttendances_AttendanceStatus_AttendanceStatusId",
                table: "TransactionAttendances");

            migrationBuilder.DropIndex(
                name: "IX_TransactionAttendances_AttendanceStatusId",
                table: "TransactionAttendances");

            migrationBuilder.DropColumn(
                name: "AttendanceStatusId",
                table: "TransactionAttendances");
        }
    }
}
