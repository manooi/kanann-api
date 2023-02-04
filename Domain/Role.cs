namespace Domain;

public class Role
{
    public Role()
    {
        Users = new List<User>();
        Pages = new List<Page>();
    }
    
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public List<User> Users { get; set; }
    public List<Page> Pages { get; set; }

}