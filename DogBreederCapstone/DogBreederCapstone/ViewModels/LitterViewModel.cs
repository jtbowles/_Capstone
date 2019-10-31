using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DogBreederCapstone.Models;

namespace DogBreederCapstone.ViewModels
{
    public class LitterViewModel
    {
        public IEnumerable<Dog> Dogs { get; set; }
        public Litter Litter { get; set; }
        public PotentialOwner PotentialOwner { get; set; }
    }
}