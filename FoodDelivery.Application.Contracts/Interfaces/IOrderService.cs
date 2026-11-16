using FoodDelivery.Application.Contracts.DTOs;

namespace FoodDelivery.Application.Contracts.Interfaces;

public interface IOrderService
    : IApplicationService<OrderDto, OrderCreateUpdateDto, int>
{
    /// <summary>
    /// Возвращает список заказов, которые ещё не были доставлены
    /// </summary>
    Task<IList<OrderDto>> GetNotDeliveredAsync();
}