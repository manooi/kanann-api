using Domain;

namespace App.Model;

public class GetAssignmentResponse
{
    public int AssignmentId { get; set; }
    public string AssignmentName { get; set; }
    public int SubjectId { get; set; }
    public int AcademicYearId { get; set; }
    public decimal? TotalScore { get; set; }
    public List<AssignedClassRoom> AssignedClassRooms { get; set; }
}

public class AssignedClassRoom
{
    public int AssignmentId { get; set; }
    public int ClassRoomId { get; set; }
    public string ClassRoomName { get; set; }
}