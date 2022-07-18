using Databasesql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Databasesql.Data;
public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {} 
}