using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TH_502045_1.Models;

namespace TH_502045_1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _context;

        public IndexModel(AppDBContext context) => _context = context;

        public List<Models.Route> AvailableRoutes { get; set; } = new();

        public async Task OnGetAsync()
        {
            AvailableRoutes = await _context.Routes.Where(r => r.IsActive).ToListAsync();
        }

        public async Task<IActionResult> OnPostSelectRouteAsync(int routeId)
        {
            var selectedRoute = await _context.Routes.FindAsync(routeId);

            if (selectedRoute == null)
                return Page();

            HttpContext.Session.SetInt32("SelectedRouteId", routeId);

            return RedirectToPage("./SelectPayment");
        }
    }
}
