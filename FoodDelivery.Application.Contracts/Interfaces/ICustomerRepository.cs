using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Contracts.Interfaces;

/// <summary>
/// Определяет операции доступа к данным покупателей
/// </summary>
public interface ICustomerRepository : IRepository<Customer>
{
}
