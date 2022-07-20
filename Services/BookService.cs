using System.Linq.Expressions;
using Databasesql.Data;
using Databasesql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Databasesql.Services;
public class BookService : IBookService<Book>
{
    private readonly ILogger<BookService> _logger;
    private readonly BookDbContext _context;

    public BookService(ILogger<BookService> logger, BookDbContext context)
    {
        
        _logger = logger;
        _context = context;
        
    }

    public async Task<(bool IsSuccess, Exception e)> DeleteAsync(Guid id)
    {
        try
        {        
            var book = await GetByIdAsync(id); 
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return (true,null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
    }

    public Task<List<Book>> GetAllAync()
        => Task.FromResult(_context.Books.ToList());

    public async Task<Book> GetByIdAsync(Guid id)
    {
         return await _context.Books.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<(bool IsSuccess, Exception e, Book entity)> InsertAsync(Book entity)
    {
        try
        {
            var res = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return(true , null , entity);   
        }
        catch (Exception e)
        {
            _logger.LogError($"This Book was not added{entity}");
            return (false, e , null);
        }
    }

    public async Task<(bool IsSuccess, Exception e)> UpdateAsyn(Book entity)
    {
        try
        {
            _context.Books.Update(entity);
            await _context.SaveChangesAsync();
            return (true ,null);
        }
        catch (Exception e)
        {
            return (false , e);
        }
    }
}