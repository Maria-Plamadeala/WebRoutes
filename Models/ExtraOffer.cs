using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRoutes.Models
{
    public class ExtraOffer
    {
        public int ID { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "ExtraOffer category name is required"), Required]

        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        [Range(1, 300)]
        [Display(Name = "Price")]
        public decimal price { get; set; }

        
        public ICollection<ExtraOfferCategory> ExtraOfferCategories { get; set; }
    }
}
