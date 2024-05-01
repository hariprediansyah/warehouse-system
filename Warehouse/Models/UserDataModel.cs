using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse;

public class UserDataModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("UserName")]
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public string NoHP { get; set; }
    public string? UserInput { get; set; }
    public DateTime? TimeInput { get; set; }
    public string? UserEdit{ get; set; }
    public DateTime? TimeEdit { get; set; }
    public string Email { get; set; }
    public string IsActive { get; set; }
    public DateTime? LastLogin { get; set; }
    public string Password { get; set; }
}
