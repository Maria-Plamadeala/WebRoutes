using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebRoutes.Models
{
    public class Guide
    {
        public int ID { get; set; }

        [Display(Name = "Guide")]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = 
            "Numele ghidului trebuie sa fie de forma 'Prenume Nume' si sa contina minimum 3 caractere in nume"), Required, StringLength(50, MinimumLength = 3)]
        public string name { get; set; }
        public ICollection<Route> Routes { get; set; }
    }
}
