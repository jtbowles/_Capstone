using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogBreederCapstone.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Confirmed")]
        public bool Confirmed { get; set; }

        [Required]
        [Display(Name = "Reason for contacting")]
        public string Reason { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public string Time { get; set; }

        public PotentialOwner PotentialOwner { get; set; }
        [Display(Name = "Meeting with")]
        public int? PotentialOwnerId { get; set; }
    }
}