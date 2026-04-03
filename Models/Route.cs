namespace TH_502045_1.Models
{
	public class Route
	{
		public int RouteId { get; set; }

		public string DestinationName { get; set; } = string.Empty;

		public decimal Price { get; set; }

		public bool IsActive { get; set; }
	}
}
