using System.ComponentModel.DataAnnotations;

namespace DogBreederCapstone.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}