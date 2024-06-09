// Order.cs
public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }



    
     // Pending, Processing, Shipped, Delivered, etc.
    // Other properties as needed
}
