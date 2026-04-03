using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TH_502045_1.Models;

namespace TH_502045_1.Pages
{
	public class CreditCardPaymentModel : PageModel
	{
		private readonly AppDBContext _context;

		public CreditCardPaymentModel(AppDBContext context) => _context = context;

		public decimal TotalAmount { get; set; }
		public string? DestinationName { get; set; }
		public int Quantity { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			var routeId = HttpContext.Session.GetInt32("SelectedRouteId");
			var route = await _context.Routes.FindAsync(routeId);

			int quantity = HttpContext.Session.GetInt32("TicketQuantity") ?? 0;

			if (route == null || quantity == 0)
			{
				return RedirectToPage("./Index");
			}

			Quantity = quantity;

			TotalAmount = route.Price * Quantity;

			DestinationName = route.DestinationName;

			return Page();
		}

		public async Task<IActionResult> OnPostProcessAsync()
		{
			await Task.Delay(2000);

			return RedirectToPage("./IssueTicket");
		}
	}
}
