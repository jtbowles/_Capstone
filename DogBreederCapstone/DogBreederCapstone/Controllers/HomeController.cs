﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DogBreederCapstone.Models;
using DogBreederCapstone.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DogBreederCapstone.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext context;

        public HomeController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var currentUser = userManager.FindById(User.Identity.GetUserId());

                if (!currentUser.FirstTimeLogin && User.IsInRole(RoleName.Breeder))
                {
                    currentUser.FirstTimeLogin = true;
                    context.SaveChanges();
                    return RedirectToAction("New", "Breeders");
                }
                else if(!currentUser.FirstTimeLogin && User.IsInRole(RoleName.PotentialOwner))
                {
                    currentUser.FirstTimeLogin = true;
                    context.SaveChanges();
                    return RedirectToAction("New", "PotentialOwners");
                }
                else
                {
                    return RedirectToAction("Index","Litters");
                }

            }
            catch
            {
                return RedirectToAction("Login","Account");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdoptionDetails()
        {
            return View();
        }

        public ActionResult BreedDetails()
        {
            return View();
        }

        public ActionResult Playground()
        {
            return View();
        }
    }
}