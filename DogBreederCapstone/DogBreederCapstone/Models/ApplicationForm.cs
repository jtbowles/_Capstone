using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogBreederCapstone.Models
{
    public class ApplicationForm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zipcode")]
        public int Zipcode { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required]
        [Display(Name = "How did you hear about us?")]
        public string Referral { get; set; }

        [Required]
        [Display(Name = "What will this dog be used for? (Pet/Companion, service/therapy, hunting, etc.)")]
        public string Use { get; set; }

        [Required]
        [Display(Name = "Where would the puppy live? (inside, outside, crate, etc.)")]
        public string Live { get; set; }

        [Required]
        [Display(Name = "Have you planned on training classes?")]
        public string Training { get; set; }

        [Required]
        [Display(Name = "Have you raised dogs before?")]
        public bool PreviousDogs { get; set; }

        [Display(Name = "Where did those dogs live?")]
        public string PreviousDogsLive { get; set; }

        [Required]
        [Display(Name = "What are your plans for the dog when you go out of town?")]
        public string OutOfTownPlan { get; set; }

        [Required]
        [Display(Name = "Do you have children?")]
        public bool Children { get; set; }

        [Required]
        [Display(Name = "Describe your required fence (electronic, traditional, planned, etc.)")]
        public string Fence { get; set; }

        [Required]
        [Display(Name = "Why do you want this breed?")]
        public string Reasoning { get; set; }

        [Required]
        [Display(Name = "Any allergies or shedding concerns?")]
        public string Allergies { get; set; }

        [Required]
        [Display(Name = "How long will the puppy be alone daily?")]
        public string LeftAlone { get; set; }

        public PotentialOwner PotentialOwner { get; set; }
        public int? PotentialOwnerId { get; set; }
    }
}