using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests;

public class RestaurantTests
{
    [Fact]
    /// <summary>
    /// Задание: Вывести топ 5 ресторанов по количеству заказов. 
    /// </summary>
    public void Top5RestaurantsByOrderCount()
    {
        var orders = TestData.Orders;

        var expected = new List<int>
        {
            1, 2, 3, 4, 5
        };

        var restaurantIds = orders
            .GroupBy(order => order.RestaurantId)
            .Select(group => new
            {
                RestaurantId = group.Key,
                OrderCount = group.Count()
            })
            .OrderByDescending(item => item.OrderCount)
            .ThenBy(item => item.RestaurantId)
            .Take(5)
            .Select(item => item.RestaurantId)
            .ToList();

        Assert.Equal(expected, restaurantIds);
    }
}