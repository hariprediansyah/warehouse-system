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

		public string ProductCount()
		{
			string userRole = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_ROLE);
			string userBranchCode = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_BRANCH_CODE);
			string userWarehouse = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_WAREHOUSE_CODE);
			
			using SqlHelper sqlHelper = new SqlHelper();
			switch (userRole)
			{
				case "ADM":
				case "SA":
					sqlHelper.commandText = " Select Count(productCode) FROM (Select productCode from transactiondetail A " +
											" INNER JOIN transaction B ON A.TransactionID = B.ID " +
											" WHERE  B.Status = '2' " +
											" GROUP by productCode) A";
					break;
				case "BM":
					sqlHelper.commandText = " Select Count(productCode) FROM ( " +
											" Select productCode from transactiondetail A" +
											" INNER JOIN transaction B ON A.TransactionID = B.ID" +
											" INNER JOIN warehouse C ON B.WarehouseCode = C.Code" +
											" WHERE C.BranchCode = @BranchCode AND B.Status = '2'" +
											" GROUP by productCode) A";
					sqlHelper.AddParameter("@BranchCode", userBranchCode, MySql.Data.MySqlClient.MySqlDbType.VarChar);
					break;
				default:
					sqlHelper.commandText = " Select Count(productCode) FROM ( " +
											" Select productCode from transactiondetail A" +
											" INNER JOIN transaction B ON A.TransactionID = B.ID" +
											" WHERE B.WarehouseCode = @WarehouseCode AND B.Status = '2'" +
											" GROUP by productCode) A";
					sqlHelper.AddParameter("@WarehouseCode", userWarehouse, MySql.Data.MySqlClient.MySqlDbType.VarChar);
					break;

			}
			return sqlHelper.ExecuteScalar();
		}

		public string AllTransaction()
		{
			string userRole = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_ROLE);
			string userBranchCode = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_BRANCH_CODE);
			string userWarehouse = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_WAREHOUSE_CODE);

			using SqlHelper sqlHelper = new SqlHelper();
			switch (userRole)
			{
				case "ADM":
				case "SA":
					sqlHelper.commandText = " SELECT * FROM transaction WHERE Status = 2 ";
					break;
				case "BM":
					sqlHelper.commandText = " SELECT COUNT(*) FROM transaction A " +
											" INNER JOIN warehouse B ON A.WarehouseCode = B.Code " +
											" WHERE Status = 2 AND B.BranchCode = @BranchCode";
					sqlHelper.AddParameter("@BranchCode", userBranchCode, MySql.Data.MySqlClient.MySqlDbType.VarChar);
					break;
				default:
					sqlHelper.commandText = "SELECT * FROM `transaction` WHERE WarehouseCode = @WarehouseCode";
					sqlHelper.AddParameter("@WarehouseCode", userWarehouse, MySql.Data.MySqlClient.MySqlDbType.VarChar);
					break;

			}
			return sqlHelper.ExecuteScalar();
		}
		public string AllTransactionWeek()
		{
			string userRole = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_ROLE);
			string userBranchCode = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_BRANCH_CODE);
			string userWarehouse = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_WAREHOUSE_CODE);

			DateTime dtNow = DateTime.Now;
			string dtStart = dtNow.AddDays(-(int)dtNow.DayOfWeek).ToString("yyyy-MM-dd");
			string dtEnd = dtNow.AddDays(6 - (int)dtNow.DayOfWeek).ToString("yyyy-MM-dd");

			using SqlHelper sqlHelper = new SqlHelper();
			switch (userRole)
			{
				case "ADM":
				case "SA":
					sqlHelper.commandText = " SELECT * FROM transaction WHERE Status = 2 AND TransactionDate BETWEEN @DtFrom AND @DtTo ";
					sqlHelper.AddParameter("@DtFrom", dtStart, MySql.Data.MySqlClient.MySqlDbType.Date);
					sqlHelper.AddParameter("@DtTo", dtEnd, MySql.Data.MySqlClient.MySqlDbType.Date);
					break;
				case "BM":
					sqlHelper.commandText = " SELECT COUNT(*) FROM transaction A " +
											" INNER JOIN warehouse B ON A.WarehouseCode = B.Code " +
											" WHERE Status = 2 AND B.BranchCode = @BranchCode AND A.TransactionDate BETWEEN @DtFrom AND @DtTo ";
					sqlHelper.AddParameter("@BranchCode", userBranchCode, MySql.Data.MySqlClient.MySqlDbType.VarChar);
					sqlHelper.AddParameter("@DtFrom", dtStart, MySql.Data.MySqlClient.MySqlDbType.Date);
					sqlHelper.AddParameter("@DtTo", dtEnd, MySql.Data.MySqlClient.MySqlDbType.Date);
					break;
				default:
					sqlHelper.commandText = "SELECT * FROM `transaction` WHERE WarehouseCode = @WarehouseCode AND TransactionDate BETWEEN @DtFrom AND @DtTo";
					sqlHelper.AddParameter("@WarehouseCode", userWarehouse, MySql.Data.MySqlClient.MySqlDbType.VarChar);
					sqlHelper.AddParameter("@DtFrom", dtStart, MySql.Data.MySqlClient.MySqlDbType.Date);
					sqlHelper.AddParameter("@DtTo", dtEnd, MySql.Data.MySqlClient.MySqlDbType.Date);
					break;

			}
			return sqlHelper.ExecuteScalar();
		}

		public string AllTransactionToday()
		{
			string userRole = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_ROLE);
			string userBranchCode = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_BRANCH_CODE);
			string userWarehouse = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_WAREHOUSE_CODE);

			using SqlHelper sqlHelper = new SqlHelper();
			switch (userRole)
			{
				case "ADM":
				case "SA":
					sqlHelper.commandText = " SELECT * FROM transaction WHERE Status = 2 AND TransactionDate = @TransactionDate ";
					sqlHelper.AddParameter("@TransactionDate", DateTime.Now.ToString("yyyy-MM-dd"), MySql.Data.MySqlClient.MySqlDbType.Date);
					break;
				case "BM":
					sqlHelper.commandText = " SELECT COUNT(*) FROM transaction A " +
											" INNER JOIN warehouse B ON A.WarehouseCode = B.Code " +
											" WHERE Status = 2 AND B.BranchCode = @BranchCode AND TransactionDate = @TransactionDate";
					sqlHelper.AddParameter("@BranchCode", userBranchCode, MySql.Data.MySqlClient.MySqlDbType.VarChar);
					sqlHelper.AddParameter("@TransactionDate", DateTime.Now.ToString("yyyy-MM-dd"), MySql.Data.MySqlClient.MySqlDbType.Date);
					break;
				default:
					sqlHelper.commandText = "SELECT COUNT(*) FROM `transaction` WHERE WarehouseCode = @WarehouseCode AND TransactionDate = @TransactionDate";
					sqlHelper.AddParameter("@WarehouseCode", userWarehouse, MySql.Data.MySqlClient.MySqlDbType.VarChar);
					sqlHelper.AddParameter("@TransactionDate", DateTime.Now.ToString("yyyy-MM-dd"), MySql.Data.MySqlClient.MySqlDbType.Date);
					break;

			}
			return sqlHelper.ExecuteScalar();
		}

		public DataTable GetProductAll()
		{
			string userRole = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_ROLE);
			string userBranchCode = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_BRANCH_CODE);
			string userWarehouse = _contextAccessor.HttpContext.Session.GetString(Util.SESSION_USER_WAREHOUSE_CODE);

			SqlHelper sqlHelper = new SqlHelper();
			sqlHelper.commandText = " SELECT " +
									"    C.Name AS ProductName," +
									"   (SELECT     " +
									"		 COALESCE(SUM(CASE " +
									"				WHEN A.TransactionType = 'IN' THEN B.Quantity" +
									"				WHEN A.TransactionType = 'OUT' THEN -B.Quantity" +
									"				ELSE 0" +
									"			END), 0) AS CurrentStock" +
									"   FROM " +
									"		`transaction` A" +
									"   INNER JOIN warehouse AA ON A.WarehouseCode = AA.Code" +
									"   INNER JOIN " +
									"		transactiondetail B ON A.ID = B.TransactionID" +
									"  WHERE   " +
									"		B.ProductCode = C.Code AND A.Status = 2 ";

			switch (userRole)
			{
				case "ADM":
				case "SA":
					sqlHelper.commandText += " ";
					break;
				case "BM":
					sqlHelper.commandText += " AND AA.BranchCode = @BranchCode ";
					sqlHelper.AddParameter("@BranchCode", userBranchCode, MySql.Data.MySqlClient.MySqlDbType.VarChar);
					break;
				default:
					sqlHelper.commandText += " AND A.WarehouseCode = @WarehouseCode";
					sqlHelper.AddParameter("@WarehouseCode", userWarehouse, MySql.Data.MySqlClient.MySqlDbType.VarChar);
					break;

			}

			sqlHelper.commandText += ") AS Stock" +
									"  FROM" +
									"  product C";
			return sqlHelper.ExecuteDataTable();
		}

		public string[] TransactionData()
		{
			DateTime dtNow = DateTime.Now;
			DateTime minggu = dtNow.AddDays(-(int)dtNow.DayOfWeek);
			DateTime senin = minggu.AddDays(1);
			DateTime selasa = minggu.AddDays(2);
			DateTime rabu = minggu.AddDays(3);
			DateTime kamis = minggu.AddDays(4);
			DateTime jumat = minggu.AddDays(5);
			DateTime sabtu = minggu.AddDays(6);

			string[] strings = new string[7];
			SqlHelper sqlHelper = new SqlHelper();
			sqlHelper.commandText = "SELECT COUNT(*) FROM transaction WHERE TransactionDate = '" + minggu.ToString("yyyy-MM-dd") + "'";
			strings[0] = sqlHelper.ExecuteScalar();

			sqlHelper.commandText = "SELECT COUNT(*) FROM transaction WHERE TransactionDate = '" + senin.ToString("yyyy-MM-dd") + "'";
			strings[1] = sqlHelper.ExecuteScalar();

			sqlHelper.commandText = "SELECT COUNT(*) FROM transaction WHERE TransactionDate = '" + selasa.ToString("yyyy-MM-dd") + "'";
			strings[2] = sqlHelper.ExecuteScalar();

			sqlHelper.commandText = "SELECT COUNT(*) FROM transaction WHERE TransactionDate = '" + rabu.ToString("yyyy-MM-dd") + "'";
			strings[3] = sqlHelper.ExecuteScalar();

			sqlHelper.commandText = "SELECT COUNT(*) FROM transaction WHERE TransactionDate = '" + kamis.ToString("yyyy-MM-dd") + "'";
			strings[4] = sqlHelper.ExecuteScalar();

			sqlHelper.commandText = "SELECT COUNT(*) FROM transaction WHERE TransactionDate = '" + jumat.ToString("yyyy-MM-dd") + "'";
			strings[5] = sqlHelper.ExecuteScalar();

			sqlHelper.commandText = "SELECT COUNT(*) FROM transaction WHERE TransactionDate = '" + sabtu.ToString("yyyy-MM-dd") + "'";
			strings[6] = sqlHelper.ExecuteScalar();
			return strings;
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
