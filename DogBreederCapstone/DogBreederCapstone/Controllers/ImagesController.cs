using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DogBreederCapstone.Models;
using DogBreederCapstone.Utilities;

namespace DogBreederCapstone.Controllers
{
    [Authorize(Roles = RoleName.Breeder)]
    public class ImagesController : Controller
    {
        private ApplicationDbContext context;

        public ImagesController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Add()
        {
            Image image = new Image();

            return View(image);
        }

        [HttpPost]
        public ActionResult Add(Image image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yy-MM-dd") + extension;
            image.ImagePath = "~/DogImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/DogImages/"), fileName);
            image.ImageFile.SaveAs(fileName);
            context.Images.Add(image);
            context.SaveChanges();
            ModelState.Clear();

            return View();
        }
    }
}