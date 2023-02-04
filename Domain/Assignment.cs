namespace Domain;

public class Assignment
{
    public int AssignmentId { get; set; }
    public string AssignmentName { get; set; }
    public int SubjectId { get; set; }
    public int AcademicYearId { get; set; }
    public decimal? TotalScore { get; set; }
 
    public Subject Subject { get; set; }
    public AcademicYear AcademicYear { get; set; }
}