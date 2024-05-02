using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Warehouse.Class;

namespace Warehouse.Pages
{
    public class UserModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;

		[BindProperty]
		public UserDataModel user { get; set; }

        public UserModel(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void OnGet()
        {
            
        }

        public void OnPostSaveData() {
            using SqlHelper sqlHelper = new SqlHelper();
            if (user.OldUserName == "" | user.OldUserName == null)
            {
                sqlHelper.commandText = " INSERT INTO user (UserName, FullName, Role, NoHP, UserInput, TimeInput, Email, IsActive, Password) " +
                                    " VALUES (@UserName, @FullName, @Role, @NoHP, @User, CURRENT_TIMESTAMP, @Email, @IsActive, @Password)";
                sqlHelper.AddParameter("@UserName", user.UserName, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@FullName", user.FullName, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@Role", user.Role, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@NoHP", user.NoHP, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@User", _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME), MySqlDbType.VarChar);
                sqlHelper.AddParameter("@Email", user.Email, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@IsActive", user.IsActive == null ? "N" : "Y", MySqlDbType.VarChar);
                sqlHelper.AddParameter("@Password", Util.GetBase64(user.UserName), MySqlDbType.VarChar);
            }
            else
            {
                sqlHelper.commandText = "UPDATE user SET UserName = @UserName, FullName = @FullName,Role = @Role , NoHP = @NoHP," +
                                    "Email = @Email, IsActive = @IsActive, TimeEdit = CURRENT_TIMESTAMP, UserEdit = @User " +
                                    "WHERE UserName = @OldUserName";
                sqlHelper.AddParameter("@UserName", user.UserName, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@OldUserName", user.OldUserName, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@FullName", user.FullName, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@Role", user.Role, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@NoHP", user.NoHP, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@User", _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME), MySqlDbType.VarChar);
                sqlHelper.AddParameter("@Email", user.Email, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@IsActive", user.IsActive == null ? "N" : "Y", MySqlDbType.VarChar);
            }
			sqlHelper.ExecuteNonQuery();
        }

        public IActionResult OnPostBtnDelete(string hdnUsernameDelete)
        {
            using SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.commandText = "DELETE FROM user WHERE UserName = @UserName";
            sqlHelper.AddParameter("@UserName", hdnUsernameDelete, MySqlDbType.VarChar);
            sqlHelper.ExecuteNonQuery();
            return Page();
        }

        public IActionResult OnGetViewDetail(string UserName)
        {
            using SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.commandText = "SELECT * FROM user WHERE UserName = @UserName";
            sqlHelper.AddParameter("@UserName", UserName, MySqlDbType.VarChar);
            var result = sqlHelper.ExecuteDataTable();
            return new JsonResult(Util.DataRowToDictionary(result));
        }

        public DataTable GetUserData()
        {
            using SqlHelper sqlHelper = new();
            sqlHelper.commandText = "SELECT * FROM user WHERE Role <> @RoleExcept";
            sqlHelper.AddParameter("@RoleExcept", Util.ROLE_SUPER_ADMIN, MySqlDbType.VarChar);
            return sqlHelper.ExecuteDataTable();
        }
    }
}
