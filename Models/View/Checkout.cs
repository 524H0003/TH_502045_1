namespace TH_502045_1.Models.View
{
	public class Checkout
	{
		public int RouteId { get; set; }
		public string PaymentType { get; set; } = string.Empty;
		public decimal Amount { get; set; }

		public string ProcessingMessage { get; set; } = "Vui lòng chọn điểm đến";
	}
}
