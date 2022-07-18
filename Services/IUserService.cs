
using Databasesql.Entities;

namespace Databasesql.Services; 
public interface IUserService <TEntity> where TEntity : class
{
    Task<(bool IsSuccess, Exception e , TEntity entity)> InsertAsync (TEntity entity);
    Task<(bool IsSuccess, Exception e)> UpdateAsync(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<(bool IsSuccess , Exception e)> DeleteAsync(Guid id);
}