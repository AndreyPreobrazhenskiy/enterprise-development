using FoodDelivery.Application.Contracts.DTOs;
using FoodDelivery.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет HTTP-операции для работы с покупателями
/// </summary>
[ApiController]
[Route("api/customers")]
public class CustomersController(
    ICustomerService customerService,
    ILogger<CustomersController> logger) : ControllerBase
{
    /// <summary>
    /// Возвращает всех покупателей
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IList<CustomerDto>), StatusCodes.Status200OK)]
    public ActionResult<IList<CustomerDto>> GetAll()
    {
        logger.LogInformation("Получен запрос на получение всех покупателей");
        return Ok(customerService.GetAll());
    }

    /// <summary>
    /// Возвращает покупателя по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CustomerDto> GetById(int id)
    {
        var customer = customerService.Get(id);

        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    /// <summary>
    /// Создаёт покупателя
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<CustomerDto> Create(CustomerCreateUpdateDto dto)
    {
        var customer = customerService.Create(dto);
        logger.LogInformation("Создан покупатель с идентификатором {CustomerId}", customer.Id);
        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
    }

    /// <summary>
    /// Обновляет данные покупателя
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CustomerDto> Update(int id, CustomerCreateUpdateDto dto)
    {
        try
        {
            return Ok(customerService.Update(dto, id));
        }
        catch (KeyNotFoundException exception)
        {
            logger.LogWarning(exception, "Покупатель с идентификатором {CustomerId} не найден", id);
            return NotFound();
        }
    }

    /// <summary>
    /// Удаляет покупателя
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        var deleted = customerService.Delete(id);

        if (deleted)
        {
            logger.LogInformation("Удалён покупатель с идентификатором {CustomerId}", id);
        }

        return NoContent();
    }
}
