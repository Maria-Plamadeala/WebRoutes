using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRoutes.Models
{
    public class ExtraOfferData
    {
        public IEnumerable<ExtraOffer> ExtraOffers { get; set; }
        public IEnumerable<ExtraCategory> ExtraCategories { get; set; }
        public IEnumerable<ExtraOfferCategory> ExtraOfferCategories { get; set; }
    }
}
