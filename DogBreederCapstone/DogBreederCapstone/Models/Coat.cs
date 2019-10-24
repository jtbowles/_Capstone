using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogBreederCapstone.Models
{
    public class Coat
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Coat Type")]
        public string Name { get; set; }

        [Display(Name = "Colors")]
        public string Colors { get; set; }
    }
}