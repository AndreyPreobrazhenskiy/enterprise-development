using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Repositories;

/// <summary>
/// Определяет операции доступа к данным ресторанов
/// </summary>
public interface IRestaurantRepository : IRepository<Restaurant>
{
}
