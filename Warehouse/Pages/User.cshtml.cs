using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MySql.Data.MySqlClient;
using Warehouse.Class;
using Warehouse.Models;

namespace Warehouse.Pages
{
    public class UserModel : PageModel
    {
        private readonly WarehouseContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

		[BindProperty]
		public UserDataModel user { get; set; }
        public List<UserDataModel> userList { get; set; }
        public UserModel(WarehouseContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public void OnGet()
        {
            FillData();
        }

        public void OnPostSaveData() {
            var result = _context.User.FirstOrDefault(row => row.UserName == user.UserName);            
            using SqlHelper sqlHelper = new SqlHelper();

            sqlHelper.commandText = " INSERT INTO user (UserName, FullName, Role, NoHP, UserInput, TimeInput, Email, IsActive, Password) " +
                                    " VALUES (@UserName, @FullName, @Role, @NoHP, @User, CURRENT_TIMESTAMP, @Email, @IsActive, @Password)";
            sqlHelper.AddParameter("@UserName", user.UserName, MySqlDbType.VarChar);
            sqlHelper.AddParameter("@FullName", user.FullName, MySqlDbType.LongText);
            sqlHelper.AddParameter("@Role", user.Role, MySqlDbType.LongText);
            sqlHelper.AddParameter("@NoHP", user.NoHP, MySqlDbType.LongText);
            sqlHelper.AddParameter("@User", _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME), MySqlDbType.LongText);
            sqlHelper.AddParameter("@Email", user.Email, MySqlDbType.LongText);
            sqlHelper.AddParameter("@IsActive", user.IsActive == null ? "N" : "Y", MySqlDbType.LongText);
            sqlHelper.AddParameter("@Password", Util.GetBase64(user.UserName), MySqlDbType.LongText);

            sqlHelper.commandText = "UPDATE user SET UserName = @UserNameNew, FullName = @FullName,Role = @Role , NoHP = @NoHP," +
                                    "Email = @Email, IsActive = @IsActive, TimeEdit = CURRENT_TIMESTAMP, UserEdit = @User " +
                                    "WHERE UserName = @UserName";

			sqlHelper.ExecuteNonQuery();

			//if (result == null)
   //         {
   //             user.IsActive = user.IsActive == null ? "N" : "Y";
   //             user.Password = Util.GetBase64(user.UserName);
   //             user.UserInput = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME);
   //             user.TimeInput = DateTime.Now;
   //             _context.ChangeTracker.Clear();
   //             _context.User.Add(user);
   //             _context.SaveChanges();
   //         }
   //         else
   //         {
			//	user.IsActive = user.IsActive == null ? "N" : "Y";
			//	user.UserEdit = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME);
   //             user.TimeEdit = DateTime.Now;
   //             _context.ChangeTracker.Clear();
   //             _context.User.Update(user);
   //             _context.SaveChanges();
   //         }
            FillData();
        }

        public IActionResult OnPostBtnDelete(string hdnUsernameDelete)
        {
            user = _context.User.FirstOrDefault(user => user.UserName == hdnUsernameDelete);
            _context.User.Remove(user);
            _context.SaveChanges();
            FillData();
            return Page();
        }

        public IActionResult OnGetViewDetail(string UserName)
        {
            user = _context.User.FirstOrDefault(user=>user.UserName == UserName);
            _context.SaveChanges();
            return new JsonResult(user);
        }

        public void FillData()
        {
            userList = [.. _context.User.Where(el => el.Role != Util.ROLE_SUPER_ADMIN)];
        }
    }
}
