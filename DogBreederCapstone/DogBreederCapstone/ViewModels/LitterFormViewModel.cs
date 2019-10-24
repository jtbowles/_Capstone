using DogBreederCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogBreederCapstone.ViewModels
{
    public class LitterFormViewModel
    {
        public IEnumerable<Coat> Coats { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
        public Litter Litter { get; set; }
    }
}