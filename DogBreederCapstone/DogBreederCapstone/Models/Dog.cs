using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace DogBreederCapstone.Models
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }

        public Litter Litter { get; set; }
        [Display(Name = "Litter")]
        public int LitterId { get; set; }

        public Gender Gender { get; set; }
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        public Collar Collar { get; set; }
        [Display(Name = "Puppy Collar")]
        public int CollarId { get; set; }
    
        public Image Image { get; set; }
        [Display(Name = "Image")]
        public int? ImageId { get; set; }

        public PotentialOwner PotentialOwner { get; set; }
        [Display(Name = "Owner")]
        public int? PotentialOwnerId { get; set; }

        public bool isReserved { get; set; }
    }
}