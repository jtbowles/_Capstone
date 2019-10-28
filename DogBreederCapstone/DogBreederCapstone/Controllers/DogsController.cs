using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DogBreederCapstone.Models;
using DogBreederCapstone.Utilities;
using DogBreederCapstone.ViewModels;

namespace DogBreederCapstone.Controllers
{
    public class DogsController : Controller
    {
        private ApplicationDbContext context;

        public DogsController()
        {
            context = new ApplicationDbContext();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var dogsFromDb = context.Dogs
                .Include(d => d.Collar)
                .Include(d => d.Gender)
                .Include(d => d.Litter)
                .ToList();

            if (User.IsInRole(RoleName.Breeder))
            {
                return View("List", dogsFromDb);
            }

            return View("ReadOnlyList", dogsFromDb);
        }

        public ActionResult GetDogs(int? id)
        {
            var dogsFromDb = context.Dogs.Where(d => d.LitterId == id)
                .Include(d => d.Litter)
                .Include(d => d.Collar)
                .Include(d => d.Gender)
                .ToList();
            return View("ReadOnlyList", dogsFromDb);
        }

        [Authorize(Roles = RoleName.Breeder)]
        public ActionResult New()
        {
            var genderTypes = context.Genders.ToList();
            var collarTypes = context.Collars.ToList();
            var litterOptions = context.Litters.ToList();

            DogFormViewModel viewModel = new DogFormViewModel
            {
                Litters = litterOptions,
                Genders = genderTypes,
                Collars = collarTypes
            };

            return View("DogForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Dog dog)
        {
            if (dog.Id == 0)
            {
                context.Dogs.Add(dog);
            }
            else
            {
                Dog dogFromDb = context.Dogs.FirstOrDefault(d => d.Id == dog.Id);
                dogFromDb.LitterId = dog.LitterId;
                dogFromDb.CollarId = dog.CollarId;
                dogFromDb.GenderId = dog.GenderId;
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Litters");
        }
    }
}