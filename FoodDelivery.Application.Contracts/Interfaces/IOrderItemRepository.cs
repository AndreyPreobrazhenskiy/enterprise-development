using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Contracts.Interfaces;

/// <summary>
/// Определяет операции доступа к позициям заказов
/// </summary>
public interface IOrderItemRepository : IRepository<OrderItem>
{
}
