using FoodDelivery.Application.Contracts.DTOs;
using FoodDelivery.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет HTTP-операции для работы с позициями заказов
/// </summary>
[ApiController]
[Route("api/order-items")]
public class OrderItemsController(IOrderItemService orderItemService, ILogger<OrderItemsController> logger) : ControllerBase
{
    /// <summary>
    /// Возвращает все позиции заказов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IList<OrderItemDto>), StatusCodes.Status200OK)]
    public ActionResult<IList<OrderItemDto>> GetAll()
    {
        logger.LogInformation("Получен запрос на получение всех позиций заказов");
        return Ok(orderItemService.GetAll());
    }

    /// <summary>
    /// Возвращает позицию заказа по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(OrderItemDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<OrderItemDto> GetById(int id)
    {
        var orderItem = orderItemService.Get(id);
        if (orderItem is null) return NotFound();
        return Ok(orderItem);
    }

    /// <summary>
    /// Создаёт позицию заказа
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(OrderItemDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<OrderItemDto> Create(OrderItemCreateUpdateDto dto)
    {
        var orderItem = orderItemService.Create(dto);
        logger.LogInformation("Создана позиция заказа с идентификатором {OrderItemId}", orderItem.Id);
        return CreatedAtAction(nameof(GetById), new { id = orderItem.Id }, orderItem);
    }

    /// <summary>
    /// Обновляет позицию заказа
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(OrderItemDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<OrderItemDto> Update(int id, OrderItemCreateUpdateDto dto)
    {
        try
        {
            return Ok(orderItemService.Update(dto, id));
        }
        catch (KeyNotFoundException exception)
        {
            logger.LogWarning(exception, "Позиция заказа {OrderItemId} не найдена", id);
            return NotFound();
        }
    }

    /// <summary>
    /// Удаляет позицию заказа
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        var deleted = orderItemService.Delete(id);

        if (deleted)
        {
            logger.LogInformation("Удалена позиция заказа {OrderItemId}.", id);
        }

        return NoContent();
    }
}
