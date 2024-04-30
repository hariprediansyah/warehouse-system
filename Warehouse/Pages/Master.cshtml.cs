using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Warehouse.Class;

namespace Warehouse.Pages
{
	public class MasterModel : PageModel
	{
		public void OnGet()
		{

		}

		public DataTable GetAllCategory(){
            using SqlHelper sqlHelper = new();
            sqlHelper.commandText = "SELECT * FROM Category";
            return sqlHelper.ExecuteDataTable();
        }

	}

	public class MasterData
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string UserInput { get; set; }

		public MasterData(string Code, string Name, string Description, string UserInput)
		{
			this.Code = Code;
			this.Name = Name;
			this.Description = Description;
			this.UserInput = UserInput;
		}
	}
}
