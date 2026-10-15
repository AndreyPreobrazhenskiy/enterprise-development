namespace FoodDelivery.Application.Contracts.DTOs;

/// <summary>
/// DTO позиции заказа
/// </summary>
public record OrderItemDto(
    int Id,
    int OrderId,
    int DishId,
    int Quantity
);
