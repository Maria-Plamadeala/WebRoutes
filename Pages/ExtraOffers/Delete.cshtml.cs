using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRoutes.Data;
using WebRoutes.Models;

namespace WebRoutes.Pages.ExtraOffers
{
    public class DeleteModel : PageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public DeleteModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExtraOffer ExtraOffer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExtraOffer = await _context.ExtraOffer.FirstOrDefaultAsync(m => m.ID == id);

            if (ExtraOffer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExtraOffer = await _context.ExtraOffer.FindAsync(id);

            if (ExtraOffer != null)
            {
                _context.ExtraOffer.Remove(ExtraOffer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
