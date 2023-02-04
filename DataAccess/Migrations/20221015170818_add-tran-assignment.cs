using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addtranassignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionAssignment",
                columns: table => new
                {
                    AssignmentMappingId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Score = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionAssignment", x => new { x.AssignmentMappingId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_TransactionAssignment_AssignmentMappings_AssignmentMappingId",
                        column: x => x.AssignmentMappingId,
                        principalTable: "AssignmentMappings",
                        principalColumn: "AssignmentMappingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionAssignment_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionAssignment_StudentId",
                table: "TransactionAssignment",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionAssignment");
        }
    }
}
