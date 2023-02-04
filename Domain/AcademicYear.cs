using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
  public class AcademicYear
  {
    public int AcademicYearId { get; set; }
    public string AcademicYearName { get; set; }
    public bool DeleteFlag { get; set;}
  }
}