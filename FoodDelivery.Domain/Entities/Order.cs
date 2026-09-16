namespace FoodDelivery.Domain.Entities;

/// <summary>
/// Заказ клиента в ресторане
/// </summary>
public class Order
{
    /// <summary>
    /// Уникальный идентификатор заказа
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор клиента, оформившего заказ
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Клиент, оформивший заказ
    /// </summary>
    public Customer Customer { get; set; } = null!;

    /// <summary>
    /// Идентификатор ресторана, в котором оформлен заказ
    /// </summary>
    public int RestaurantId { get; set; }

    /// <summary>
    /// Ресторан, в котором оформлен заказ
    /// </summary>
    public Restaurant Restaurant { get; set; } = null!;

    /// <summary>
    /// Дата и время оформления заказа
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата и время доставки заказа
    /// </summary>
    public DateTime DeliveredAt { get; set; }

    /// <summary>
    /// Итоговая сумма заказа в рублях
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Список позиций заказа
    /// </summary>
    public List<OrderItem> Items { get; set; } = new();
}