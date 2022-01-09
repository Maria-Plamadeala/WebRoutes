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

namespace WebRoutes.Pages.ExtraCategories
{
    public class EditModel : PageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public EditModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExtraCategory ExtraCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExtraCategory = await _context.ExtraCategory.FirstOrDefaultAsync(m => m.ID == id);

            if (ExtraCategory == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ExtraCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraCategoryExists(ExtraCategory.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExtraCategoryExists(int id)
        {
            return _context.ExtraCategory.Any(e => e.ID == id);
        }
    }
}
