using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    ClassRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassRoomName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MasterAcademicYearId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.ClassRoomId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MasterAcademicYears",
                columns: table => new
                {
                    AcademicYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AcademicYearName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeleteFlag = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAcademicYears", x => x.AcademicYearId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MasterDatabases",
                columns: table => new
                {
                    MasterDataBaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MasterName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDatabases", x => x.MasterDataBaseId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    SubjectCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubjectName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StudyPlan = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "ClassRoomId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MasterMappings",
                columns: table => new
                {
                    MasterDatabaseId = table.Column<int>(type: "int", nullable: false),
                    Variable = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sequence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterMappings", x => new { x.Variable, x.Name, x.MasterDatabaseId });
                    table.ForeignKey(
                        name: "FK_MasterMappings_MasterDatabases_MasterDatabaseId",
                        column: x => x.MasterDatabaseId,
                        principalTable: "MasterDatabases",
                        principalColumn: "MasterDataBaseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassRoomSubject",
                columns: table => new
                {
                    ClassRoomsClassRoomId = table.Column<int>(type: "int", nullable: false),
                    SubjectsSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoomSubject", x => new { x.ClassRoomsClassRoomId, x.SubjectsSubjectId });
                    table.ForeignKey(
                        name: "FK_ClassRoomSubject_ClassRooms_ClassRoomsClassRoomId",
                        column: x => x.ClassRoomsClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "ClassRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoomSubject_Subjects_SubjectsSubjectId",
                        column: x => x.SubjectsSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransactionClasses",
                columns: table => new
                {
                    TransactionClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionClasses", x => x.TransactionClassId);
                    table.ForeignKey(
                        name: "FK_TransactionClasses_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "ClassRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionClasses_MasterAcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "MasterAcademicYears",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionClasses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    SubjectsSubjectId = table.Column<int>(type: "int", nullable: false),
                    TeachersTeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectsSubjectId, x.TeachersTeacherId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subjects_SubjectsSubjectId",
                        column: x => x.SubjectsSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teachers_TeachersTeacherId",
                        column: x => x.TeachersTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransactionAttendances",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TransactionClassId = table.Column<int>(type: "int", nullable: false),
                    AttendTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionAttendances", x => new { x.StudentId, x.TransactionClassId });
                    table.ForeignKey(
                        name: "FK_TransactionAttendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionAttendances_TransactionClasses_TransactionClassId",
                        column: x => x.TransactionClassId,
                        principalTable: "TransactionClasses",
                        principalColumn: "TransactionClassId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoomSubject_SubjectsSubjectId",
                table: "ClassRoomSubject",
                column: "SubjectsSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterMappings_MasterDatabaseId",
                table: "MasterMappings",
                column: "MasterDatabaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassRoomId",
                table: "Students",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeachersTeacherId",
                table: "SubjectTeacher",
                column: "TeachersTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionAttendances_TransactionClassId",
                table: "TransactionAttendances",
                column: "TransactionClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionClasses_AcademicYearId",
                table: "TransactionClasses",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionClasses_ClassRoomId",
                table: "TransactionClasses",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionClasses_SubjectId",
                table: "TransactionClasses",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassRoomSubject");

            migrationBuilder.DropTable(
                name: "MasterMappings");

            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.DropTable(
                name: "TransactionAttendances");

            migrationBuilder.DropTable(
                name: "MasterDatabases");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TransactionClasses");

            migrationBuilder.DropTable(
                name: "ClassRooms");

            migrationBuilder.DropTable(
                name: "MasterAcademicYears");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
