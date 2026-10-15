namespace FoodDelivery.Application.Contracts.DTOs;

/// <summary>
/// DTO для создания или обновления блюда
/// </summary>
public record DishCreateUpdateDto(
    string Name,
    int WeightGrams,
    decimal Price,
    int CategoryId,
    int RestaurantId);