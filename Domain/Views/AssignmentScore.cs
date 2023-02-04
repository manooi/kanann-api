namespace Domain.Views;

public class AssignmentScore
{
    public string StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int AcademicYearId { get; set; }
    public string AcademicYearName { get; set; }
    public string SubjectCode { get; set; }
    public string SubjectName { get; set; }
    public string AssignmentName { get; set; }
    public decimal Score { get; set; }
    public decimal TotalScore { get; set; }
    public decimal Credit { get; set; }
}