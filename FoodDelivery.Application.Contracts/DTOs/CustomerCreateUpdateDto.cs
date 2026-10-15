namespace FoodDelivery.Application.Contracts.DTOs;

/// <summary>
/// DTO для создания или обновления клиента
/// </summary>
public record CustomerCreateUpdateDto(
    string LastName,
    string FirstName,
    string? Patronymic,
    string Phone,
    string DeliveryAddress);