using Databasesql.Entities.Enums;
namespace Databasesql.Models;
public class UserModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long PhoneNumber { get; set; }
    public int Age { get; set; }
    public EGender Gender { get; set; }
}