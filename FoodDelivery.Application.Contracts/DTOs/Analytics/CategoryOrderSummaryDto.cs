namespace FoodDelivery.Application.Contracts.DTOs.Analytics;

/// <summary>
/// Содержит сводную информацию о заказах по категории блюд
/// </summary>
public record CategoryOrderSummaryDto(
    int CategoryId,
    string CategoryName,
    int OrderCount,
    decimal AverageOrderAmount,
    decimal TotalOrderAmount);