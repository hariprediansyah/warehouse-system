using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Warehouse.Class;

namespace Warehouse.Pages
{
    [BindProperties]
    public class UserModel : PageModel
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string NoHP { get; set; }
        public string Email { get; set; }
        public string IsActive { get; set; }    

        private readonly ILogger<UserModel> _logger;

        public UserModel(ILogger<UserModel> logger)
        {
            _logger = logger;
        }

        public DataTable GetAllUser(){
            using SqlHelper sqlHelper = new();
            sqlHelper.commandText = "SELECT * FROM User";
            return sqlHelper.ExecuteDataTable();
        }

        public void OnGet()
        {
        }

        public void OnPost() {
            using SqlHelper sqlHelper = new();
            sqlHelper.commandText = " INSERT INTO User (Username, FullName, NoHP, Email, Password, Role, IsActive) " +
                                    " VALUES (@Username, @FullName, @NoHP, @Email, @Password, @Role, @IsActive) ";
            sqlHelper.AddParameter("@Username", UserName, MySqlDbType.VarChar);
            sqlHelper.AddParameter("@FullName", FullName, MySqlDbType.VarChar);
            sqlHelper.AddParameter("@NoHP", NoHP, MySqlDbType.VarChar);
            sqlHelper.AddParameter("@Email", Email, MySqlDbType.VarChar);
            sqlHelper.AddParameter("@Password", Util.GetBase64(UserName), MySqlDbType.VarChar);
            sqlHelper.AddParameter("@Role", Role, MySqlDbType.VarChar);
            sqlHelper.AddParameter("@IsActive", IsActive == "on" ? "Y" : "N", MySqlDbType.VarChar);
            sqlHelper.ExecuteNonQuery();
        }

        public IActionResult OnPostUserById()
        {
            using SqlHelper sqlHelper = new();
            sqlHelper.commandText = "SELECT * FROM User WHERE UserName = @UserName";
            sqlHelper.AddParameter("@UserName", "leo", MySqlDbType.VarChar);
            var dt = sqlHelper.ExecuteDataTable();
            return new JsonResult(dt.Rows[0]);
        }
    }
}
