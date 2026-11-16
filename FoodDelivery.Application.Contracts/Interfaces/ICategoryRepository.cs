using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Contracts.Interfaces;

/// <summary>
/// Определяет операции доступа к данным категорий
/// </summary>
public interface ICategoryRepository : IRepository<Category>
{
}
