namespace FoodDelivery.Application.Contracts.DTOs;

/// <summary>
/// DTO для создания или обновления заказа
/// </summary>
public record OrderCreateUpdateDto(
    int CustomerId,
    int RestaurantId,
    DateTime CreatedAt,
    DateTime DeliveredAt,
    List<OrderItemDto> Items);