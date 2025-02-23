using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces;

/// <summary>
/// En generisk repository-interface som tillhandahåller grundläggande CRUD-operationer.
/// </summary>
/// <typeparam name="TEntity">Den entitetstyp som repositoryt hanterar.</typeparam>
public interface IBaseRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Kontrollerar om en entitet redan finns baserat på ett uttryck.
    /// </summary>
    /// <param name="expression">Ett uttryck för att hitta entiteten.</param>
    /// <returns>En boolsk uppgift som är sann om entiteten finns, annars falsk.</returns>
    Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Skapar en ny entitet i databasen.
    /// </summary>
    /// <param name="entity">Den entitet som ska skapas.</param>
    /// <returns>Den skapade entiteten.</returns>
    Task<TEntity> CreateAsync(TEntity entity);

    /// <summary>
    /// Raderar en entitet baserat på ett uttryck.
    /// </summary>
    /// <param name="expression">Ett uttryck för att hitta entiteten.</param>
    /// <returns>En boolsk uppgift som är sann om entiteten raderades, annars falsk.</returns>
    Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Hämtar alla entiteter av typen <typeparamref name="TEntity"/>.
    /// </summary>
    /// <returns>En lista med alla entiteter.</returns>
    Task<IEnumerable<TEntity>> GetAsync();

    /// <summary>
    /// Hämtar en entitet baserat på ett uttryck.
    /// </summary>
    /// <param name="expression">Ett uttryck för att hitta entiteten.</param>
    /// <returns>Den hittade entiteten eller null om ingen match hittas.</returns>
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Uppdaterar en entitet baserat på ett uttryck och den uppdaterade entiteten.
    /// </summary>
    /// <param name="expression">Ett uttryck för att hitta den befintliga entiteten.</param>
    /// <param name="updatedEntity">Den uppdaterade entiteten med nya värden.</param>
    /// <returns>Den uppdaterade entiteten eller null om ingen match hittas.</returns>
    Task<TEntity?> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity);
}
//Hjälp av chatgpt med hur och vart man ska sätta XML-kommentarer