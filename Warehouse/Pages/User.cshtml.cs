using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Warehouse.Class;

namespace Warehouse.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class UserModel(IHttpContextAccessor contextAccessor) : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor = contextAccessor;

        public void OnGet()
        {
            
        }

        public IActionResult OnPostSaveData([FromBody] UserDataModel user) {
            try
            {
                using SqlHelper sqlHelper = new SqlHelper();
                if (user.OldUserName == "" | user.OldUserName == null)
                {
                    sqlHelper.commandText = " INSERT INTO user (UserName, FullName, Role, NoHP, UserInput, TimeInput, Email, IsActive, Password, BranchCode, WarehouseCode) " +
                                        " VALUES (@UserName, @FullName, @Role, @NoHP, @User, CURRENT_TIMESTAMP, @Email, @IsActive, @Password, @BranchCode, @WarehouseCode)";
                    sqlHelper.AddParameter("@UserName", user.UserName, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@FullName", user.FullName, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@Role", user.Role, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@NoHP", user.NoHP, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@User", _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME), MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@Email", user.Email, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@BranchCode", user.Role == Util.ROLE_ADMIN ? DBNull.Value : user.BranchCode, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@WarehouseCode", user.WarehouseCode == null ? DBNull.Value : user.WarehouseCode, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@IsActive", user.IsActive == null ? "N" : "Y", MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@Password", Util.GetBase64(user.UserName), MySqlDbType.VarChar);
                }
                else
                {
                    sqlHelper.commandText = "UPDATE user SET UserName = @UserName, FullName = @FullName,Role = @Role , NoHP = @NoHP, BranchCode = @BranchCode, " +
                                        "WarehouseCode = @WarehouseCode, Email = @Email, IsActive = @IsActive, TimeEdit = CURRENT_TIMESTAMP, UserEdit = @User " +
                                        "WHERE UserName = @OldUserName";
                    sqlHelper.AddParameter("@UserName", user.UserName, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@OldUserName", user.OldUserName, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@FullName", user.FullName, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@Role", user.Role, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@NoHP", user.NoHP, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@User", _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME), MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@Email", user.Email, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@BranchCode", user.Role == Util.ROLE_ADMIN ? DBNull.Value : user.BranchCode, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@WarehouseCode", user.WarehouseCode == null ? DBNull.Value : user.WarehouseCode, MySqlDbType.VarChar);
                    sqlHelper.AddParameter("@IsActive", user.IsActive == null ? "N" : "Y", MySqlDbType.VarChar);
                }
                sqlHelper.ExecuteNonQuery();
                return Util.ReturnJSON(true, "Data saved");
            }catch (Exception ex)
            {
                return Util.ReturnJSON(false, ex.Message);
            }
        }

        public IActionResult OnPostDeleteData(string UserName)
        {
            try
            {
                using SqlHelper sqlHelper = new SqlHelper();
                sqlHelper.commandText = "DELETE FROM user WHERE UserName = @UserName";
                sqlHelper.AddParameter("@UserName", UserName, MySqlDbType.VarChar);
                sqlHelper.ExecuteNonQuery();
            }catch (Exception ex){
                return new JsonResult(Util.APIResponse(false, ex.Message));
            }
            return new JsonResult(Util.APIResponse(true, "Success delete data"));
        }

        public IActionResult OnGetViewDetail(string UserName)
        {
            using SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.commandText = "SELECT * FROM user WHERE UserName = @UserName";
            sqlHelper.AddParameter("@UserName", UserName, MySqlDbType.VarChar);
            var result = sqlHelper.ExecuteDataTable();
            return new JsonResult(Util.DataRowToDictionary(result));
        }

        public IActionResult OnGetAllUser()
        {
            using SqlHelper sqlHelper = new();
            sqlHelper.commandText = " SELECT A.UserName, A.FullName, A.Role, A.IsActive, B.Name AS Branch, C.Name AS Warehouse, A.NoHP, A.Email FROM user A " +
                                    " LEFT JOIN branch B ON A.BranchCode = B.Code " +
                                    " LEFT JOIN warehouse C ON A.WarehouseCode = C.Code ";
            if (_contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_ROLE) == Util.ROLE_ADMIN) {
                sqlHelper.commandText += " WHERE A.Role NOT IN ('ADM', 'SA')";
            }
            else
            {
                sqlHelper.commandText += " WHERE A.Role <> 'SA' ";
            }
            return new JsonResult(Util.DataTableToDictionary(sqlHelper.ExecuteDataTable()));
        }

        public IActionResult OnGetAllWarehouse(string BranchCode)
        {
            using SqlHelper sqlHelper = new();
            sqlHelper.commandText = "SELECT Code, Name FROM warehouse WHERE BranchCode = @BranchCode ORDER BY Name ASC";
            sqlHelper.AddParameter("@BranchCode", BranchCode, MySqlDbType.VarChar);
            return new JsonResult(Util.APIResponse(true, "success", Util.DataTableToDictionary(sqlHelper.ExecuteDataTable())));
        }

        public DataTable GetAllBranch()
        {
            SqlHelper sqlHelper = new()
            {
                commandText = "SELECT * FROM branch ORDER BY Name ASC"
            };
            return sqlHelper.ExecuteDataTable();
        }
    }
}
