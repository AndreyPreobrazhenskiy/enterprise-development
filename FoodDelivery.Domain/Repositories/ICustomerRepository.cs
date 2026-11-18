using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Repositories;

/// <summary>
/// Определяет операции доступа к данным покупателей
/// </summary>
public interface ICustomerRepository : IRepository<Customer>
{
}
