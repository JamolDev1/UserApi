namespace Databasesql.Services;
public interface IBookService<TEntity> where TEntity : class
{
    Task<(bool IsSuccess , Exception e,TEntity entity)> InsertAsync( TEntity entity );
    Task<(bool IsSuccess , Exception e )> UpdateAsyn( TEntity entity );
    Task <List<TEntity>> GetAllAync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<(bool IsSuccess , Exception e)> DeleteAsync( Guid id );
}