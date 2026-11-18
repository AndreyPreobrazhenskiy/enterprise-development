using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Repositories;

/// <summary>
/// Определяет операции доступа к данным блюд
/// </summary>
public interface IDishRepository : IRepository<Dish>
{
}
