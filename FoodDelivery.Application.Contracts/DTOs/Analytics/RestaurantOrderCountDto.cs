namespace FoodDelivery.Application.Contracts.DTOs.Analytics;

/// <summary>
/// Содержит информацию о ресторане и количестве его заказов
/// </summary>
public record RestaurantOrderCountDto(
    int RestaurantId,
    string RestaurantName,
    int OrderCount);