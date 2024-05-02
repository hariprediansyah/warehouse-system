using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Warehouse.Class;
using Warehouse.Models;

namespace Warehouse.Pages
{
	[IgnoreAntiforgeryToken(Order = 1001)]
	public class MasterModel : PageModel
	{
		IHttpContextAccessor _contextAccessor;
		public MasterModel(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}

		public void OnGet()
		{

		}

		public IActionResult OnPostDeleteData([FromBody]DeleteDataModel Delete)
		{
			using SqlHelper sqlHelper = new();
			switch (Delete.From)
			{
				case "Branch":
					sqlHelper.commandText = "DELETE FROM branch WHERE Code = @Code";
					break;
				case "Category":
					sqlHelper.commandText = "DELETE FROM category WHERE Code = @Code";
					break;
				case "Product":
					sqlHelper.commandText = "DELETE FROM product WHERE Code = @Code";
					break;
			}
			sqlHelper.AddParameter("@Code", Delete.CodeDelete, MySqlDbType.VarChar);
			sqlHelper.ExecuteNonQuery();
			return Page();
		}

		#region "Branch"
		public DataTable GetAllBranch()
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT A.Code, A.Name, A.IsActive, B.FullName AS UserInput FROM branch A " +
									" INNER JOIN user B ON A.UserInput = B.UserName ORDER BY A.Name ASC";
			return sqlHelper.ExecuteDataTable();
		}

