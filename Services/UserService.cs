using Databasesql.Data;
using Databasesql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Databasesql.Services;
public class UserService : IUserService<User>
{
    private readonly ILogger<UserService> _logger;
    private readonly UserDbContext _context;

    public UserService(ILogger<UserService> logger, UserDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<(bool IsSuccess, Exception e)> DeleteAsync(Guid id)
    {
        try
        {
            var user = await GetByIdAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception e)
        {
             return (false , e);
        }
    }

    public  Task<List<User>> GetAllAsync()
        => Task.FromResult(_context.Users.ToList());

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<(bool IsSuccess, Exception e, User entity)> InsertAsync(User entity)
    {
        try
        {
            var res = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return(true , null , entity);   
        }
        catch (Exception ex)
        {
             _logger.LogError($"This User was not added{entity}");
             return (false, ex , null);
        }
    }

    public async Task<(bool IsSuccess, Exception e)> UpdateAsync(User entity)
    {
        try
        {
             _context.Users.Update(entity);
             await _context.SaveChangesAsync();
             return (true ,null);
        }
        catch (Exception e)
        {
            return (false , e);
        }
    }
}