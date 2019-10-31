using DogBreederCapstone.Models;
using DogBreederCapstone.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DogBreederCapstone.Utilities;
using Microsoft.AspNet.Identity;

namespace DogBreederCapstone.Controllers
{
    public class LittersController : Controller
    {
        private ApplicationDbContext context;

        public LittersController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Litters
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Breeder))
            {
                return View("List");
            }

            return View("ReadOnlyList");
        }

        // GET: Litters/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Litter litter = context.Litters
                .Include("Coat")
                .Include("Size")
                .FirstOrDefault(l => l.Id == id);

            if (litter == null)
            {
                return HttpNotFound();
            }

            return View(litter);
        }

        // GET: Litters/DetailsViewModel
        [Authorize(Roles = RoleName.PotentialOwner)]
        public ActionResult GetDogsFromLitter(int? id)
        {
            var dogsFromDb = context.Dogs.Where(d => d.LitterId == id)
                .Include(d => d.Collar)
                .Include(d => d.Gender)
                .Include(d => d.Litter)
                .Include(d => d.Image);

            var unreservedDogs = dogsFromDb.Where(d => d.isReserved == false).ToList();

            Litter litter = context.Litters.Include(l => l.Coat)
                .Include(l => l.Size)
                .FirstOrDefault(l => l.Id == id);

            var applicationId = User.Identity.GetUserId();
            PotentialOwner potentialOwner =
                context.PotentialOwners.FirstOrDefault(p => p.ApplicationId == applicationId);

            LitterViewModel viewModel = new LitterViewModel
            {
                Litter = litter,
                Dogs = unreservedDogs,
                PotentialOwner = potentialOwner
            };

            return View("ReservationList", viewModel);
        }

        // GET: Litters/Edit/5
        public ActionResult Edit(int id)
        {
            Litter litter = context.Litters.FirstOrDefault(l => l.Id == id);

            if (litter == null)
            {
                return HttpNotFound();
            }

            LitterFormViewModel viewModel = new LitterFormViewModel
            {
                Litter = litter,
                Sizes = context.Sizes.ToList(),
                Coats = context.Coats.ToList()
            };
            return View("LitterForm", viewModel);
        }


        [Authorize(Roles = RoleName.Breeder)]
        public ActionResult New()
        {
            var coatTypes = context.Coats.ToList();
            var sizeTypes = context.Sizes.ToList();

            LitterFormViewModel viewModel = new LitterFormViewModel
            {
                Coats = coatTypes,
                Sizes = sizeTypes
            };

            return View("LitterForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Litter litter)
        {
            if (litter.Id == 0)
            {
                context.Litters.Add(litter);
            }
            else
            {
                Litter litterFromDb = context.Litters.Single(l => l.Id == litter.Id);
                litterFromDb.Name = litter.Name;
                litterFromDb.CoatId = litter.CoatId;
                litterFromDb.SizeId = litter.SizeId;

                if (litter.DueDate.Year != 1)
                {
                    litterFromDb.DueDate = litter.DueDate;
                }
                if (litter.SendHomeDate.Year != 1)
                {
                    litterFromDb.SendHomeDate = litter.SendHomeDate;
                }
            }

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [Authorize(Roles = RoleName.PotentialOwner)]
        public ActionResult GetLittersByPreference()
        {
            var applicationId = User.Identity.GetUserId();
            PotentialOwner potentialOwner = context.PotentialOwners.FirstOrDefault(e => e.ApplicationId == applicationId);
            Preference preferences = context.Preferences.FirstOrDefault(p => p.Id == potentialOwner.PreferenceId);

            if (preferences == null)
            {
                return RedirectToAction("NewPreferences", "PotentialOwners");
            }

            List<Litter> litters = FilterLitterPreferences(preferences);

            return View("ListByPreference", litters);
        }

        public List<Litter> FilterLitterPreferences(Preference preferences)
        {
            List<Litter> littersByPreference = new List<Litter>();

            if (preferences.IsMicro)
            {
                littersByPreference = LitterBySize(littersByPreference, 1);
            }
            if (preferences.IsMini)
            {
                littersByPreference = LitterBySize(littersByPreference, 2);
            }
            if (preferences.IsMedium)
            {
                littersByPreference = LitterBySize(littersByPreference, 3);
            }
            if (preferences.IsStandard)
            {
                littersByPreference = LitterBySize(littersByPreference, 4);
            }
            if (preferences.IsCaramel)
            {
                littersByPreference = LitterByCoat(littersByPreference, 1);
            }
            if (preferences.IsRed)
            {
                littersByPreference = LitterByCoat(littersByPreference, 2);
            }
            if (preferences.IsBlue)
            {
                littersByPreference = LitterByCoat(littersByPreference, 3);
            }
            if (preferences.IsSilver)
            {
                littersByPreference = LitterByCoat(littersByPreference, 4);
            }
            if (preferences.IsChocolate)
            {
                littersByPreference = LitterByCoat(littersByPreference, 5);
            }
            if (preferences.IsCafe)
            {
                littersByPreference = LitterByCoat(littersByPreference, 6);
            }
            if (preferences.IsLavender)
            {
                littersByPreference = LitterByCoat(littersByPreference, 7);
            }
            if (preferences.IsParchment)
            {
                littersByPreference = LitterByCoat(littersByPreference, 8);
            }

            return littersByPreference;
        }

        public List<Litter> LitterByCoat(List<Litter> litters, int id)
        {
            List<Litter> filteredLitters = context.Litters.Where(l => l.CoatId == id)
                .Include(l => l.Coat)
                .Include(l => l.Size)
                .ToList();

            try
            {
                foreach (var litter in filteredLitters)
                {
                    litters.Add(litter);
                }

                return litters;

            }
            catch
            {
                return litters;
            }

        }

        public List<Litter> LitterBySize(List<Litter> litters, int id)
        {
            List<Litter> filteredLitters = context.Litters.Where(l => l.SizeId == id)
                .Include(l => l.Coat)
                .Include(l => l.Size)
                .ToList();

            try
            {
                foreach (var litter in filteredLitters)
                {
                    litters.Add(litter);
                }

                return litters;

            }
            catch 
            {
                return litters;
            }
        }
    }
}
