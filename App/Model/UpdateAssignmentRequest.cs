namespace App.Model;

public class UpdateAssignmentRequest
{
    public string AssignmentName { get; set; }
    public decimal? TotalScore { get; set; }
    public List<int> AssignedClassRooms { get; set; }
}