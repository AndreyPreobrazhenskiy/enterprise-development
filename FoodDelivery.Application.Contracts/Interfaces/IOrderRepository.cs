using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Contracts.Interfaces;

/// <summary>
/// Определяет операции доступа к данным заказов
/// </summary>
public interface IOrderRepository : IRepository<Order>
{
    /// <summary>
    /// Возвращает заказы, которые ещё не были доставлены
    /// </summary>
    Task<IList<Order>> GetNotDeliveredAsync();
}
