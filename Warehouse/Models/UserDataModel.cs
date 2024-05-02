using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse;

public class UserDataModel
{
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public string NoHP { get; set; }
    public string Email { get; set; }
    public string IsActive { get; set; }
    public string OldUserName { get; set; }
}
