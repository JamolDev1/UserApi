using System.ComponentModel.DataAnnotations;
using Databasesql.Entities.Enums;

namespace Databasesql.Entities;
public class Book
{
 [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MaxLength(50)]
    public string Author{ get; set; }
    [Required]
    [MaxLength(1024)]
    public string Description { get; set; }
    [Required]
    public EGenre Genre { get; set; }
    public ICollection<User> Users { get; set; }

}