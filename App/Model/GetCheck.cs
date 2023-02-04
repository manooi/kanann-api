using Domain;

namespace App.Model;

public class GetCheck
{
    public List<AttendanceCheckResult> TransactionAttendance { get; set; }
    public string SubjectCode { get; set; }
    public string SubjectName { get; set; }
    public string ClassRoomName { get; set; }
    public DateTime ClassDate { get; set; }
}

public class AttendanceCheckResult
{
    public string StudentId { get; set; }
    public DateTime? AttendTime { get; set; }
    public string? Remark { get; set; }
    public int AttendanceStatusId { get; set; }
    public int GainedClassWeight { get; set; }
    public int TotalClassWeight { get; set; }
    public Student Student { get; set; }
    public int TransactionClassId { get; set; }
    public AttendanceStatus AttendanceStatus { get; set; }
}