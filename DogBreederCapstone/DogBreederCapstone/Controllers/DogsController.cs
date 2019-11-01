using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DogBreederCapstone.Models;
using DogBreederCapstone.Utilities;
using DogBreederCapstone.ViewModels;
using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;

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
                .Include(d => d.Image)
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
                .Include(d => d.Image)
                .ToList();
            return View("ReadOnlyList", dogsFromDb);
        }

        [Authorize(Roles = RoleName.Breeder)]
        public ActionResult New()
        {
            var genderTypes = context.Genders.ToList();
            var collarTypes = context.Collars.ToList();
            var litterOptions = context.Litters.ToList();
            var imageOptions = context.Images.ToList();

            DogFormViewModel viewModel = new DogFormViewModel
            {
                Litters = litterOptions,
                Genders = genderTypes,
                Collars = collarTypes,
                Images = imageOptions
            };

            return View("DogForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Breeder)]
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
                dogFromDb.ImageId = dog.ImageId;
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Litters");
        }

        public ActionResult Details(int? id)
        {
            Dog dogFromDb = context.Dogs
                .Include(d => d.Litter)
                .Include(d => d.Collar)
                .Include(d => d.Gender)
                .Include(d => d.Image)
                .FirstOrDefault(d => d.Id == id);

            return View(dogFromDb);
        }

        [Authorize(Roles = RoleName.PotentialOwner)]
        public async Task<ActionResult> Reserve(int? id)
        {
            var applicationId = User.Identity.GetUserId();
            PotentialOwner potentialOwner =
                context.PotentialOwners.FirstOrDefault(p => p.ApplicationId == applicationId);

            ApplicationForm form =
                context.ApplicationForms.FirstOrDefault(f => f.PotentialOwnerId == potentialOwner.Id);

            if (form == null || form.Confirmed == false)
            {
                return View("NotApproved");
            }

            Dog dog = context.Dogs.FirstOrDefault(d => d.Id == id);
            dog.isReserved = true;
            dog.PotentialOwnerId = potentialOwner.Id;

            context.SaveChanges();
            await SendReserveSpotEmail(potentialOwner);
            return View("SpotReserved");
        }

        public async Task SendReserveSpotEmail(PotentialOwner potentialOwner)
        {
            var breeder = context.Breeders.FirstOrDefault();
            var client = new SendGridClient(ApiKey.ApiKey.SendGrid);
            var from = new EmailAddress(potentialOwner.EmailAddress, potentialOwner.FirstName);
            var subject = "Spot Reserved";
            var to = new EmailAddress(breeder.EmailAddress, breeder.FirstName);
            var plainTextContent = "<strong>" + potentialOwner.FirstName + Email.SpotReserved + "</strong>";
            var htmlContent = "<strong>" + potentialOwner.FirstName + Email.SpotReserved + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}