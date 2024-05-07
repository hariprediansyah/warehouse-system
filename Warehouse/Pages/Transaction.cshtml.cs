using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Data;
using Warehouse.Class;
using Warehouse.Models;

namespace Warehouse.Pages
{
	[IgnoreAntiforgeryToken(Order = 1001)]
	public class TransactionModel : PageModel
    {
        IHttpContextAccessor _contextAccessor;

        public TransactionModel(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void OnGet()
        {
        }

		public DataTable GetAllWarehouse()
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT A.Code, A.Name, A.IsActive, C.Name AS Branch, A.Address, B.FullName AS UserInput " +
									" FROM Warehouse A INNER JOIN user B ON A.UserInput = B.UserName" +
									" INNER JOIN branch C ON A.BranchCode = C.Code ORDER BY A.Name ASC";
			return sqlHelper.ExecuteDataTable();
		}

		public DataTable GetAllProduct()
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT * FROM Product ORDER BY Name ASC";
			return sqlHelper.ExecuteDataTable();
		}

		public IActionResult OnPostDeleteData(string ID)
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = "DELETE FROM transaction WHERE ID = @ID; " +
									"DELETE FROM transactionDetail WHERE TransactionID = @ID";
			sqlHelper.AddParameter("@ID", ID, MySqlDbType.Int64);
			sqlHelper.ExecuteNonQuery();
			return new JsonResult("Success");
		}
		
		public IActionResult OnPostSubmitTransaction(string ID)
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = "UPDATE transaction SET Submitted = 'Y' WHERE ID = @ID; ";
			sqlHelper.AddParameter("@ID", ID, MySqlDbType.Int64);
			sqlHelper.ExecuteNonQuery();
			return new JsonResult("Success");
		}

		public IActionResult OnGetAllTransaction()
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT A.ID, C.Name AS Warehouse, Submitted, TransactionType, DATE_FORMAT(TransactionDate, '%d %M %Y') AS TransactionDate, B.QuantityTotal " +
									" FROM transaction A " +
									" INNER JOIN (SELECT TransactionID, SUM(Quantity) QuantityTotal " +
									"		FROM transactionDetail GROUP BY TransactionID) B ON A.ID = B.TransactionID" +
									" INNER JOIN warehouse C ON A.WarehouseCode = C.Code" +
									" ORDER BY Submitted ASC, A.TransactionDate DESC, A.TimeInput DESC";
			return new JsonResult(Util.DataTableToDictionary(sqlHelper.ExecuteDataTable()));
		}

		public IActionResult OnPostSaveDataTransaction([FromBody] TransactionDataModel transaction)
		{
			string UserName = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_NAME);
			using SqlHelper sqlHelper = new();
			if (transaction.ID == null || transaction.ID == "")
			{
				sqlHelper.commandText = " INSERT INTO transaction (WarehouseCode, TransactionType, TransactionDate, UserInput, TimeInput) " +
										" VALUES (@WarehouseCode, @TransactionType, @TransactionDate, @User, CURRENT_TIMESTAMP);" +
										" SELECT LAST_INSERT_ID()";
			}
			else
			{
				sqlHelper.commandText = " UPDATE transaction SET WarehouseCode = @WarehouseCode, TransactionType = @TransactionType, " +
										" TransactionDate = @TransactionDate, UserEdit = @User, TimeEdit = CURRENT_TIMESTAMP WHERE ID = @ID; " +
										" DELETE FROM transactionDetail WHERE TransactionID = @ID;" +
										" SELECT @ID ";
			}
			sqlHelper.AddParameter("@ID", transaction.ID == null ? "0" : transaction.ID, MySqlDbType.Int64);
			sqlHelper.AddParameter("@WarehouseCode", transaction.WarehouseCode, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@TransactionType", transaction.TransactionType, MySqlDbType.VarChar);
			sqlHelper.AddParameter("@TransactionDate", transaction.TransactionDate, MySqlDbType.Date);
			sqlHelper.AddParameter("@User", UserName, MySqlDbType.VarChar);
			transaction.ID = sqlHelper.ExecuteScalar();

			foreach (TransactionDetailDataModel detail in transaction.Details)
			{
				sqlHelper.ClearParameters();
				sqlHelper.commandText = " INSERT INTO transactiondetail (TransactionID, ProductCode, Quantity, UserInput, TimeInput) " +
										" VALUES (@TransactionID, @ProductCode, @Quantity, @User, CURRENT_TIMESTAMP) ";
				sqlHelper.AddParameter("@TransactionID", transaction.ID, MySqlDbType.Int64);
				sqlHelper.AddParameter("@ProductCode", detail.ProductCode, MySqlDbType.VarChar);
				sqlHelper.AddParameter("@Quantity", detail.Quantity, MySqlDbType.Int64);
				sqlHelper.AddParameter("@User", UserName, MySqlDbType.VarChar);
				sqlHelper.ExecuteNonQuery();
			}
			return new JsonResult("Success");
		}

		public IActionResult OnGetViewDetailTransaction(string ID)
		{
			using SqlHelper sqlHelper = new();
			sqlHelper.commandText = " SELECT ID, WarehouseCode, Submitted, TransactionType, DATE_FORMAT(TransactionDate, '%Y-%m-%d') AS TransactionDate FROM transaction WHERE ID = @ID;" +
									" SELECT A.ID, B.Name AS Product, A.ProductCode, A.Quantity FROM transactionDetail A INNER JOIN product B ON A.ProductCode = B.Code " +
									" WHERE TransactionID = @ID";
			sqlHelper.AddParameter("@ID", ID, MySqlDbType.VarChar);
			DataSet ds = sqlHelper.ExecuteDataSet();
			Dictionary<string, object> retData = new();
			retData["Transaction"] = Util.DataRowToDictionary(ds.Tables[0]);
			retData["Details"] = Util.DataTableToDictionary(ds.Tables[1]);

			return new JsonResult(retData);
		}
	}

}
