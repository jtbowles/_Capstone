using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DogBreederCapstone.Models;
using DogBreederCapstone.Utilities;
using Microsoft.AspNet.Identity;

namespace DogBreederCapstone.Controllers
{
    public class ForumMessagesController : Controller
    {
        private ApplicationDbContext context;

        public ForumMessagesController()
        {
            context = new ApplicationDbContext();
        }

        [Authorize(Roles = RoleName.BreederOrPotentialOwner)]
        public ActionResult Add()
        {
            ForumMessage message = new ForumMessage();
            return View(message);
        }

        [HttpPost]
        public ActionResult Add(ForumMessage message)
        {
            string fileName = Path.GetFileNameWithoutExtension(message.ImageFile.FileName);
            string extension = Path.GetExtension(message.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yy-MM-dd") + extension;
            message.ImagePath = "~/ForumImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/ForumImages/"), fileName);
            message.ImageFile.SaveAs(fileName);
            context.ForumMessages.Add(message);
            context.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("GetForumPosts");
        }

        [HttpGet]
        [Authorize(Roles = RoleName.BreederOrPotentialOwner)]
        public ActionResult GetForumPosts()
        {
            if (User.IsInRole(RoleName.PotentialOwner))
            {
                var applicationId = User.Identity.GetUserId();
                PotentialOwner potentialOwner =
                    context.PotentialOwners.FirstOrDefault(p => p.ApplicationId == applicationId);

                if (!potentialOwner.IsOwner)
                {
                    return View("NonOwner");
                }
            }

            var gallery = context.ForumMessages.ToList();
            return View("Gallery", gallery);
        }
    }
}