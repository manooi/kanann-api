using App.Model;
using Domain;
namespace App.Service;
public interface  IAssignmentRepository
{
    public IEnumerable<GetAssignmentResponse> GetAssignment(GetAssignmentQuery req);
    public void CreateAssignment(CreateAssignmentRequest req);
    void DeleteAsisgment(int assignmentId);
    
    public GetScoringResponse GetScoring(GetTransactionAssignmentQuery req);

    public void UpdateScoring(UpdateScoringRequest req);
    
    public void UpdateAssignmentById(int assignmentId, UpdateAssignmentRequest req);
}