using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Student
{
  [MaxLength(10)]
  public string StudentId { get; set; }
  public int Sequence { get; set; }
  [MaxLength(1)]
  public string Gender { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string? MiddleName { get; set; }
  public ClassRoom ClassRoom { get; set; }
  
  public int? UserId { get; set; }
  public User? User { get; set; }
}
