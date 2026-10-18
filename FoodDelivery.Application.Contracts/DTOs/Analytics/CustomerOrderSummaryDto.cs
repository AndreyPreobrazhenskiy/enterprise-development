namespace FoodDelivery.Application.Contracts.DTOs.Analytics;

/// <summary>
/// Содержит информацию о клиенте и общей сумме его заказов
/// </summary>
public record CustomerOrderSummaryDto(
    int CustomerId,
    string LastName,
    string FirstName,
    string? Patronymic,
    decimal TotalOrderAmount);