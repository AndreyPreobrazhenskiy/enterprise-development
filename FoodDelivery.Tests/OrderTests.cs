using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests;

public class OrderTests
{
    /// <summary>
    /// Задание: Вывести список заказов с минимальным временем доставки.
    /// </summary>
    [Fact]
    public void OrdersWithMinDeliveryTime()
    {
        var orders = TestData.Orders;

        int[] expected = [8, 9];

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