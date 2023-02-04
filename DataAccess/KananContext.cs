using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Views;

namespace DataAccess;

public class KananContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<AcademicYear> MasterAcademicYears { get; set; }
    public DbSet<MasterDatabase> MasterDatabases { get; set; }
    public DbSet<MasterMapping> MasterMappings { get; set; }
    public DbSet<TransactionClass> TransactionClasses { get; set; }
    public DbSet<TransactionAttendance> TransactionAttendances { get; set; }
    public DbSet<AttendanceStatus> AttendanceStatus { get; set; }
    public DbSet<RFIDMapping> RfidMappings { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<AssignmentMapping> AssignmentMappings { get; set; }
    public DbSet<TransactionAssignment> TransactionAssignment { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Page> PageMasters { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    // Views
    public DbSet<AttendacePercentage> AttendacePercentages { get; set; }
    public DbSet<UserRolePage> UserRolePage { get; set; }
    public DbSet<LessThanEightyPercentAttendance> LessThanEightyPercentAttendance { get; set; }
    public DbSet<AttendacePercentageForDisplay> AttendacePercentageForDisplay { get; set; }
    public DbSet<AssignmentScore> AssignmentScore { get; set; }
    public DbSet<AssignmentScoreSummary> AssignmentScoreSummary { get; set; }
    public DbSet<AttendaceReport> AttendaceReport { get; set; }

    public KananContext(DbContextOptions<KananContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MasterMapping>()
            .HasKey(a => new { a.Variable, a.Name, a.MasterDatabaseId });

        modelBuilder.Entity<TransactionAttendance>()
            .HasKey(a => new { a.StudentId, a.TransactionClassId });

        modelBuilder.Entity<TransactionAssignment>()
            .HasKey(a => new { a.AssignmentMappingId, a.StudentId });

        modelBuilder.Entity<AttendacePercentage>().HasNoKey().ToView(nameof(AttendacePercentage));
        modelBuilder.Entity<UserRolePage>().HasNoKey().ToView(nameof(Domain.Views.UserRolePage));
        modelBuilder.Entity<LessThanEightyPercentAttendance>().HasNoKey().ToView(nameof(Domain.Views.LessThanEightyPercentAttendance));
        modelBuilder.Entity<AttendacePercentageForDisplay>().HasNoKey().ToView(nameof(Domain.Views.AttendacePercentageForDisplay));
        modelBuilder.Entity<AssignmentScore>().HasNoKey().ToView(nameof(Domain.Views.AssignmentScore));
        modelBuilder.Entity<AssignmentScoreSummary>().HasNoKey().ToView(nameof(Domain.Views.AssignmentScoreSummary));
        modelBuilder.Entity<AttendaceReport>().HasNoKey().ToView(nameof(Domain.Views.AttendaceReport));

        // modelBuilder.Entity<Assignment>(b =>
        // {
        //     b.HasOne(a => a.AcademicYear)
        //         .WithMany()
        //         .HasForeignKey(a => a.AcademicYearId)
        //         .OnDelete(DeleteBehavior.SetNull)
        //         .IsRequired();
        //
        //     b.HasOne(a => a.Subject)
        //         .WithMany()
        //         .HasForeignKey(a => a.SubjectId)
        //         .OnDelete(DeleteBehavior.SetNull)
        //         .IsRequired();
        //
        //     b.Navigation(a => a.AcademicYear);
        //
        //     b.Navigation(a => a.Subject);
        // });
    }
}