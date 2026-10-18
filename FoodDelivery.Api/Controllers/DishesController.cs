using FoodDelivery.Application.Contracts.DTOs;
using FoodDelivery.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет HTTP-операции для работы с блюдами
/// </summary>
[ApiController]
[Route("api/dishes")]
public class DishesController(IDishService dishService, ILogger<DishesController> logger) : ControllerBase
{
    /// <summary>
    /// Возвращает все блюда
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IList<DishDto>), StatusCodes.Status200OK)]
    public ActionResult<IList<DishDto>> GetAll()
    {
        logger.LogInformation("Получен запрос на получение всех блюд");
        return Ok(dishService.GetAll());
    }

    /// <summary>
    /// Возвращает блюдо по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DishDto> GetById(int id)
    {
        var dish = dishService.Get(id);
        if (dish is null) return NotFound();
        return Ok(dish);
    }

    /// <summary>
    /// Создаёт блюдо
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(DishDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<DishDto> Create(DishCreateUpdateDto dto)
    {
        var dish = dishService.Create(dto);
        logger.LogInformation("Создано блюдо с идентификатором {DishId}.", dish.Id);
        return CreatedAtAction(nameof(GetById), new { id = dish.Id }, dish);
    }

    /// <summary>
    /// Обновляет блюдо
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DishDto> Update(int id, DishCreateUpdateDto dto)
    {
        try
        {
            return Ok(dishService.Update(dto, id));
        }
        catch (KeyNotFoundException exception)
        {
            logger.LogWarning(exception, "Блюдо {DishId} не найдено", id);
            return NotFound();
        }
    }

    /// <summary>
    /// Удаляет блюдо
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        var deleted = dishService.Delete(id);

        if (deleted)
        {
            logger.LogInformation("Удалено блюдо {DishId}", id);
        }

        return NoContent();
    }
}
