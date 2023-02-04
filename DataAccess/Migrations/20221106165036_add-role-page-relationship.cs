using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addrolepagerelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageRole",
                columns: table => new
                {
                    PagesPageId = table.Column<int>(type: "int", nullable: false),
                    RolesRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageRole", x => new { x.PagesPageId, x.RolesRoleId });
                    table.ForeignKey(
                        name: "FK_PageRole_PageMasters_PagesPageId",
                        column: x => x.PagesPageId,
                        principalTable: "PageMasters",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageRole_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PageRole_RolesRoleId",
                table: "PageRole",
                column: "RolesRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageRole");
        }
    }
}
