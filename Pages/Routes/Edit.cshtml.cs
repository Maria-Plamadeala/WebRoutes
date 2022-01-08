using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebRoutes.Data;
using WebRoutes.Models;

namespace WebRoutes.Pages.Routes
{
    public class EditModel : RouteCategoriesPageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public EditModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Route Route { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Route = await _context.Route
                .Include(b => b.Guide)
                .Include(b => b.RouteCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Route == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Route);

            ViewData["guideID"] = new SelectList(_context.Guide, "ID", "name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var routeToUpdate = await _context.Route
           .Include(i => i.Guide)
           .Include(i => i.RouteCategories)
           .ThenInclude(i => i.Category)
           .FirstOrDefaultAsync(s => s.ID == id);
            if (routeToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Route>(
            routeToUpdate,
            "Route",
            i => i.name, i => i.description, i => i.duration,
            i => i.price, i => i.Guide))
            {
                UpdateRouteCategories(_context, selectedCategories, routeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateRouteCategories pentru a aplica informatiile din checkboxuri la entitatea Routes care
            //este editata
            UpdateRouteCategories(_context, selectedCategories, routeToUpdate);
            PopulateAssignedCategoryData(_context, routeToUpdate);
            return Page();
        }
    }
}
