using System.Diagnostics;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

/// <summary>
/// Generiskt repository för CRUD-operationer.
/// </summary>
/// <typeparam name="TEntity">Datatypen för entiteten.</typeparam>
public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    /// <summary>
    /// Skapar en ny entitet i databasen och kontrollerar om den sparades korrekt.
    /// </summary>
    /// <param name="entity">Entiteten som ska skapas.</param>
    /// <returns>Den skapade entiteten eller null vid fel.</returns>
    /// <exception cref="ArgumentNullException">Kastas om entiteten är null.</exception>
    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        try
        {
            await _dbSet.AddAsync(entity);
            var changes = await _context.SaveChangesAsync();

            if (changes > 0)
            {
                Console.WriteLine($"Entity of type {nameof(TEntity)} created successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to save entity of type {nameof(TEntity)} to the database.");
                return null!;
            }

            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating {nameof(TEntity)} entity :: {ex.Message}");
            Console.WriteLine($"Error creating entity: {ex.Message}");
            return null!;
        }
    }

    /// <summary>
    /// Hämtar alla entiteter från databasen.
    /// </summary>
    /// <returns>En lista med alla entiteter av typen <typeparamref name="TEntity"/>.</returns>
    public virtual async Task<IEnumerable<TEntity>> GetAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Hämtar en entitet baserat på ett filter.
    /// </summary>
    /// <param name="expression">Filteruttrycket för att hitta en specifik entitet.</param>
    /// <returns>Den hittade entiteten eller null om ingen matchning hittas.</returns>
    /// <exception cref="ArgumentNullException">Kastas om filteruttrycket är null.</exception>
    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        ArgumentNullException.ThrowIfNull(expression);
        return await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
    }

    /// <summary>
    /// Uppdaterar en befintlig entitet i databasen.
    /// </summary>
    /// <param name="expression">Filter för att hitta rätt entitet att uppdatera.</param>
    /// <param name="updatedEntity">Den uppdaterade entiteten med nya värden.</param>
    /// <returns>Den uppdaterade entiteten eller null om ingen matchning hittas.</returns>
    /// <exception cref="ArgumentNullException">Kastas om den uppdaterade entiteten är null.</exception>
    public virtual async Task<TEntity?> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity)
    {
        ArgumentNullException.ThrowIfNull(expression);
        ArgumentNullException.ThrowIfNull(updatedEntity);

        try
        {
            var existingEntity = await _dbSet.FirstOrDefaultAsync(expression);
            if (existingEntity == null)
                return null;

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating {nameof(TEntity)} entity :: {ex.Message}");
            return null!;
        }
    }

    /// <summary>
    /// Raderar en entitet från databasen.
    /// </summary>
    /// <param name="expression">Filter för att hitta rätt entitet att radera.</param>
    /// <returns>True om raderingen lyckades, annars false.</returns>
    /// <exception cref="ArgumentNullException">Kastas om filteruttrycket är null.</exception>
    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        ArgumentNullException.ThrowIfNull(expression);

        try
        {
            var existingEntity = await _dbSet.FirstOrDefaultAsync(expression);
            if (existingEntity == null)
                return false;

            _dbSet.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting {nameof(TEntity)} entity :: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Kontrollerar om en entitet redan existerar baserat på ett filter.
    /// </summary>
    /// <param name="expression">Filteruttrycket för att kontrollera om entiteten finns.</param>
    /// <returns>True om entiteten finns, annars false.</returns>
    /// <exception cref="ArgumentNullException">Kastas om filteruttrycket är null.</exception>
    public virtual async Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        ArgumentNullException.ThrowIfNull(expression);
        return await _dbSet.AnyAsync(expression);
    }
}
//Hjälp av chatgp med XML-kommentarerna, hur dem ska sättas, var.


