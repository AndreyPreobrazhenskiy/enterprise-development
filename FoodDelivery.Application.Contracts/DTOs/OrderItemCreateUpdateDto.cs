namespace FoodDelivery.Application.Contracts.DTOs;

/// <summary>
/// DTO для создания или обновления позиции заказа
/// </summary>
public record OrderItemCreateUpdateDto(int OrderId, int DishId, int Quantity);