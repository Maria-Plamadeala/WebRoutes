using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebRoutes.Data;
using WebRoutes.Models;


namespace WebRoutes.Pages.Routes
{
    public class CreateModel : RouteCategoriesPageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public CreateModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["guideID"] = new SelectList(_context.Guide, "ID", "name");

            var route = new Route();
            route.RouteCategories = new List<RouteCategory>();
            PopulateAssignedCategoryData(_context, route);

            return Page();
        }

        [BindProperty]
        public Route Route { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newRoute = new Route();
            if (selectedCategories != null)
            {
                newRoute.RouteCategories = new List<RouteCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new RouteCategory
                    {
                        categoryID = int.Parse(cat)
                    };
                    newRoute.RouteCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Route>(
           newRoute,
           "Route",
           i => i.name, i => i.description, i => i.duration,
           i => i.price, i => i.guideID))
            {
                _context.Route.Add(newRoute);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newRoute);
            return Page();
        }
    }
}
