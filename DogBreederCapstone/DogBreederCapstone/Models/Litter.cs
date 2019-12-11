using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DogBreederCapstone.Models
{
    public class Litter
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name ="Litter Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expected Arrival")]
        public DateTime DueDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expected Availability")]
        public DateTime SendHomeDate { get; set; }

        public Coat Coat { get; set; }
        [Display(Name = "Coat")]
        public int CoatId { get; set; }

        public Size Size { get; set; }
        [Display(Name = "Size")]
        public int SizeId { get; set; }

        [NotMapped]
        public int? NumberOfDogs { get; set; }
    }
}