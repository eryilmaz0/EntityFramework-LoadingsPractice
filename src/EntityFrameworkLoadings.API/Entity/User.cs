namespace EntityFrameworkLoadings.API.Entity;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    //Navigation Property
    public virtual  ICollection<Order> Orders { get; set; }
}