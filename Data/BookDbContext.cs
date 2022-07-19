using Databasesql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Databasesql.Data;
public class BookDbContext : DbContext
{
    public DbSet<Book> Books  { get; set; }
    public BookDbContext(DbContextOptions <BookDbContext> options) : base(options) {}
    
}