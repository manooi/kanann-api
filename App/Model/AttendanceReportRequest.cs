using Microsoft.Build.Framework;

namespace App.Model;

public class AttendanceReportRequest
{
    public int? AcademicYearId { get; set; }
    
    public int? ClassRoomId { get; set; }
    
    public  int? SubjectId { get; set; }
}