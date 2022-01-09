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
    public class IndexModel : PageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public IndexModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        public IList<ExtraOffer> ExtraOffer { get; set; }
        public ExtraOfferData ExtraOfferD { get; set; }
        public int extraofferID { get; set; }
        public int extracategoryID { get; set; }


        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ExtraOfferD = new ExtraOfferData();
            ExtraOfferD.ExtraOffers = await _context.ExtraOffer
            .Include(b => b.ExtraOfferCategories)
            .ThenInclude(b => b.ExtraCategory)
            .AsNoTracking()
            .OrderBy(b => b.name)
            .ToListAsync();
            if (id != null)
            {
                extraofferID = id.Value;
                ExtraOffer extraoffer = ExtraOfferD.ExtraOffers
                .Where(i => i.ID == id.Value).Single();
                ExtraOfferD.ExtraCategories = extraoffer.ExtraOfferCategories.Select(s => s.ExtraCategory);
            }
        }
    }
}
