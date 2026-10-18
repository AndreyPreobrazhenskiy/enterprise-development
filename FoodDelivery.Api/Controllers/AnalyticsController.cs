using FoodDelivery.Application.Contracts.DTOs.Analytics;
using FoodDelivery.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет API для получения аналитики
/// </summary>
[ApiController]
[Route("api/analytics")]
public class AnalyticsController(IAnalyticsService analyticsService, ILogger<AnalyticsController> logger) : ControllerBase
{
    /// <summary>
    /// Получает сводную информацию по категориям за выбранный период
    /// </summary>
    [HttpGet("categories")]
    [ProducesResponseType(typeof(IList<CategoryOrderSummaryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IList<CategoryOrderSummaryDto>> GetOrdersByCategory([FromQuery] DateTime periodStart, [FromQuery] DateTime periodEnd)
    {
        try
        {
            var result = analyticsService.GetOrdersByCategoryForPeriod(periodStart, periodEnd);
            return Ok(result);
        }
        catch (ArgumentException exception)
        {
            logger.LogWarning(exception, "Некорректный период аналитики");
            return BadRequest(new { message = exception.Message });
        }
    }

    /// <summary>
    /// Получает клиентов, заказывавших в указанном ресторане
    /// </summary>
    [HttpGet("restaurants/{restaurantId:int}/customers")]
    [ProducesResponseType(typeof(IList<CustomerOrderSummaryDto>), StatusCodes.Status200OK)]
    public ActionResult<IList<CustomerOrderSummaryDto>> GetCustomersByRestaurant(int restaurantId)
    {
        var result = analyticsService.GetCustomersByRestaurant(restaurantId);
        return Ok(result);
    }

    /// <summary>
    /// Получает клиента с максимальной общей суммой заказов
    /// </summary>
    [HttpGet("customers/top-spender")]
    [ProducesResponseType(typeof(CustomerOrderSummaryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CustomerOrderSummaryDto> GetCustomerWithMaxTotalOrderAmount()
    {
        var result = analyticsService.GetCustomerWithMaxTotalOrderAmount();
        if (result is null) return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Получает заказы с минимальным временем доставки
    /// </summary>
    [HttpGet("orders/min-delivery-time")]
    [ProducesResponseType(typeof(IList<OrderDeliveryTimeDto>), StatusCodes.Status200OK)]
    public ActionResult<IList<OrderDeliveryTimeDto>> GetOrdersWithMinDeliveryTime()
    {
        var result = analyticsService.GetOrdersWithMinDeliveryTime();
        return Ok(result);
    }

    /// <summary>
    /// Получает топ ресторанов по количеству заказов
    /// </summary>
    [HttpGet("restaurants/top")]
    [ProducesResponseType(typeof(IList<RestaurantOrderCountDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IList<RestaurantOrderCountDto>> GetTopRestaurants([FromQuery] int count = 5)
    {
        try
        {
            var result = analyticsService.GetTopRestaurantsByOrderCount(count);
            return Ok(result);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            logger.LogWarning(exception, "Некорректное количество ресторанов");
            return BadRequest(new { message = exception.Message });
        }
    }
}