using DogBreederCapstone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogBreederCapstone.Dtos
{
    public class LitterDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime SendHomeDate { get; set; }

        public int CoatId { get; set; }
        public CoatDto Coat { get; set; }

        public int SizeId { get; set; }
        public SizeDto Size { get; set; }

    }
}