namespace App.Model;

public class CreateAssignmentRequest
{
    public int AcademicYearId { get; set; }
    public string SubjectCode { get; set; }
    public string AssignmentName { get; set; }
    public decimal? TotalScore { get; set; }
    public List<int> AssignedClassRooms { get; set; }
}