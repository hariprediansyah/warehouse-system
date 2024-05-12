namespace Warehouse;

using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System.Data;
using System.Text;

public class Util
{
    public readonly static string SESSION_USER_NAME = "UserName";
    public readonly static string SESSION_FULL_NAME = "FullName";
    public readonly static string SESSION_USER_ROLE = "Role";
    public readonly static string SESSION_USER_ROLE_NAME = "RoleName";
    public readonly static string SESSION_USER_WAREHOUSE_CODE = "WarehouseCode";
    public readonly static string SESSION_USER_BRANCH_CODE = "BranchCode";

    public readonly static string ROLE_ADMIN = "ADM";
    public readonly static string ROLE_SUPER_ADMIN = "SA";
    public readonly static string ROLE_BRANCH_MANAGER = "BM";
    public readonly static string ROLE_OPERATOR = "OPR";

    public static string GetBase64(string text){
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
    }

    public static string StringFromBase64(string text)
    {
        var data = Convert.FromBase64String(text);
        return Encoding.UTF8.GetString(data);
    }

    public static string RoleName(string code)
    {
        switch (code)
        {
            case "SA":
                return "Super Admin";
            case "ADM":
                return "Admin";
            case "OPR":
                return "Operator";
            default:
                return "Branch Manager";
        }
    }

    public static Dictionary<string, object> DataRowToDictionary(DataTable dataTable)
    {
        // Get the first row from the DataTable
        DataRow row = dataTable.Rows[0];

        // Convert the DataRow into a dictionary
        var data = new Dictionary<string, object>();

        foreach (DataColumn col in dataTable.Columns)
        {
            var value = row[col];
            if (value is DBNull || (value != null && value.ToString() == "{}"))
            {
                value = null; // Change {} or DBNull to null
            }

            data[col.ColumnName] = value;
        }
        return data;
    }

    public static List<Dictionary<string, object>> DataTableToDictionary(DataTable dataTable)
    {
		var data = new List<Dictionary<string, object>>();
		foreach (DataRow row in dataTable.Rows)
		{
			var rowData = new Dictionary<string, object>();
			foreach (DataColumn col in dataTable.Columns)
			{
				rowData[col.ColumnName] = row[col]; var value = row[col];
				if (value is DBNull || (value != null && value.ToString() == "{}"))
				{
					value = null; // Change {} or DBNull to null
				}

				rowData[col.ColumnName] = value;
			}
			data.Add(rowData);
		}
        return data;
	}

	public static Dictionary<string, object> APIResponse(bool ok, string message, object? data = null) => new()
	{
		["ok"] = ok,
		["message"] = message,
		["data"] = data
	};

    public static JsonResult ReturnJSON(bool ok, string message, object? data = null)
    {
        return new JsonResult(APIResponse(ok, message, data));
    }
}
