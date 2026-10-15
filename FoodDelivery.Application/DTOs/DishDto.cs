namespace FoodDelivery.Application.DTOs;

/// <summary>
/// DTO блюда
/// </summary>
public record DishDto(
    int Id,
    string Name,
    int WeightGrams,
    decimal Price,
    int CategoryId,
    int RestaurantId
);
