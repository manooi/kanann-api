using Domain;

namespace App.Model;

public class GetScoringResponse
{
    public int AcademicYearId { get; set; }
    public string AcademicYearName { get; set; }
    public int ClassRoomId { get; set; }
    public string ClassRoomName { get; set; }
    public string SubjectCode { get; set; }
    public string SubjectName { get; set; }
    public List<AssignmentHeader> AssignmentHeaders { get; set; }
}

public class AssignmentHeader
{
    public int AssignmentMappingId { get; set; }
    public int AssignmentId { get; set; }
    public string AssignmentName { get; set; }
    public decimal? TotalScore { get; set; }
    public List<AssignmentScore> Scores { get; set; }
}

public class AssignmentScore
{
    public int AssignmentMappingId { get; set; }
    public string StudentId { get; set; }
    public int Sequence { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal? Score { get; set; }
}