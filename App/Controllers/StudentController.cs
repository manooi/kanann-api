using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    [Route("[controller]/[action]")]
    // [Authorize("all users")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly KananContext _context;

        public StudentController(KananContext ctx)
        {
            _context = ctx;
        }

        [HttpGet()]
        public IActionResult Attendance(string userName)
        {
            // implement sub claim logic later
            // var subClaim = HttpContext.User.FindFirst(c => c.Type == AppConstant.Auth0SubClaimType)?.Value;
            // var user = _context.Users.FirstOrDefault(u => u.Auth0ClientId == subClaim);

            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            var student = _context.Students.FirstOrDefault(u => u.UserId == user.UserId);
            var result = _context.AttendacePercentageForDisplay.Where(a => a.StudentId == student.StudentId);
            return Ok(result);
        }

        [HttpGet()]
        public IActionResult AssignmentScore(string userName, int? academicYearId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            var student = _context.Students.FirstOrDefault(u => u.UserId == user.UserId);
            var result = _context.AssignmentScore.Where(a => a.StudentId == student.StudentId);
            
            if (academicYearId != null)
            {
                result = result.Where(s => s.AcademicYearId == academicYearId);
            }

            return Ok(result);
        }
        
        [HttpGet()]
        public IActionResult AssignmentScoreSummary(string userName, int? academicYearId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            var student = _context.Students.FirstOrDefault(u => u.UserId == user.UserId);
            var result = _context.AssignmentScoreSummary.Where(a => a.StudentId == student.StudentId);
            
            if (academicYearId != null)
            {
                result = result.Where(s => s.AcademicYearId == academicYearId);
            }

            return Ok(result);
        }
    }
}