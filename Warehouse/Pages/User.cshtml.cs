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
                sqlHelper.commandText = " INSERT INTO user (UserName, FullName, Role, NoHP, UserInput, TimeInput, Email, IsActive, Password, BranchCode) " +
                                    " VALUES (@UserName, @FullName, @Role, @NoHP, @User, CURRENT_TIMESTAMP, @Email, @IsActive, @Password, @BranchCode)";
                sqlHelper.AddParameter("@UserName", user.UserName, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@FullName", user.FullName, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@Role", user.Role, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@NoHP", user.NoHP, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@User", _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME), MySqlDbType.VarChar);
                sqlHelper.AddParameter("@Email", user.Email, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@BranchCode", user.Role == Util.ROLE_OPERATOR ? user.BranchCode : DBNull.Value, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@IsActive", user.IsActive == null ? "N" : "Y", MySqlDbType.VarChar);
                sqlHelper.AddParameter("@Password", Util.GetBase64(user.UserName), MySqlDbType.VarChar);
            }
            else
            {
                sqlHelper.commandText = "UPDATE user SET UserName = @UserName, FullName = @FullName,Role = @Role , NoHP = @NoHP, BranchCode = @BranchCode, " +
                                    "Email = @Email, IsActive = @IsActive, TimeEdit = CURRENT_TIMESTAMP, UserEdit = @User " +
                                    "WHERE UserName = @OldUserName";
                sqlHelper.AddParameter("@UserName", user.UserName, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@OldUserName", user.OldUserName, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@FullName", user.FullName, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@Role", user.Role, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@NoHP", user.NoHP, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@User", _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME), MySqlDbType.VarChar);
                sqlHelper.AddParameter("@Email", user.Email, MySqlDbType.VarChar);
                sqlHelper.AddParameter("@BranchCode", user.Role == Util.ROLE_OPERATOR ? user.BranchCode : DBNull.Value, MySqlDbType.VarChar);
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
            sqlHelper.commandText = " SELECT A.UserName, A.FullName, A.Role, A.IsActive, B.Name AS Branch, A.NoHP, A.Email FROM user A " +
                                    " LEFT JOIN branch B ON A.BranchCode = B.Code";
            if (_contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_ROLE) == Util.ROLE_ADMIN) {
                sqlHelper.commandText += " WHERE A.Role NOT IN ('ADM', 'SA')";
            }
            else
            {
                sqlHelper.commandText += " WHERE A.Role <> 'SA' ";
            }
            return sqlHelper.ExecuteDataTable();
        }

        public DataTable GetAllBranch()
        {
            SqlHelper sqlHelper = new();
            sqlHelper.commandText = "SELECT * FROM branch ORDER BY Name ASC";
            return sqlHelper.ExecuteDataTable();
        }
    }
}
