namespace FoodDelivery.Domain;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int DishId { get; set; }

    public Dish Dish { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}