		public IActionResult OnGetAllBranch()
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT A.Code, A.Name, A.IsActive, B.FullName AS UserInput FROM branch A " +
									" INNER JOIN user B ON A.UserInput = B.UserName";
			return new JsonResult(Util.DataTableToDictionary(sqlHelper.ExecuteDataTable()));
		}

		public IActionResult OnPostSaveDataBranch([FromBody] BranchDataModel Branch)
		{
			using SqlHelper sqlHelper = new();
			if (Branch.IsNew == "Y")
			{
				sqlHelper.commandText = " INSERT INTO branch (Code, Name, IsActive, UserInput, TimeInput) " +
									" VALUES (@Code, @Name, @IsActive, @User, CURRENT_TIMESTAMP) ";
			}
			else
			{
				sqlHelper.commandText = " UPDATE branch SET Name = @Name, IsActive = @IsActive, " +
										" UserEdit = @User, TimeEdit = CURRENT_TIMESTAMP WHERE Code = @Code";
			}
			sqlHelper.AddParameter("@Code", Branch.Code, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@Name", Branch.Name, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@IsActive", Branch.IsActive, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@User", _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME), MySqlDbType.VarChar);
			sqlHelper.ExecuteNonQuery();
			return new JsonResult("Success");
		}

		public IActionResult OnGetViewDetailBranch(string Code)
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = "SELECT Code, Name, IsActive FROM branch WHERE Code = @Code";
			sqlHelper.AddParameter("@Code", Code, MySqlDbType.VarChar);
			DataTable dataTable = sqlHelper.ExecuteDataTable();
			return new JsonResult(Util.DataRowToDictionary(dataTable));
		}
		#endregion

		#region "Category"
		public DataTable GetAllCategory(){
            using SqlHelper sqlHelper = new();
            sqlHelper.commandText = " SELECT A.Code, A.Name, A.Description, B.FullName AS UserInput FROM category A " +
									" INNER JOIN user B ON A.UserInput = B.UserName";
            return sqlHelper.ExecuteDataTable();
        }

		public IActionResult OnGetAllCategory()
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT A.Code, A.Name, A.Description, B.FullName AS UserInput FROM category A " +
									" INNER JOIN user B ON A.UserInput = B.UserName";
			return new JsonResult(Util.DataTableToDictionary(sqlHelper.ExecuteDataTable()));
		}

		public IActionResult OnPostSaveDataCategory([FromBody]CategoryDataModel Category)
		{
			using SqlHelper sqlHelper = new();
			if (Category.IsNew == "Y")
			{
				sqlHelper.commandText = " INSERT INTO category (Code, Name, Description, UserInput, TimeInput) " +
									" VALUES (@Code, @Name, @Description, @User, CURRENT_TIMESTAMP) ";
			}
			else { 
				sqlHelper.commandText = " UPDATE category SET Name = @Name, Description = @Description, " +
										" UserEdit = @User, TimeEdit = CURRENT_TIMESTAMP WHERE Code = @Code";
			}
			sqlHelper.AddParameter("@Code", Category.Code, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@Name", Category.Name, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@Description", Category.Description, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@User", _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME), MySqlDbType.VarChar);
			sqlHelper.ExecuteNonQuery();
			return new JsonResult("Success");
		}

		public IActionResult OnGetViewDetailCategory(string Code)
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = "SELECT * FROM category WHERE Code = @Code";
			sqlHelper.AddParameter("@Code", Code, MySqlDbType.VarChar);
			DataTable dataTable = sqlHelper.ExecuteDataTable();
			return new JsonResult(Util.DataRowToDictionary(dataTable));
		}
		#endregion

		#region "Product"

		public DataTable GetAllProduct()
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT A.Code, A.Name, A.Description, C.Name AS Category, B.FullName AS UserInput FROM product A " +
									" INNER JOIN user B ON A.UserInput = B.UserName " +
									" INNER JOIN category C ON A.Category = C.Code ";
			return sqlHelper.ExecuteDataTable();
		}

		public IActionResult OnGetAllProduct()
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT A.Code, A.Name, A.Description, C.Name AS Category, B.FullName AS UserInput FROM product A " +
									" INNER JOIN user B ON A.UserInput = B.UserName " +
									" INNER JOIN category C ON A.Category = C.Code ";
			return new JsonResult(Util.DataTableToDictionary(sqlHelper.ExecuteDataTable()));
		}

		public IActionResult OnPostSaveDataProduct([FromBody] ProductDataModel Product)
		{
			using SqlHelper sqlHelper = new();
			if (Product.IsNew == "Y")
			{
				sqlHelper.commandText = " INSERT INTO product (Code, Name, Description, Category, UserInput, TimeInput) " +
									" VALUES (@Code, @Name, @Description, @Category, @User, CURRENT_TIMESTAMP) ";
			}
			else
			{
				sqlHelper.commandText = " UPDATE product SET Name = @Name, Description = @Description, Category = @Category, " +
										" UserEdit = @User, TimeEdit = CURRENT_TIMESTAMP WHERE Code = @Code";
			}
			sqlHelper.AddParameter("@Code", Product.Code, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@Name", Product.Name, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@Description", Product.Description, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@Category", Product.Category, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@User", _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME), MySqlDbType.VarChar);
			sqlHelper.ExecuteNonQuery();
			return Content("<script>refreshDataTable();</script>");
		}

		public IActionResult OnGetViewDetailProduct(string Code)
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = "SELECT * FROM product WHERE Code = @Code";
			sqlHelper.AddParameter("@Code", Code, MySqlDbType.VarChar);
			DataTable dataTable = sqlHelper.ExecuteDataTable();
			return new JsonResult(Util.DataRowToDictionary(dataTable));
		}

		#endregion

		#region "Warehouse"
		public DataTable GetAllWarehouse()
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT A.Code, A.Name, A.IsActive, C.Name AS Branch, A.Address, B.FullName AS UserInput " +
									" FROM Warehouse A INNER JOIN user B ON A.UserInput = B.UserName" +
									" INNER JOIN branch C ON A.BranchCode = C.Code ORDER BY A.Name ASC";
			return sqlHelper.ExecuteDataTable();
		}

		public IActionResult OnGetAllWarehouse()
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT A.Code, A.Name, A.IsActive, C.Name AS Branch, A.Address, B.FullName AS UserInput " +
									" FROM Warehouse A INNER JOIN user B ON A.UserInput = B.UserName" +
									" INNER JOIN branch C ON A.BranchCode = C.Code ORDER BY A.Name ASC";
			return new JsonResult(Util.DataTableToDictionary(sqlHelper.ExecuteDataTable()));
		}

		public IActionResult OnPostSaveDataWarehouse([FromBody] WarehouseDataModel Warehouse)
		{
			using SqlHelper sqlHelper = new();
			if (Warehouse.IsNew == "Y")
			{
				sqlHelper.commandText = " INSERT INTO Warehouse (Code, Name, BranchCode, Address, IsActive, UserInput, TimeInput) " +
									" VALUES (@Code, @Name, @BranchCode, @Address, @IsActive, @User, CURRENT_TIMESTAMP) ";
			}
			else
			{
				sqlHelper.commandText = " UPDATE Warehouse SET Name = @Name, BranchCode = @BranchCode, Address = @Address, IsActive = @IsActive, " +
										" UserEdit = @User, TimeEdit = CURRENT_TIMESTAMP WHERE Code = @Code";
			}
			sqlHelper.AddParameter("@Code", Warehouse.Code, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@Name", Warehouse.Name, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@BranchCode", Warehouse.BranchCode, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@Address", Warehouse.Address, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@IsActive", Warehouse.IsActive, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@User", _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME), MySqlDbType.VarChar);
			sqlHelper.ExecuteNonQuery();
			return new JsonResult("Success");
		}

		public IActionResult OnGetViewDetailWarehouse(string Code)
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = "SELECT Code, Name, Address, BranchCode, IsActive FROM warehouse WHERE Code = @Code";
			sqlHelper.AddParameter("@Code", Code, MySqlDbType.VarChar);
			DataTable dataTable = sqlHelper.ExecuteDataTable();
			return new JsonResult(Util.DataRowToDictionary(dataTable));
		}
		#endregion
	}
}
