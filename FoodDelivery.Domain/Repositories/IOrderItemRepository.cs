using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Repositories;

/// <summary>
/// Определяет операции доступа к позициям заказов
/// </summary>
public interface IOrderItemRepository : IRepository<OrderItem>
{
}
