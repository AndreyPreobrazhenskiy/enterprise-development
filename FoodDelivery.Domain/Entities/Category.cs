namespace FoodDelivery.Domain.Entities;

/// <summary>
/// Категория блюда
/// </summary>
public class Category
{
    /// <summary>
    /// Уникальный идентификатор категории
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название категории
    /// </summary>
    public string Name { get; set; } = string.Empty;
}