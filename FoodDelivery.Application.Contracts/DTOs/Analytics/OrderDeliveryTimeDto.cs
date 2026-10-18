namespace FoodDelivery.Application.Contracts.DTOs.Analytics;

/// <summary>
/// Содержит информацию о времени доставки заказа
/// </summary>
public record OrderDeliveryTimeDto(
    int OrderId,
    TimeSpan DeliveryTime);