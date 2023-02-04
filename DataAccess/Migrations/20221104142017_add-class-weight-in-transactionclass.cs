using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addclassweightintransactionclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassWeight",
                table: "TransactionAttendances");

            migrationBuilder.AddColumn<int>(
                name: "ClassWeight",
                table: "TransactionClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassWeight",
                table: "TransactionClasses");

            migrationBuilder.AddColumn<int>(
                name: "ClassWeight",
                table: "TransactionAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
