using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Warehouse.Pages
{
    public class TransactionModel : PageModel
    {
        private readonly ILogger<TransactionModel> _logger;

        public TransactionModel(ILogger<TransactionModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
