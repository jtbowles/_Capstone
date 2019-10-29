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

        //Breeder
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
                breeder.EmailAddress = GetUserEmail();
                context.Breeders.Add(breeder);
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Litters");
        }

        private string GetUserEmail()
        {
            var applicationId = User.Identity.GetUserId();
            var applicationUser = context.Users.FirstOrDefault(u => u.Id == applicationId);
            var email = applicationUser.Email;

            return email;
        }

        //Application
        //public ActionResult GetAppointments()
        //{

        //}

    }
}
