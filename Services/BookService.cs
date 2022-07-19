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

    public Task<(bool IsSuccess, Exception e)> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Book>> GetAllAync()
        => Task.FromResult(_context.Books.ToList());

    public Task<Book> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<(bool IsSuccess, Exception e, Book entity)> InsertAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<(bool IsSuccess, Exception e)> UpdateAsyn(Book entity)
    {
        throw new NotImplementedException();
    }
}