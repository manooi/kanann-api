using App.Model;
using App.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Authorize("all users")]
[Route("[controller]/[action]")]
public class CheckController : ControllerBase
{
    private readonly ITransactionClassRepository _transactionClassRepository;
    private readonly IRFIDRepository _rfidRepository;

    public CheckController(ITransactionClassRepository repo, IRFIDRepository rfidRepository)
    {
        _transactionClassRepository = repo;
        _rfidRepository = rfidRepository;
    }

    
    [HttpGet()]
    public IActionResult Class([FromQuery] GetTransactionClassQuery query)
    {
        return Ok(_transactionClassRepository.GetTransactionClass(query));
    }
    
    [HttpPost()]
    [ActionName("Class")]
    public IActionResult ClassPost([FromBody] PostTransactionClass req)
    {
        _transactionClassRepository.AddTransaction(req);
        return NoContent();
    }
    
    [HttpDelete()]
    [Route("{id:int}")]
    [ActionName("Class")]
    public IActionResult DeleteClass([FromRoute] int id)
    {
        _transactionClassRepository.RemoveTransaction(id);
        return NoContent();
    }
    
    [HttpGet()]
    public IActionResult Check(int transactionClassId)
    {
        var result = _transactionClassRepository.GetCheck(transactionClassId);
        return Ok(result);
    }
    
    [HttpPut()]
    [ActionName("Check")]
    public IActionResult CheckPut([FromBody] UpdateAttendance req )
    {
        _transactionClassRepository.UpdateAttendance(req);
        return NoContent();
    }

    [HttpGet()]
    public IActionResult RFIDMapping()
    {
        return Ok(_rfidRepository.GetRFIDMapping());
    }
    
}