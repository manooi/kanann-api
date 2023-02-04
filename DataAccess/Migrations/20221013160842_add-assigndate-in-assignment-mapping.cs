using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addassigndateinassignmentmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedDate",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "DeadlineDate",
                table: "Assignments");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedDate",
                table: "AssignmentMappings",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineDate",
                table: "AssignmentMappings",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedDate",
                table: "AssignmentMappings");

            migrationBuilder.DropColumn(
                name: "DeadlineDate",
                table: "AssignmentMappings");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedDate",
                table: "Assignments",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineDate",
                table: "Assignments",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
