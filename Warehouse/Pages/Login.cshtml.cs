using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Data;
using Warehouse.Class;

namespace Warehouse.Pages
{
    public class LoginModel : PageModel
    {
        readonly IHttpContextAccessor _contextAccessor;
        [BindProperty]
        public string Username{ get; set; }
        
        [BindProperty]
        public string Password { get; set; }

        public LoginModel(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostLogin(string UserName, string Password) {
            using SqlHelper sqlHelper = new ();
            sqlHelper.commandText = "SELECT * FROM user WHERE UserName = @UserName AND Password = @Password";
            sqlHelper.AddParameter("@UserName", UserName, MySqlDbType.VarChar);
            sqlHelper.AddParameter("@Password", Util.GetBase64(Password), MySqlDbType.VarChar);
            var result = sqlHelper.ExecuteDataTable();
            if (result.Rows.Count == 0)
            {
                TempData["ErrorMessage"] = "Invalid Username / Password";
                return Page();
            }
            else
            {
                _contextAccessor.HttpContext.Session.SetString(Util.SESSION_USER_NAME, result.Rows[0]["UserName"].ToString());
                _contextAccessor.HttpContext.Session.SetString(Util.SESSION_USER_ROLE, result.Rows[0]["Role"].ToString());
				_contextAccessor.HttpContext.Session.SetString(Util.SESSION_USER_ROLE_NAME, Util.RoleName(result.Rows[0]["Role"].ToString()));
				_contextAccessor.HttpContext.Session.SetString(Util.SESSION_FULL_NAME, result.Rows[0]["FullName"].ToString());

                return RedirectToPage("/index");
            }
        }
    }
}
