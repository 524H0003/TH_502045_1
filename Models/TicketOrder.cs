namespace TH_502045_1.Models
{
    public class TicketOrder
    {
        public int TicketOrderId { get; set; }
        public Route? Route { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }

        /*
         * 0: not transferred
         * 1: transferred
         * 9: something went wrong
         */
        public short? isTransferred { get; set; }
        public string? BarcodeData { get; set; }
    }
}
