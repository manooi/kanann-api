namespace App.Model;

public class UpdateAttendance
{
    public int TransactionClassId { get; set; }
    public List<EachStudentAttendance> StudentAttendances { get; set; }

    public UpdateAttendance()
    {
        StudentAttendances = new List<EachStudentAttendance>();
    }
}

public class EachStudentAttendance
{
    public int AttendanceStatusId { get; set; }
    public string StudentId { get; set; }
    public DateTime? AttendTime { get; set; } 
}