namespace Domain;

public class User
{
    public int UserId { get; set; }
    public string Auth0ClientId { get; set; }
    public string UserName { get; set; }
    public List<Role> Roles { get; set; }
    
    public User()
    {
        Roles = new List<Role>();
    }
}