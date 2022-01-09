using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebRoutes.Models
{
    public class ExtraCategory
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string extra_category_name { get; set; }
        public ICollection<ExtraOfferCategory> ExtraOfferCategories { get; set; }
    }
}
