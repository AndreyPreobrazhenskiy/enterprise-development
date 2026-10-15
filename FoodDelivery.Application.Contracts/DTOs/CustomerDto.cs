namespace FoodDelivery.Application.Contracts.DTOs;

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
