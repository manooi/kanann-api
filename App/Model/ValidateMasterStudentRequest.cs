using Domain;

namespace App.Model
{
  public class ValidateMasterStudentRequest
  {
    public List<StudentData> Data { get; set; }
  }

  public class StudentData
  {
    public string StudentId { get; set; }
    public int Sequence { get; set; }
    public string Gender { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string AcademicYearName { get; set; }
    public string ClassRoomName { get; set; }
  }
}