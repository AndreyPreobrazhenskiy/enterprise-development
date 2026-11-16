using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Contracts.Interfaces;

/// <summary>
/// Определяет операции доступа к данным блюд
/// </summary>
public interface IDishRepository : IRepository<Dish>
{
}
