namespace Domain
{
  public class Teacher
  {
    public int TeacherId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string Description { get; set; }
    public List<Subject> Subjects {get; set;}
    public int? UserId { get; set; }
    public User? User { get; set; }
    public Teacher()
    {
     Subjects = new List<Subject>(); 
    }
  }
}