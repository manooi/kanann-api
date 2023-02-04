namespace App.Model;

public class GetAssignmentQuery
{
    public int AcademicYearId { get; set; }
    public string SubjectCode { get; set; }
    public int? AssignmentId { get; set; }
}