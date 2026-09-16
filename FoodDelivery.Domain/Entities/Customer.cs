namespace FoodDelivery.Domain.Entities;

/// <summary>
/// Клиент
/// </summary>
public class Customer
{
    /// <summary>
    /// Уникальный идентификатор клиента
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Полное имя разделено, "чтобы не страдать из-за парсинга полных имен, где пробелы могут быть не только разделителями, но и частью имени/фамилии/отчества"
    /// </summary>

    /// <summary>
    /// Фамилия клиента
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Имя клиента
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Отчество клиента (может отсутствовать)
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Адрес доставки клиента
    /// </summary>
    public string DeliveryAddress { get; set; } = string.Empty;
}