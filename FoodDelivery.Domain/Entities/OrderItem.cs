namespace FoodDelivery.Domain.Entities;

/// <summary>
/// Отдельная позиция в заказе
/// </summary>
public class OrderItem
{
    /// <summary>
    /// Уникальный идентификатор позиции заказа
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Идентификатор блюда
    /// </summary>
    public int DishId { get; set; }

    /// <summary>
    /// Блюдо, добавленное в заказ
    /// </summary>
    public Dish Dish { get; set; } = null!;

    /// <summary>
    /// Количество единиц блюда
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Цена одной единицы блюда на момент оформления заказа
    /// </summary>
    public decimal Price { get; set; }
}