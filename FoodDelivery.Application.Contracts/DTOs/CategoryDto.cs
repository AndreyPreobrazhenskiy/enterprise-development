using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Application.Contracts.DTOs;

/// <summary>
/// DTO категории блюда
/// </summary>
/// <param name="Id">Идентификатор категории</param>
/// <param name="Name">Название категории</param>
public record CategoryDto(
    int Id, 

    [property: Required(ErrorMessage = "Название категории обязательно")]
    [property: StringLength(100, MinimumLength = 1, ErrorMessage = "Название категории не должно превышать 100 символов")]
    [property: RegularExpression(@".\S.", ErrorMessage = "Название категории не должно состоять только из пробелов")]
    string Name
);
