using FoodDelivery.Application.Contracts.DTOs;
using FoodDelivery.Application.Contracts.Interfaces;
using FoodDelivery.Application.Interfaces;
using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Services;

/// <summary>
/// Реализует прикладные операции над заказами
/// </summary>
public class OrderService(
    IOrderRepository orderRepository,
    ICustomerRepository customerRepository,
    IRestaurantRepository restaurantRepository,
    IOrderItemRepository orderItemRepository,
    IDishRepository dishRepository)
    : IOrderService
{
    public OrderDto Create(OrderCreateUpdateDto dto)
    {
        var customer = customerRepository.GetById(dto.CustomerId)
            ?? throw new KeyNotFoundException(
                $"Покупатель с идентификатором {dto.CustomerId} не найден");

        var restaurant = restaurantRepository.GetById(dto.RestaurantId)
            ?? throw new KeyNotFoundException(
                $"Ресторан с идентификатором {dto.RestaurantId} не найден");

        var order = new Order
        {
            Id = 0,
            CustomerId = customer.Id,
            Customer = customer,
            RestaurantId = restaurant.Id,
            Restaurant = restaurant,
            CreatedAt = dto.CreatedAt,
            DeliveredAt = dto.DeliveredAt,
            Items = []
        };

        var createdOrder = orderRepository.Add(order);

        foreach (var itemDto in dto.Items)
        {
            var dish = dishRepository.GetById(itemDto.DishId)
                ?? throw new KeyNotFoundException(
                    $"Блюдо с идентификатором {itemDto.DishId} не найдено");

            var item = new OrderItem
            {
                Id = 0,
                OrderId = createdOrder.Id,
                DishId = dish.Id,
                Dish = dish,
                Quantity = itemDto.Quantity
            };

            var createdItem = orderItemRepository.Add(item);
            createdOrder.Items.Add(createdItem);
        }

        return MapToDto(createdOrder);
    }

    public OrderDto? Get(int id)
    {
        var order = orderRepository.GetById(id);
        return order is null ? null : MapToDto(order);
    }

    public IList<OrderDto> GetAll()
    {
        return orderRepository.GetAll()
            .Select(MapToDto)
            .ToList();
    }

    public OrderDto Update(OrderCreateUpdateDto dto, int id)
    {
        var order = orderRepository.GetById(id)
            ?? throw new KeyNotFoundException(
                $"Заказ с идентификатором {id} не найден");

        var customer = customerRepository.GetById(dto.CustomerId)
            ?? throw new KeyNotFoundException(
                $"Покупатель с идентификатором {dto.CustomerId} не найден");

        var restaurant = restaurantRepository.GetById(dto.RestaurantId)
            ?? throw new KeyNotFoundException(
                $"Ресторан с идентификатором {dto.RestaurantId} не найден");

        order.CustomerId = customer.Id;
        order.Customer = customer;
        order.RestaurantId = restaurant.Id;
        order.Restaurant = restaurant;
        order.CreatedAt = dto.CreatedAt;
        order.DeliveredAt = dto.DeliveredAt;

        orderRepository.Update(order);

        foreach (var oldItem in order.Items.ToList())
        {
            orderItemRepository.Delete(oldItem.Id);
        }

        order.Items.Clear();

        foreach (var itemDto in dto.Items)
        {
            var dish = dishRepository.GetById(itemDto.DishId)
                ?? throw new KeyNotFoundException(
                    $"Блюдо с идентификатором {itemDto.DishId} не найдено");

            var item = new OrderItem
            {
                Id = 0,
                OrderId = order.Id,
                DishId = dish.Id,
                Dish = dish,
                Quantity = itemDto.Quantity
            };

            var createdItem = orderItemRepository.Add(item);
            order.Items.Add(createdItem);
        }

        return MapToDto(order);
    }

    public bool Delete(int id)
    {
        var order = orderRepository.GetById(id);

        if (order is null)
        {
            return false;
        }

        foreach (var item in order.Items.ToList())
        {
            orderItemRepository.Delete(item.Id);
        }

        order.Items.Clear();

        return orderRepository.Delete(id);
    }

    private static OrderDto MapToDto(Order order)
    {
        return new OrderDto(
            order.Id,
            order.CustomerId,
            order.RestaurantId,
            order.CreatedAt,
            order.DeliveredAt,
            order.TotalAmount,
            order.Items.Select(item => new OrderItemDto(
                item.Id,
                item.OrderId,
                item.DishId,
                item.Quantity)).ToList());
    }
}
