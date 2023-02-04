namespace Domain;

public class TransactionClass
{
    public int TransactionClassId { get; set; }
    public int AcademicYearId { get; set; }
    public int SubjectId { get; set; }
    public int ClassRoomId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int ClassWeight { get; set; }
    
    public AcademicYear AcademicYear { get; set; }
    public Subject Subject { get; set; }
    public ClassRoom ClassRoom { get; set; }
    
    public List<TransactionAttendance> Attendance { get; set; }

    public TransactionClass()
    {
        Attendance = new List<TransactionAttendance>();
    }
}