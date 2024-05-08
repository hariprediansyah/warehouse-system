using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Data;
using Warehouse.Class;

namespace Warehouse.Pages
{
    public class IndexModel : PageModel
    {
		IHttpContextAccessor _contextAccessor;

        public IndexModel(IHttpContextAccessor contextAccessor)
        {
			_contextAccessor = contextAccessor;
        }

        public void OnGet()
        {

        }

		public IActionResult OnGetChangePassword(string password, string newPassword)
		{
			string userName =  _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME);
			DataTable dt;
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT * FROM user WHERE password = '" + Util.GetBase64(password) + "' " +
									" AND UserName = '" + userName + "'";
			dt = sqlHelper.ExecuteDataTable();
			if (dt.Rows.Count == 0)
			{
				return new JsonResult(Util.APIResponse(false, "Invalid Password"));
			}
			sqlHelper.commandText = " UPDATE user SET password = '" + Util.GetBase64(newPassword) + "' " +
									" WHERE UserName = '" + userName + "' ";
			sqlHelper.ExecuteNonQuery();
			return new JsonResult(Util.APIResponse(true, "Success change password"));
		}
	}
}
