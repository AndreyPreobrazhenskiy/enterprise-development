namespace FoodDelivery.Application.Contracts.DTOs;

/// <summary>
/// DTO ресторана
/// </summary>
public record RestaurantDto(
    int Id,
    string Name,
    string Address,
    double Rating,
    TimeOnly OpeningTime,
    TimeOnly ClosingTime
);
