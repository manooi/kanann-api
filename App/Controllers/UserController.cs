using DataAccess;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

[ApiController]
[Authorize("all users")]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly KananContext _context;

    public UserController(KananContext ctx)
    {
        _context = ctx;
    }

    [HttpGet()]
    public IActionResult GetUser(string userName)
    {
        // Add logic to check if requested user is in the same
        // role as requesting user
        var subClaim = HttpContext.User.FindFirst(c => c.Type == AppConstant.Auth0SubClaimType).Value;

        // if role is student, no need to check for clientId
        var role = HttpContext.User.FindFirst(c => c.Type == AppConstant.Auth0RoleClaimType).Value;
        if (role.Contains("student"))
        {
            var result = _context.PageMasters.Where(p => p.PageId == 7 || p.PageId == 8)
                .Select(s => new
                {
                    s.PageId,
                    s.PageName
                }).ToList();
            return Ok(result);
        }

        // else, check for user name and clientId
        var user = _context.Users.FirstOrDefault(u => u.UserName == userName && u.Auth0ClientId == subClaim);
        if (user != null)
        {
            var result = _context.UserRolePage
                .Where(s => s.UserName == userName)
                .Select(s => new
                {
                    s.PageId,
                    s.PageName
                }).Distinct().ToList();

            if (result.Count == 0)
            {
                return Unauthorized();
            }

            return Ok(result);
        }

        return Unauthorized();
    }
}