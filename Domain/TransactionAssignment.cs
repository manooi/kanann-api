namespace Domain;

public class TransactionAssignment
{
    public int AssignmentMappingId { get; set; }
    public string StudentId { get; set; }
    public decimal? Score { get; set; }
    
    public AssignmentMapping AssignmentMapping { get; set; }
    public Student Student { get; set; }
}