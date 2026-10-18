using FoodDelivery.Application.Contracts.DTOs;
using FoodDelivery.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет HTTP-операции для работы с категориями
/// </summary>
[ApiController]
[Route("api/categories")]
public class CategoriesController(
    ICategoryService categoryService,
    ILogger<CategoriesController> logger) : ControllerBase
{
    /// <summary>
    /// Возвращает все категории
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IList<CategoryDto>), StatusCodes.Status200OK)]
    public ActionResult<IList<CategoryDto>> GetAll()
    {
        logger.LogInformation("Получен запрос на получение всех категорий");
        return Ok(categoryService.GetAll());
    }

    /// <summary>
    /// Возвращает категорию по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CategoryDto> GetById(int id)
    {
        var category = categoryService.Get(id);
        if (category is null) return NotFound();
        return Ok(category);
    }

    /// <summary>
    /// Создаёт категорию
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<CategoryDto> Create(CategoryCreateUpdateDto dto)
    {
        var category = categoryService.Create(dto);

        logger.LogInformation("Создана категория с идентификатором {CategoryId}", category.Id);

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    /// <summary>
    /// Обновляет категорию
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CategoryDto> Update(int id, CategoryCreateUpdateDto dto)
    {
        try
        {
            return Ok(categoryService.Update(dto, id));
        }
        catch (KeyNotFoundException exception)
        {
            logger.LogWarning(exception, "Категория {CategoryId} не найдена", id);
            return NotFound();
        }
    }

    /// <summary>
    /// Удаляет категорию
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        var deleted = categoryService.Delete(id);

        if (deleted)
        {
            logger.LogInformation("Удалена категория {CategoryId}", id);
        }

        return NoContent();
    }
}
