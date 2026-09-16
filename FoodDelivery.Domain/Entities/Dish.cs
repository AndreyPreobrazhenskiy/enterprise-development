namespace FoodDelivery.Domain.Entities;

/// <summary>
/// Блюдо из ресторана
/// </summary>
public class Dish
{
    /// <summary>
    /// Уникальный идентификатор блюда
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название блюда
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Вес блюда в граммах
    /// </summary>
    public int WeightGrams { get; set; }

    /// <summary>
    /// Цена блюда в рублях
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Идентификатор категории блюда
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Категория, к которой относится блюдо
    /// </summary>
    public Category Category { get; set; } = null!;
}