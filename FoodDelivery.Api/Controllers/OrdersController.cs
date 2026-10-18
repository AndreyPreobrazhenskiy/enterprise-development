using FoodDelivery.Application.Contracts.DTOs;
using FoodDelivery.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет HTTP-операции для работы с заказами
/// </summary>
[ApiController]
[Route("api/orders")]
public class OrdersController(IOrderService orderService, ILogger<OrdersController> logger) : ControllerBase
{
    /// <summary>
    /// Возвращает все заказы
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IList<OrderDto>), StatusCodes.Status200OK)]
    public ActionResult<IList<OrderDto>> GetAll()
    {
        logger.LogInformation("Получен запрос на получение всех заказов");
        return Ok(orderService.GetAll());
    }

    /// <summary>
    /// Возвращает заказ по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<OrderDto> GetById(int id)
    {
        var order = orderService.Get(id);
        if (order is null) return NotFound();
        return Ok(order);
    }

    /// <summary>
    /// Создаёт заказ
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<OrderDto> Create(OrderCreateUpdateDto dto)
    {
        var order = orderService.Create(dto);
        logger.LogInformation("Создан заказ с идентификатором {OrderId}", order.Id);
        return CreatedAtAction(nameof(GetById),new { id = order.Id }, order);
    }

    /// <summary>
    /// Обновляет заказ
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<OrderDto> Update(int id, OrderCreateUpdateDto dto)
    {
        try
        {
            return Ok(orderService.Update(dto, id));
        }
        catch (KeyNotFoundException exception)
        {
            logger.LogWarning(exception, "Заказ {OrderId} не найден", id);
            return NotFound();
        }
    }

    /// <summary>
    /// Удаляет заказ
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        var deleted = orderService.Delete(id);

        if (deleted)
        {
            logger.LogInformation("Удалён заказ {OrderId}", id);
        }

        return NoContent();
    }
}
