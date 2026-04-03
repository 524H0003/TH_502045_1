using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TH_502045_1.Models;

namespace TH_502045_1.Pages
{
	public class SelectPaymentModel(AppDBContext context) : PageModel
	{
		private readonly AppDBContext _context = context;

		public decimal UnitPrice { get; set; }

		public string? Destication { get; set; }

		public int Quantity { get; set; } = 1;

		public decimal TotalAmount { get; set; }

		public async Task<IActionResult> OnGet()
		{
			var routeId = HttpContext.Session.GetInt32("SelectedRouteId");
			var route = await _context.Routes.FindAsync(routeId);

			if (route == null)
			{
				return RedirectToPage("./Index");
			}

			UnitPrice = route.Price;
			TotalAmount = route.Price * this.Quantity;
			Destication = route.DestinationName;

			return Page();
		}

		public IActionResult OnPost(string paymentMethod, int Quantity)
		{
			HttpContext.Session.SetInt32("TicketQuantity", Quantity);
			HttpContext.Session.SetString("PaymentMethod", paymentMethod);

			return RedirectToPage(
				(paymentMethod == "CreditCard" ? "./CreditCard" : "./QRCode")
					+ "Payment"
			);
		}
	}
}
