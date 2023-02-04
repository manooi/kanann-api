namespace Domain;

public class AssignmentMapping
{
    public int AssignmentMappingId { get; set; }
    public int AssignmentId { get; set; }
    public int ClassRoomId { get; set; }
    public DateTime? AssignedDate { get; set; }
    public DateTime? DeadlineDate { get; set; }
    
    public Assignment Assignment { get; set; }
    public ClassRoom ClassRoom { get; set; }
}