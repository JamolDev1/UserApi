using Databasesql.Entities.Enums;

namespace Databasesql.Models;
public class BookModel
{
    public string Title { get; set; }
    public string Author{ get; set; }
    public string Description { get; set; }
    public EGenre Genre { get; set; }
}