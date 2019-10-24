using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Due")]
        public DateTime DueDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Send Home")]
        public DateTime SendHomeDate { get; set; }

        [Display(Name = "Coat")]
        public Coat Coat { get; set; }
        public int CoatId { get; set; }

        [Display(Name = "Size")]
        public Size Size { get; set; }
        public int SizeId { get; set; }

    }
}