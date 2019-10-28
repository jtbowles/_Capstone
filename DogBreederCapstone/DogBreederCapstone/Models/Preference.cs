using System.ComponentModel.DataAnnotations;

namespace DogBreederCapstone.Models
{
    public class Preference
    {
        [Key]
        public int Id { get; set; }

        public bool IsMicro { get; set; }
        public bool IsMini { get; set; }
        public bool IsMedium { get; set; }
        public bool IsStandard { get; set; }
        public bool IsCaramel { get; set; }
        public bool IsRed { get; set; }
        public bool IsBlue { get; set; }
        public bool IsSilver { get; set; }
        public bool IsCafe { get; set; }
        public bool IsChocolate { get; set; }
        public bool IsParchment { get; set; }
        public bool IsLavender { get; set; }
    }
}