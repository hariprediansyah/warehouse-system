namespace Warehouse.Models
{
	public class TransactionDataModel
	{
		public string? ID { get; set; }
		public string WarehouseCode { get; set; }
		public string TransactionType { get; set; }
		public string TransactionDate { get; set; }
		public List<TransactionDetailDataModel> Details { get; set; }
	}

	public class TransactionDetailDataModel
	{
		public string ProductCode { get; set; }
		public int Quantity { get; set; }
	}
}
