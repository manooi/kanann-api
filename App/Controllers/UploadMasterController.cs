using System.Linq;
using App.Model;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

[ApiController]
[Authorize("all users")]
[Route("[controller]/[action]")]
public class UploadMasterController : ControllerBase
{
    private readonly ILogger<CommonController> _logger;
    private readonly KananContext _context;

    public UploadMasterController(ILogger<CommonController> logger, KananContext _ctx)
    {
        _logger = logger;
        _context = _ctx;
    }

    [HttpPost()]
    public ActionResult UploadStudentMaster([FromBody] ValidateMasterStudentRequest req)
    {
        try
        {
            var studentToBeAdded = new List<Student>();
            req.Data.ForEach(dt =>

            {
                var academicYear =
                    _context.MasterAcademicYears.FirstOrDefault(y => y.AcademicYearName == dt.AcademicYearName);

                if (academicYear == null)
                {
                    throw new Exception($"Class room or Academic year not found for student: {dt.StudentId}");
                };
                
                var currentClassRoom = _context.ClassRooms.FirstOrDefault(
                    c => c.ClassRoomName == dt.ClassRoomName &&
                         c.MasterAcademicYearId == academicYear.AcademicYearId);

                if (currentClassRoom == null)
                {
                    throw new Exception($"Class room or Academic year not found for student: {dt.StudentId}");
                }

                studentToBeAdded.Add(new Student
                {
                    StudentId = dt.StudentId,
                    Sequence = dt.Sequence,
                    Gender = dt.Gender,
                    FirstName = dt.FirstName,
                    LastName = dt.LastName,
                    ClassRoom = currentClassRoom
                });
            });
            _context.Students.AddRange(studentToBeAdded);
            // _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();
            return NoContent();
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
}