namespace FoodDelivery.Domain;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;

    public int RestaurantId { get; set; }

    public Restaurant Restaurant { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime DeliveredAt { get; set; }

    public decimal TotalAmount { get; set; }

    public List<OrderItem> Items { get; set; } = new();
}