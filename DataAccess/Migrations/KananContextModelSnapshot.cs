﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(KananContext))]
    partial class KananContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ClassRoomSubject", b =>
                {
                    b.Property<int>("ClassRoomsClassRoomId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectsSubjectId")
                        .HasColumnType("int");

                    b.HasKey("ClassRoomsClassRoomId", "SubjectsSubjectId");

                    b.HasIndex("SubjectsSubjectId");

                    b.ToTable("ClassRoomSubject");
                });

            modelBuilder.Entity("Domain.AcademicYear", b =>
                {
                    b.Property<int>("AcademicYearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AcademicYearName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AcademicYearId");

                    b.ToTable("MasterAcademicYears");
                });

            modelBuilder.Entity("Domain.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AcademicYearId")
                        .HasColumnType("int");

                    b.Property<string>("AssignmentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalScore")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("AssignmentId");

                    b.HasIndex("AcademicYearId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Domain.AssignmentMapping", b =>
                {
                    b.Property<int>("AssignmentMappingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("AssignedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeadlineDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("AssignmentMappingId");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("AssignmentMappings");
                });

            modelBuilder.Entity("Domain.AttendanceStatus", b =>
                {
                    b.Property<int>("AttendanceStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AttendanceStatusId");

                    b.ToTable("AttendanceStatus");
                });

            modelBuilder.Entity("Domain.ClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClassRoomName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("MasterAcademicYearId")
                        .HasColumnType("int");

                    b.HasKey("ClassRoomId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Domain.MasterDatabase", b =>
                {
                    b.Property<int>("MasterDataBaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MasterName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MasterDataBaseId");

                    b.ToTable("MasterDatabases");
                });

            modelBuilder.Entity("Domain.MasterMapping", b =>
                {
                    b.Property<string>("Variable")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("MasterDatabaseId")
                        .HasColumnType("int");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.HasKey("Variable", "Name", "MasterDatabaseId");

                    b.HasIndex("MasterDatabaseId");

                    b.ToTable("MasterMappings");
                });

            modelBuilder.Entity("Domain.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PageId");

                    b.ToTable("PageMasters");
                });

            modelBuilder.Entity("Domain.RFIDMapping", b =>
                {
                    b.Property<int>("RFIDMappingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RFID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("RFIDMappingId");

                    b.HasIndex("StudentId");

                    b.ToTable("RfidMappings");
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Property<string>("StudentId")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AcademicYearId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Credit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("StudyPlan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Domain.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TeacherId");

                    b.HasIndex("UserId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Domain.TransactionAssignment", b =>
                {
                    b.Property<int>("AssignmentMappingId")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .HasColumnType("varchar(10)");

                    b.Property<decimal?>("Score")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("AssignmentMappingId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("TransactionAssignment");
                });

            modelBuilder.Entity("Domain.TransactionAttendance", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("TransactionClassId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AttendTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AttendanceStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.HasKey("StudentId", "TransactionClassId");

                    b.HasIndex("AttendanceStatusId");

                    b.HasIndex("TransactionClassId");

                    b.ToTable("TransactionAttendances");
                });

            modelBuilder.Entity("Domain.TransactionClass", b =>
                {
                    b.Property<int>("TransactionClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AcademicYearId")
                        .HasColumnType("int");

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<int>("ClassWeight")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("TransactionClassId");

                    b.HasIndex("AcademicYearId");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("SubjectId");

                    b.ToTable("TransactionClasses");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Auth0ClientId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Views.AssignmentScore", b =>
                {
                    b.Property<int>("AcademicYearId")
                        .HasColumnType("int");

                    b.Property<string>("AcademicYearName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AssignmentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("TotalScore")
                        .HasColumnType("decimal(65,30)");

                    b.ToView("AssignmentScore");
                });

            modelBuilder.Entity("Domain.Views.AttendacePercentage", b =>
                {
                    b.Property<int>("AcademicYearId")
                        .HasColumnType("int");

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<int>("GainedClassWeight")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TotalClassWeight")
                        .HasColumnType("int");

                    b.ToView("AttendacePercentage");
                });

            modelBuilder.Entity("Domain.Views.AttendacePercentageForDisplay", b =>
                {
                    b.Property<string>("AcademicYearName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("GainedClassWeight")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TotalClassWeight")
                        .HasColumnType("int");

                    b.ToView("AttendacePercentageForDisplay");
                });

            modelBuilder.Entity("Domain.Views.AttendaceReport", b =>
                {
                    b.Property<int>("AcademicYearId")
                        .HasColumnType("int");

                    b.Property<string>("AcademicYearName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<string>("ClassRoomName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<int>("Status1")
                        .HasColumnType("int");

                    b.Property<int>("Status2")
                        .HasColumnType("int");

                    b.Property<int>("Status3")
                        .HasColumnType("int");

                    b.Property<int>("Status4")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToView("AttendaceReport");
                });

            modelBuilder.Entity("Domain.Views.LessThanEightyPercentAttendance", b =>
                {
                    b.Property<string>("AcademicYearName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ClassRoomName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MasterAcademicYearId")
                        .HasColumnType("int");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToView("LessThanEightyPercentAttendance");
                });

            modelBuilder.Entity("Domain.Views.UserRolePage", b =>
                {
                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToView("UserRolePage");
                });

            modelBuilder.Entity("PageRole", b =>
                {
                    b.Property<int>("PagesPageId")
                        .HasColumnType("int");

                    b.Property<int>("RolesRoleId")
                        .HasColumnType("int");

                    b.HasKey("PagesPageId", "RolesRoleId");

                    b.HasIndex("RolesRoleId");

                    b.ToTable("PageRole");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesRoleId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("RolesRoleId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsSubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersTeacherId")
                        .HasColumnType("int");

                    b.HasKey("SubjectsSubjectId", "TeachersTeacherId");

                    b.HasIndex("TeachersTeacherId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("ClassRoomSubject", b =>
                {
                    b.HasOne("Domain.ClassRoom", null)
                        .WithMany()
                        .HasForeignKey("ClassRoomsClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Assignment", b =>
                {
                    b.HasOne("Domain.AcademicYear", "AcademicYear")
                        .WithMany()
                        .HasForeignKey("AcademicYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicYear");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Domain.AssignmentMapping", b =>
                {
                    b.HasOne("Domain.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("ClassRoom");
                });

            modelBuilder.Entity("Domain.MasterMapping", b =>
                {
                    b.HasOne("Domain.MasterDatabase", "MasterDatabase")
                        .WithMany("MasterMappings")
                        .HasForeignKey("MasterDatabaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterDatabase");
                });

            modelBuilder.Entity("Domain.RFIDMapping", b =>
                {
                    b.HasOne("Domain.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.HasOne("Domain.ClassRoom", "ClassRoom")
                        .WithMany("Students")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("ClassRoom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Teacher", b =>
                {
                    b.HasOne("Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.TransactionAssignment", b =>
                {
                    b.HasOne("Domain.AssignmentMapping", "AssignmentMapping")
                        .WithMany()
                        .HasForeignKey("AssignmentMappingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignmentMapping");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.TransactionAttendance", b =>
                {
                    b.HasOne("Domain.AttendanceStatus", "AttendanceStatus")
                        .WithMany()
                        .HasForeignKey("AttendanceStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TransactionClass", null)
                        .WithMany("Attendance")
                        .HasForeignKey("TransactionClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttendanceStatus");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.TransactionClass", b =>
                {
                    b.HasOne("Domain.AcademicYear", "AcademicYear")
                        .WithMany()
                        .HasForeignKey("AcademicYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicYear");

                    b.Navigation("ClassRoom");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("PageRole", b =>
                {
                    b.HasOne("Domain.Page", null)
                        .WithMany()
                        .HasForeignKey("PagesPageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Domain.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("Domain.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.ClassRoom", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Domain.MasterDatabase", b =>
                {
                    b.Navigation("MasterMappings");
                });

            modelBuilder.Entity("Domain.TransactionClass", b =>
                {
                    b.Navigation("Attendance");
                });
#pragma warning restore 612, 618
        }
    }
}
