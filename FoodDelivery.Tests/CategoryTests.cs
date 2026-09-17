using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests;

public class CategoryTests
{
    [Fact]
    /// <summary>
    /// Задание: Вывести сводную информацию о заказах (число заказов, средняя сумма заказа, общая сумма заказа) по каждой категории блюд за указанный период.
    /// </summary>
    public void OrdersByCategoryForSelectedPeriod()
    {
        var periodStart = new DateTime(2026, 9, 1);
        var periodEnd = new DateTime(2026, 9, 5);

        var expected = new[]
        {
            new
            {
                CategoryId = 1,
                OrderCount = 2,
                AvgOrderAmount = 1725m,
                TotalOrderAmount = 3450m
            },
            new
            {
                CategoryId = 2,
                OrderCount = 2,
                AvgOrderAmount = 1085m,
                TotalOrderAmount = 2170m
            },
            new
            {
                CategoryId = 3,
                OrderCount = 2,
                AvgOrderAmount = 1085m,
                TotalOrderAmount = 2170m
            }
        };

        var summary = TestData.Orders
            .Where(order =>
                order.CreatedAt >= periodStart &&
                order.CreatedAt < periodEnd)
            .SelectMany(order => order.Items.Select(item => new
            {
                Order = order,
                CategoryId = item.Dish.CategoryId
            }))
            .GroupBy(item => item.CategoryId)
            .Select(group => new
            {
                CategoryId = group.Key,

                OrderCount = group
                    .Select(item => item.Order.Id)
                    .Distinct()
                    .Count(),

                AvgOrderAmount = group
                    .Select(item => item.Order)
                    .DistinctBy(order => order.Id)
                    .Average(order => order.TotalAmount),

                TotalOrderAmount = group
                    .Select(item => item.Order)
                    .DistinctBy(order => order.Id)
                    .Sum(order => order.TotalAmount)
            })
            .OrderBy(item => item.CategoryId)
            .ToList();

        Assert.Equal(expected.Length, summary.Count);

        for (var i = 0; i < expected.Length; i++)
        {
            Assert.Equal(
                expected[i].CategoryId,
                summary[i].CategoryId);

            Assert.Equal(
                expected[i].OrderCount,
                summary[i].OrderCount);

            Assert.Equal(
                expected[i].AvgOrderAmount,
                summary[i].AvgOrderAmount);

            Assert.Equal(
                expected[i].TotalOrderAmount,
                summary[i].TotalOrderAmount);
        }
    }
}