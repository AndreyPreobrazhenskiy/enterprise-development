using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests;

public class OrderTests
{
    [Fact]

    /// <summary>
    /// Задание: Вывести список заказов с минимальным временем доставки.
    /// </summary>
    public void OrdersWithMinDeliveryTime()
    {
        var orders = TestData.Orders;

        var expected = new List<int>
        {
            8, 9
        };

        var minimumDeliveryTime = orders
            .Select(order => order.DeliveredAt - order.CreatedAt)
            .Min();

        var orderIds = orders
            .Where(order => order.DeliveredAt - order.CreatedAt == minimumDeliveryTime)
            .Select(order => order.Id)
            .OrderBy(orderId => orderId)
            .ToList();

        Assert.Equal(expected, orderIds);
    }
}