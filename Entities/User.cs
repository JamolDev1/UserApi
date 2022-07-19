
using System.ComponentModel.DataAnnotations;
using Databasesql.Entities.Enums;

namespace Databasesql.Entities;
public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    public long PhoneNumber { get; set; }
    
    [Required]
    public int Age { get; set; }
    
    [Required]
    public EGender Gender { get; set; }

}