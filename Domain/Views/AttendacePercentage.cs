namespace Domain.Views;

public class AttendacePercentage
{
    public string StudentId { get; set; }
    public int AcademicYearId { get; set; }
    public int SubjectId { get; set; }
    public int ClassRoomId { get; set; }
    public int GainedClassWeight { get; set; }
    public int TotalClassWeight { get; set; }
}