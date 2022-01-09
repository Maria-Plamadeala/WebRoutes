using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebRoutes.Models
{
    public class ExtraOfferCategory
    {
        public int ID { get; set; }
        public int extraofferID { get; set; }
        public ExtraOffer ExtraOffer { get; set; }
        public int extracategoryID { get; set; }
        public ExtraCategory ExtraCategory { get; set; }
    }
}
