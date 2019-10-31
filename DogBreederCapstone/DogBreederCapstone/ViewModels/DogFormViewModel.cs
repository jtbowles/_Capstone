using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DogBreederCapstone.Models;

namespace DogBreederCapstone.ViewModels
{
    public class DogFormViewModel
    {
        public Dog Dog { get; set; }
        public IEnumerable<Litter> Litters { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public IEnumerable<Collar> Collars { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}