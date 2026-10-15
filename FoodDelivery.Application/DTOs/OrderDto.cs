namespace FoodDelivery.Application.DTOs;

/// <summary>
/// DTO заказа
/// </summary>
public record OrderDto(
    int Id,
    int CustomerId,
    int RestaurantId,
    DateTime CreatedAt,
    DateTime DeliveredAt,
    decimal TotalAmount,
    List<OrderItemDto> Items
);
