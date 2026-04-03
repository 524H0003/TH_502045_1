using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TH_502045_1.Models;

namespace TH_502045_1.Pages
{
	public class IssueTicketModel : PageModel
	{
		private readonly AppDBContext _context;

		public IssueTicketModel(AppDBContext context) => _context = context;

		public string Barcode { get; set; } = string.Empty;
		public decimal TotalPaid { get; set; }
		public int TicketQty { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			var qty = HttpContext.Session.GetInt32("TicketQuantity");
			var routeId = HttpContext.Session.GetInt32("SelectedRouteId");
			var route = await _context.Routes.FindAsync(routeId);
			var method = HttpContext.Session.GetString("PaymentMethod");

			if (route == null)
				return RedirectToPage("./Index");

			TicketQty = qty ?? 1;
			TotalPaid = TicketQty * route.Price;
			Barcode = "METRO-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

			var newOrder = new TicketOrder
			{
				Route = route,
				PurchaseDate = DateTime.Now,
				PaymentMethod = method ?? "Unknown",
				TotalAmount = TotalPaid,
				isTransferred = 1,
				BarcodeData = Barcode,
			};

			_context.TicketOrders.Add(newOrder);
			await _context.SaveChangesAsync();

			HttpContext.Session.Clear();

			return Page();
		}
	}
}
