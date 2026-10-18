
using FoodDelivery.Application.Contracts.DTOs;
using FoodDelivery.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет HTTP-операции для работы с ресторанами
/// </summary>
[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantService restaurantService, ILogger<RestaurantsController> logger) : ControllerBase
{
    /// <summary>
    /// Возвращает все рестораны
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IList<RestaurantDto>), StatusCodes.Status200OK)]
    public ActionResult<IList<RestaurantDto>> GetAll()
    {
        logger.LogInformation("Получен запрос на получение всех ресторанов");
        return Ok(restaurantService.GetAll());
    }

    /// <summary>
    /// Возвращает ресторан по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<RestaurantDto> GetById(int id)
    {
        var restaurant = restaurantService.Get(id);

        if (restaurant is null)
        {
            return NotFound();
        }

        return Ok(restaurant);
    }

    /// <summary>
    /// Создаёт ресторан
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<RestaurantDto> Create(RestaurantCreateUpdateDto dto)
    {
        var restaurant = restaurantService.Create(dto);
        logger.LogInformation("Создан ресторан с идентификатором {RestaurantId}", restaurant.Id);
        return CreatedAtAction(nameof(GetById), new { id = restaurant.Id }, restaurant);
    }

    /// <summary>
    /// Обновляет ресторан
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<RestaurantDto> Update(int id, RestaurantCreateUpdateDto dto)
    {
        try
        {
            return Ok(restaurantService.Update(dto, id));
        }
        catch (KeyNotFoundException exception)
        {
            logger.LogWarning(exception, "Ресторан с идентификатором {RestaurantId} не найден", id);

            return NotFound();
        }
    }

    /// <summary>
    /// Удаляет ресторан
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        var deleted = restaurantService.Delete(id);

        if (deleted)
        {
            logger.LogInformation("Удалён ресторан с идентификатором {RestaurantId}", id);
        }

        return NoContent();
    }
}
