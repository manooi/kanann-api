namespace App.Model;

public class UpdateScoringRequest
{
    public List<UpdatedScore> Scores { get; set; }
}

public class UpdatedScore
{
    public int AssignmentMappingId { get; set; }
    public string StudentId { get; set; }
    public decimal? Score { get; set; }
}