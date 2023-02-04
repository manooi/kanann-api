using System.Linq;
using System.Security.Claims;
using App.Model;
using App.Service;
using AutoWrapper.Wrappers;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static App.AppConstant;

namespace App.Controllers;

[ApiController]
[Authorize("all users")]
[Route("[controller]/[action]")]
public class CommonController : ControllerBase
{
    private readonly ILogger<CommonController> _logger;
    private readonly IMasterRepository _masterRepository;
    private readonly KananContext _context;

    public CommonController(ILogger<CommonController> logger, KananContext ctx, IMasterRepository masterRepository)
    {
        _logger = logger;
        _context = ctx;
        _masterRepository = masterRepository;
    }

    [HttpGet()]
    public ActionResult<IEnumerable<DropdownModel<int>>> AcademicYear()
    {
        var years = _context.MasterAcademicYears.Where(y => !y.DeleteFlag).Distinct().ToList();
        var dropdown = years.Select(year => new DropdownModel<int>
                { Value = year.AcademicYearId, Text = year.AcademicYearName })
            .ToList();
        return Ok(dropdown);
        // return new ApiResponse("Kuy", dropdown, 200);
    }

    [HttpGet()]
    public ActionResult<IEnumerable<DropdownModel<string>>> ClassRoom(int academicYearId, string subjectCode)
    {
        var query = from c in _context.ClassRooms
            from s in c.Subjects
            where s.SubjectCode == subjectCode
            select new
            {
                c.ClassRoomId,
                c.ClassRoomName
            };
        
        var dropdown = query.Select(c => new DropdownModel<int>
        {
            Value = c.ClassRoomId,
            Text = c.ClassRoomName
        }).ToList();

        return Ok(dropdown);
    }

    [HttpGet()]
    public ActionResult<List<DropdownModel<int>>> MasterName()
    {
        var masters = _context.MasterDatabases.ToList();
        var dropdown = masters.Select(master => new DropdownModel<int>
            { Value = master.MasterDataBaseId, Text = master.MasterName }).ToList();
        return Ok(dropdown);
    }

    [HttpGet()]
    public ActionResult<List<MasterMapping>> MasterMapping(int masterId)
    {
        return Ok(_masterRepository.GetMasterMapping(masterId));
    }

    [HttpPost()]
    public ActionResult GetDatabase([FromBody] GetDatabaseRequest request)
    {
        switch (request.Database)
        {
            case ((int)MasterId.AcademicYear):
                var academicYears = _context.MasterAcademicYears.Where(master => !master.DeleteFlag).ToList();
                return Ok(academicYears);
            case ((int)MasterId.Teacher):
                var teachers = _context.Teachers.ToList();
                return Ok(teachers);
            case ((int)MasterId.ClassRoom):
                var classRooms = _context.ClassRooms.Where(c => c.MasterAcademicYearId == request.AcademicYearId).ToList();
                return Ok(classRooms);
            case ((int)MasterId.Subject):
                var subjects = _context.Subjects.Where(s => s.AcademicYearId == request.AcademicYearId).ToList();
                return Ok(subjects);
            case ((int)MasterId.Student):
                var students = _context.Students
                    .Include(s => s.ClassRoom)
                    .Select(s => new
                    {
                        s.Sequence,
                        s.StudentId,
                        s.Gender,
                        s.FirstName,
                        s.LastName,
                        s.ClassRoom.MasterAcademicYearId,
                        s.ClassRoom.ClassRoomName
                    })
                    .Where(s => s.MasterAcademicYearId == request.AcademicYearId)
                    .OrderBy(s => s.ClassRoomName)
                    .ThenBy(s => s.Sequence)
                    .ToList();
                return Ok(students);
        }

        return Ok();
    }

    [HttpPost()]
    public ActionResult GetStudents()
    {
        var x = _context.Students.FromSqlRaw("SELECT * FROM Students").Include(s => s.ClassRoom)
            .Select(s => new
            {
                s.Sequence,
                s.StudentId,
                s.Gender,
                s.FirstName,
                s.LastName,
                s.ClassRoom.MasterAcademicYearId,
                s.ClassRoom.ClassRoomName
            })
            .OrderBy(s => s.ClassRoomName)
            .ThenBy(s => s.Sequence)
            .ToList();

        return Ok(x);
    }

    [HttpPost()]
    public IActionResult GetSubjectByAcademicYear([FromBody] GetSubjectRequest request)
    {
        var subClaim = HttpContext.User.FindFirst(c => c.Type == AppConstant.Auth0SubClaimType)?.Value;
        var user = _context.Users.FirstOrDefault(u => u.Auth0ClientId == subClaim);
        
        var teacher = _context.Teachers.FirstOrDefault(t => t.UserId == user.UserId);
        if (teacher == null)
        {
            return NotFound();
        }
        
        try
        {
            var subjects = _context.Subjects
                .Where(s=> s.Teachers.Any(t => t.TeacherId == teacher.TeacherId))
                .Where(s => s.AcademicYearId == request.AcademicYearId)
                .Select(s => new { s.SubjectCode, s.SubjectName })
                .ToList();
            return Ok(subjects);
        }
        catch
        {
            return BadRequest();
        }
    }
}