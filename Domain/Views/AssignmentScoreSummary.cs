namespace Domain.Views;

public class AssignmentScoreSummary
{
    public string StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int AcademicYearId { get; set; }
    public string AcademicYearName { get; set; }
    public string SubjectCode { get; set; }
    public string SubjectName { get; set; }
    public decimal Score { get; set; }
    public decimal TotalScore { get; set; }
    public decimal Credit { get; set; }
}