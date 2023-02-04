using System.ComponentModel.DataAnnotations;

namespace Domain;

public class TransactionAttendance
{
    public string StudentId { get; set; }
    public DateTime? AttendTime { get; set; }
    public string? Remark { get; set; }
    public int AttendanceStatusId { get; set; }
    
    public Student Student { get; set; }
    public int TransactionClassId { get; set; }
    public AttendanceStatus AttendanceStatus { get; set; }
}