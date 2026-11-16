using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Contracts.Interfaces;

/// <summary>
/// Определяет операции доступа к данным ресторанов
/// </summary>
public interface IRestaurantRepository : IRepository<Restaurant>
{
}
