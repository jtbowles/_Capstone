using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DogBreederCapstone.Models;
using Microsoft.AspNet.Identity;

namespace DogBreederCapstone.Controllers
{
    public class BreedersController : Controller
    {
        private ApplicationDbContext context;

        public BreedersController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            Breeder breeder = new Breeder();
            return View("BreederForm", breeder);
        }

        public ActionResult Save(Breeder breeder)
        {
            if (breeder.Id == 0)
            {
                breeder.ApplicationId = User.Identity.GetUserId(); 
                context.Breeders.Add(breeder);
            }
            else
            {
                Breeder breederFromDb = context.Breeders.FirstOrDefault(b => b.Id == breeder.Id);
                breederFromDb.FirstName = breeder.FirstName;
                breederFromDb.LastName = breeder.LastName;
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Litters");
        }
    }
}
