using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App
{
  public static class AppConstant
  {
    public enum MasterId : int
    {
      AcademicYear = 1,
      Teacher = 2,
      ClassRoom = 3,
      Subject = 4,
      Student = 5,
    }

    public static readonly string Auth0RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

    public static readonly string Auth0SubClaimType =
      "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";


  }

}