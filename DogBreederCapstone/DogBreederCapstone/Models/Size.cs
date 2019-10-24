using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogBreederCapstone.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Size")]
        public string Name { get; set; }

        [Display(Name = "Height in Inches")]
        public int Height { get; set; }

        [Display(Name = "Weight in Pounds")]
        public int Weight { get; set; }
    }
}