using DogBreederCapstone.Models;
using DogBreederCapstone.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index()
        {
            //var litters = context.Litters.Include("Coat").Include("Size").ToList();
            return View();
        }

        // GET: Litters/Details/5
        public ActionResult Details(int id)
        {
            return View();
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


        // GET: Litters/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Litters/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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
    }
}
