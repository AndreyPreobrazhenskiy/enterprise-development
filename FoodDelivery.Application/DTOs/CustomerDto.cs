namespace FoodDelivery.Application.DTOs;

/// <summary>
/// DTO клиента
/// </summary>
public record CustomerDto(
    int Id,
    string LastName,
    string FirstName,
    string? Patronymic,
    string Phone,
    string DeliveryAddress
);
