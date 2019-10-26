using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogBreederCapstone.Models
{
    public class Collar
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
    }
}