using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Warehouse.Models;

namespace Warehouse.Pages
{
    public class LoginModel : PageModel
    {
        WarehouseContext _context;
        IHttpContextAccessor _contextAccessor;
        [BindProperty]
        public string Username{ get; set; }
        
        [BindProperty]
        public string Password { get; set; }

        public LoginModel(WarehouseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _contextAccessor = httpContextAccessor;
            _context.Database.EnsureCreated();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost() {
            var result = _context.User.Find(Username);
            if (result == null || (result != null && Password != Util.StringFromBase64(result.Password)))
            {
                TempData["ErrorMessage"] = "Invalid Username / Password";
                return Page();
            }
            else
            {
                _contextAccessor.HttpContext.Session.SetString(Util.SESSION_USER_NAME, result.UserName);
                _contextAccessor.HttpContext.Session.SetString(Util.SESSION_USER_ROLE, result.Role);
				_contextAccessor.HttpContext.Session.SetString(Util.SESSION_USER_ROLE_NAME, Util.RoleName(result.Role));
				_contextAccessor.HttpContext.Session.SetString(Util.SESSION_FULL_NAME, result.FullName);

                return RedirectToPage("/index");
            }
        }
    }
}
