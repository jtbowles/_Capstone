using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DogBreederCapstone.Models;

namespace DogBreederCapstone.Dtos
{
    public class DogDto
    {
        public int Id { get; set; }

        public int LitterId { get; set; }
        public LitterDto Litter { get; set; }

        public int GenderId { get; set; }
        public GenderDto Gender { get; set; }

        public int CollarId { get; set; }
        public CollarDto Collar { get; set; }

    }
}