namespace Domain;

public class Page
{
   public Page()
   {
      Roles = new List<Role>();
   }
   public int PageId { get; set; } 
   public string PageName { get; set; }
   
   public List<Role> Roles { get; set; }
}