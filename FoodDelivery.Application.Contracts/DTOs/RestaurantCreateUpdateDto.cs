namespace FoodDelivery.Application.Contracts.DTOs;

/// <summary>
/// DTO для создания или обновления ресторана
/// </summary>
public record RestaurantCreateUpdateDto(
    string Name,
    string Address,
    double Rating,
    TimeOnly OpeningTime,
    TimeOnly ClosingTime);