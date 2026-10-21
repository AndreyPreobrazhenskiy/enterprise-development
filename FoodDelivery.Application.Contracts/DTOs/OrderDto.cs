using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Application.Contracts.DTOs;

/// <summary>
/// DTO заказа
/// </summary>
/// <param name="Id">Уникальный идентификатор заказа</param>
/// <param name="CustomerId">Идентификатор клиента</param>
/// <param name="RestaurantId">Идентификатор ресторана</param>
/// <param name="CreatedAt">Дата и время создания заказа</param>
/// <param name="DeliveredAt">Дата и время доставки заказа</param>
/// <param name="TotalAmount">Общая стоимость заказа</param>
/// <param name="Items">Список позиций заказа</param>
public record OrderDto(
    int Id,

    [property: Range(1, int.MaxValue, ErrorMessage = "Идентификатор клиента должен быть положительным")]
    int CustomerId,

    [property: Range(1, int.MaxValue, ErrorMessage = "Идентификатор ресторана должен быть положительным")]
    int RestaurantId,

    [property: Required(ErrorMessage = "Дата создания заказа обязательна")]
    [property: Range(typeof(DateTime), "01/01/2000", "12/31/9999", ErrorMessage = "Укажите корректную дату создания заказа")]
    DateTime CreatedAt,

    [property: Required(ErrorMessage = "Дата доставки обязательна")]
    [property: Range(typeof(DateTime), "01/01/2000", "12/31/9999", ErrorMessage = "Укажите корректную дату доставки")]
    DateTime DeliveredAt,

    decimal TotalAmount,
    List<OrderItemDto> Items
);
