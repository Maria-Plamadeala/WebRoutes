using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebRoutes.Data;
using WebRoutes.Models;

namespace WebRoutes.Pages.Guides
{
    public class CreateModel : PageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public CreateModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Guide Guide { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Guide.Add(Guide);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
