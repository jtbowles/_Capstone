using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DogBreederCapstone.Models;
using DogBreederCapstone.Utilities;
using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;

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
        [Authorize(Roles = RoleName.Breeder)]
        public ActionResult GetAppointments()
        {
            var unconfirmedAppointments = context.Appointments.Where(a => a.Confirmed == false)
                .Include("PotentialOwner")
                .ToList();
            return View("UnconfirmedAppointments", unconfirmedAppointments);
        }

        [Authorize(Roles = RoleName.Breeder)]
        public async Task<ActionResult> ConfirmAppointment(Appointment appointment)
        {
            Appointment appointmentFromDb = context.Appointments.FirstOrDefault(a => a.Id == appointment.Id);
            appointmentFromDb.Confirmed = true;
            context.SaveChanges();
            await AppointmentEmail(appointment.PotentialOwnerId, "yes");
            return RedirectToAction("GetAppointments");
        }

        [Authorize(Roles = RoleName.Breeder)]
        public async Task<ActionResult> DenyAppointment(Appointment appointment)
        {
            Appointment appointmentFromDb = context.Appointments.FirstOrDefault(a => a.Id == appointment.Id);
            await AppointmentEmail(appointment.PotentialOwnerId, "no");
            context.Appointments.Remove(appointmentFromDb);
            context.SaveChanges();
            return RedirectToAction("GetAppointments");
        }

        public async Task AppointmentEmail(int? id, string confirmation)
        {
            PotentialOwner potentialOwner = context.PotentialOwners.FirstOrDefault(p => p.Id == id);
            var breeder = context.Breeders.FirstOrDefault();
            var subjectTitle = "Appointment Denied";
            var text = "<strong>" + Email.AppointmentDenied + "</strong>";

            if (confirmation == "yes")
            {
                subjectTitle = "Appointment Confirmed";
                text = "<strong>" + breeder.FirstName + Email.AppointmentConfirmed + "</strong>";
            }

            var client = new SendGridClient(ApiKey.ApiKey.SendGrid);
            var from = new EmailAddress(breeder.EmailAddress, breeder.FirstName);
            var subject = subjectTitle;
            var to = new EmailAddress(potentialOwner.EmailAddress, potentialOwner.FirstName);
            var plainTextContent = text;
            var htmlContent = text;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
