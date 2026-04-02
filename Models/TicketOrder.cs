namespace TH_502045_1.Models
{
    public class TicketOrder
    {
        public int OrderId { get; set; }
        public int RouteId { get; set; }
        public Route? Route { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string? TransactionStatus { get; set; }
        public string? BarcodeData { get; set; }
    }
}
