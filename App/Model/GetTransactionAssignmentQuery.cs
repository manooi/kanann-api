namespace App.Model;

public class GetTransactionAssignmentQuery
{
    public int AcademicYearId { get; set; }
    public string SubjectCode { get; set; }
    public int ClassRoomId { get; set; }
}