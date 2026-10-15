namespace FoodDelivery.Application.Contracts.Interfaces;

/// <summary>
/// Определяет стандартные операции CRUD для прикладных сервисов
/// </summary>
public interface IApplicationService<TDto, TCreateUpdateDto, TKey>
{
    /// <summary>Создаёт новую запись</summary>
    Task<TDto> Create(TCreateUpdateDto dto);

    /// <summary>Возвращает запись по идентификатору</summary>
    Task<TDto?> Get(TKey id);

    /// <summary>Возвращает все записи</summary>
    Task<IList<TDto>> GetAll();

    /// <summary>Обновляет существующую запись</summary>
    Task<TDto> Update(TCreateUpdateDto dto, TKey id);

    /// <summary>Удаляет запись</summary>
    Task<bool> Delete(TKey id);
}
