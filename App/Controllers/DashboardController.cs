using App.Model;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

[ApiController]
// [Authorize("all users")]
[Route("[controller]/[action]")]
public class DashboardController : ControllerBase
{
    private readonly KananContext _context;

    public DashboardController(KananContext ctx)
    {
        _context = ctx;
    }

    [HttpGet()]
    public IActionResult LessThanEightyPercentAttendance()
    {
        return Ok(_context.LessThanEightyPercentAttendance.ToList());
    }
    
    [HttpGet()]
    public IActionResult AttendaceReport([FromQuery] AttendanceReportRequest req)
    {
        var query = _context.AttendaceReport.AsEnumerable();
        if (req.AcademicYearId != null)
        {
            query = query.Where(q => q.AcademicYearId == req.AcademicYearId);
        }

        if (req.ClassRoomId != null)
        {
            query = query.Where(q => q.ClassRoomId == req.ClassRoomId);
        }

        if (req.SubjectId != null)
        {
            query = query.Where(q => q.SubjectId == req.SubjectId);
        }

        return Ok(query.ToList());
    }
}