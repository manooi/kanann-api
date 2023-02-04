using App.Model;
using App.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Authorize("all users")]
[Route("[controller]/[action]")]
public class AssignmentController : ControllerBase
{
    private readonly IAssignmentRepository _assignmentRepository;
    
    public AssignmentController(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }

    [HttpGet()]
    public IActionResult Assignment([FromQuery] GetAssignmentQuery query)
    {
        return Ok(_assignmentRepository.GetAssignment(query));
    }
    
    [HttpPost()]
    [ActionName("Assignment")]
    public IActionResult CreateAssignment([FromBody] CreateAssignmentRequest req)
    {
        _assignmentRepository.CreateAssignment(req);
        return NoContent();
    }
    
    [HttpPut()]
    [Route("{id:int}")]
    [ActionName("Assignment")]
    public IActionResult UpdateAssignment([FromRoute] int id, [FromBody] UpdateAssignmentRequest req)
    {
        _assignmentRepository.UpdateAssignmentById(id, req);
        return NoContent();
    }
    
    [HttpDelete()]
    [Route("{id:int}")]
    [ActionName("Assignment")]
    public IActionResult DeleteAssignment([FromRoute] int id)
    {
        _assignmentRepository.DeleteAsisgment(id);
        return NoContent();
    }

    [HttpGet()]
    public IActionResult Scoring([FromQuery] GetTransactionAssignmentQuery req)
    {
        return Ok( _assignmentRepository.GetScoring(req));
    }
    
    [HttpPut()]
    [ActionName("Scoring")]
    public IActionResult UpdateScoring([FromBody] UpdateScoringRequest req)
    {
        _assignmentRepository.UpdateScoring(req);
        return NoContent();
    }
}