namespace EntityFrameworkLoadings.API.Entity;

public class Order
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public decimal Price { get; set; }
    public string OrderItems { get; set; }
    
    //Navigation Property
    public virtual User User { get; set; }
}