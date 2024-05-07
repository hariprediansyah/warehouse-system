using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Warehouse.Class;
using OfficeOpenXml;
using System.Drawing;

namespace Warehouse.Pages
{
    public class ReportModel : PageModel
    {
        private readonly ILogger<ReportModel> _logger;

        public ReportModel(ILogger<ReportModel> logger)
        {
            _logger = logger;
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

        public IActionResult OnGetGenerate(string dtFrom, string dtTo, string TransactionType, string WarehouseCode)
        {
            ExcelPackage ep = new ExcelPackage();
            ExcelWorksheet ws = ep.Workbook.Worksheets.Add("Report");

            var dt = new DataTable();
            var dtDetail = new DataTable();

            using (SqlHelper sqlHelper = new SqlHelper())
            {
                sqlHelper.commandText = " SELECT C.Name AS Branch, " +
                                        "        B.Code AS WarehouseCode,  " +
                                        "        B.Name AS Warehouse,  " +
                                        "        A.TransactionType AS 'Transaction Type', " +
                                        "        DATE_FORMAT(A.TransactionDate, '%Y-%m-%d') AS 'Transaction Date', " +
                                        "        A.ID " +
                                        " FROM transaction A " +
                                        " INNER JOIN warehouse B ON A.WarehouseCode = B.Code " +
                                        " INNER JOIN branch C ON B.BranchCode = C.Code " +
                                        " INNER JOIN user D ON A.UserInput = D.UserName WHERE TransactionDate >= '" + dtFrom + "' " +
                                        " AND TransactionDate < '" + Convert.ToDateTime(dtTo).AddDays(1).ToString("yyyy-MM-dd") + "' ";

                if (TransactionType != null && TransactionType != "")
                {
                    sqlHelper.commandText += " AND TransactionType = '" + TransactionType + "' ";
                }

                if (WarehouseCode != null && WarehouseCode != "")
                {
                    sqlHelper.commandText += " AND WarehouseCode = '" + WarehouseCode + "' ";
                }

                sqlHelper.commandText += " ORDER BY TransactionDate ASC, ID ASC ";
                dt = sqlHelper.ExecuteDataTable();

                sqlHelper.commandText = " SELECT B.Code AS ProductCode, " +
                                        "        B.Name AS ProductName, " +
                                        "        A.Quantity, " +
                                        "        CONVERT(A.TransactionID, CHAR) TransactionID " +
                                        " FROM transactionDetail A" +
                                        " INNER JOIN transaction AA ON A.TransactionID = AA.ID " +
                                        " INNER JOIN product B ON A.ProductCode = B.Code WHERE AA.TransactionDate >= '" + dtFrom + "' " +
                                        " AND AA.TransactionDate < '" + Convert.ToDateTime(dtTo).AddDays(1).ToString("yyyy-MM-dd") + "' ";

                if (TransactionType != null && TransactionType != "")
                {
                    sqlHelper.commandText += " AND AA.TransactionType = '" + TransactionType + "' ";
                }

                if (WarehouseCode != null && WarehouseCode != "")
                {
                    sqlHelper.commandText += " AND AA.WarehouseCode = '" + WarehouseCode + "' ";
                }

                sqlHelper.commandText += " ORDER BY A.TransactionID ASC, B.Name ASC ";

                dtDetail = sqlHelper.ExecuteDataTable();
            }

            ws.Cells["A1"].Value = "Report Transaction";
            ws.Cells[1, 1, 1, 2].Merge = true;
            ws.Cells["A1"].Style.Font.Bold = true;
            ws.Cells["A1"].Style.Font.Size = 15;
            ws.Cells["A3"].Value = "Branch";
            ws.Cells["B3"].Value = "Warehouse Code";
            ws.Cells["C3"].Value = "Warehouse Name";
            ws.Cells["D3"].Value = "Transaction Type";
            ws.Cells["E3"].Value = "Transaction Date";
            ws.Cells["F3"].Value = "Product Code";
            ws.Cells["G3"].Value = "Product Name";
            ws.Cells["H3"].Value = "Quantity";

            ws.Cells[3, 1, 3, 8].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            ws.Cells[3, 1, 3, 8].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            ws.Cells[3, 1, 3, 8].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells[3, 1, 3, 8].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
            ws.Cells[3, 1, 3, 8].Style.Font.Bold = true;
            for (int i = 1; i <= 8; i++)
            {
                ws.Cells[3, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Medium);
            }

            int iRow = 4;
            foreach (DataRow dr in dt.Rows)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (j != 5)
                    {
                        ws.Cells[iRow, j + 1].Value = dr[j].ToString();
                        ws.Cells[iRow, j + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    }
                    else
                    {
                        var filteredRows = from DataRow row in dtDetail.Rows
                                           where row.Field<string>("TransactionID") == dr[j].ToString()
                                           select row;
                        foreach (DataRow drDetail in filteredRows)
                        {
                            for (int k = 0; k <= 2; k++)
                            {
                                ws.Cells[iRow, j + 1 + k].Value = drDetail[k].ToString();
                                ws.Cells[iRow, j + 1 + k].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                if (k == 2)
                                {
                                    ws.Cells[iRow, j + 1 + k].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                }
                                if (k > 0)
                                {
                                    ws.Cells[iRow, 1, iRow, j].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                }
                            }
                            iRow++;
                        }
                    }
                }
            }

            ws.Row(3).Height = 25;
            ws.Column(1).Width = 15;
            ws.Column(2).Width = 19;
            ws.Column(3).Width = 17;
            ws.Column(4).Width = 18;
            ws.Column(5).Width = 18;
            ws.Column(6).Width = 13;
            ws.Column(7).Width = 22;
            ws.Column(8).Width = 13;


            byte[] fileBytes = ep.GetAsByteArray();

            string fileName = "Report Transaction.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(fileBytes, contentType, fileName);
        }
    }

}
