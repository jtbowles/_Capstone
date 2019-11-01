using System;
using System.Collections.Generic;
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
    public class PotentialOwnersController : Controller
    {
        private ApplicationDbContext context;

        public PotentialOwnersController()
        {
            context = new ApplicationDbContext();
        }

        //PotentialOwner
        public ActionResult New()
        {
            PotentialOwner potentialOwner = new PotentialOwner();
            return View("PotentialOwnersForm", potentialOwner);
        }

        [HttpPost]
        public ActionResult Save(PotentialOwner potentialOwner)
        {
            if (potentialOwner.Id == 0)
            {
                potentialOwner.ApplicationId = User.Identity.GetUserId();
                potentialOwner.EmailAddress = GetUserEmail();
                context.PotentialOwners.Add(potentialOwner);
            }
            else
            {
                PotentialOwner potentialOwnerFromDb = 
                    context.PotentialOwners.FirstOrDefault(p => p.Id == potentialOwner.Id);

                potentialOwnerFromDb.FirstName = potentialOwner.FirstName;
                potentialOwnerFromDb.LastName = potentialOwner.LastName;
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

        //Preferences
        [Authorize(Roles = RoleName.PotentialOwner)]
        public ActionResult NewPreferences()
        {
            var applicationId = User.Identity.GetUserId();
            PotentialOwner potentialOwnerFromDb = 
                context.PotentialOwners.FirstOrDefault(p => p.ApplicationId == applicationId);

            if (potentialOwnerFromDb.PreferenceId == null)
            {
                Preference preference = new Preference();
                return View("PreferencesForm", preference);
            }

            Preference preferenceFromDb =
                context.Preferences.FirstOrDefault(p => p.Id == potentialOwnerFromDb.PreferenceId);

            return View("PreferencesForm", preferenceFromDb);
        }

        [HttpPost]
        public ActionResult UpdatePreferences(Preference preference)
        {

            if (preference.Id == 0)
            {
                context.Preferences.Add(preference);
                context.SaveChanges();
                AssignPreferenceId();
            }
            else
            {
                Preference preferenceFromDb = context.Preferences.FirstOrDefault(p => p.Id == preference.Id);
                preferenceFromDb.IsMicro = preference.IsMicro;
                preferenceFromDb.IsMini = preference.IsMini;
                preferenceFromDb.IsMedium = preference.IsMedium;
                preferenceFromDb.IsStandard = preference.IsStandard;
                preferenceFromDb.IsCaramel = preference.IsCaramel;
                preferenceFromDb.IsRed = preference.IsRed;
                preferenceFromDb.IsBlue= preference.IsBlue;
                preferenceFromDb.IsSilver = preference.IsSilver;
                preferenceFromDb.IsCafe = preference.IsCafe;
                preferenceFromDb.IsChocolate = preference.IsChocolate;
                preferenceFromDb.IsParchment = preference.IsParchment;
                context.SaveChanges();
            }

            return RedirectToAction("GetLittersByPreference","Litters");
        }

        public void AssignPreferenceId()
        {
            var applicationId = User.Identity.GetUserId();
            PotentialOwner potentialOwnerFromDb =
                context.PotentialOwners.FirstOrDefault(p => p.ApplicationId == applicationId);
            var mostRecentEntry = context.Preferences.Max(p => p.Id);

            potentialOwnerFromDb.PreferenceId = mostRecentEntry;
            context.SaveChanges();
        }

        //ApplicationForm
        [Authorize(Roles = RoleName.PotentialOwner)]
        public ActionResult NewApplicationForm()
        {
            ApplicationForm applicationForm = new ApplicationForm();
            return View("ApplicationForm", applicationForm);
        }

        [HttpPost]
        public async Task<ActionResult> SendApplication(ApplicationForm applicationForm)
        {
            var applicationUserId = User.Identity.GetUserId();
            PotentialOwner potentialOwner =
                context.PotentialOwners.FirstOrDefault(p => p.ApplicationId == applicationUserId);
            applicationForm.PotentialOwnerId = potentialOwner.Id;

            context.ApplicationForms.Add(applicationForm);
            context.SaveChanges();
            await SendApplicationEmail(potentialOwner);
            return View("ApplicationSentConfirmation");
        }

        public async Task SendApplicationEmail(PotentialOwner potentialOwner)
        {
            var breeder = context.Breeders.FirstOrDefault();
            var client = new SendGridClient(ApiKey.ApiKey.SendGrid);
            var from = new EmailAddress(potentialOwner.EmailAddress, potentialOwner.FirstName);
            var subject = "Application Submitted";
            var to = new EmailAddress(breeder.EmailAddress, breeder.FirstName);
            var plainTextContent =  "<strong>" + potentialOwner.FirstName + Email.ApplicationMessage + "</strong>";
            var htmlContent = "<strong>" + potentialOwner.FirstName + Email.ApplicationMessage + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        //Appointment
        [Authorize(Roles = RoleName.PotentialOwner)]
        public ActionResult NewAppointment()
        {
            Appointment appointment = new Appointment();
            return View("AppointmentForm", appointment);
        }

        [HttpPost]
        public async Task<ActionResult> SaveAppointment(Appointment appointment)
        {
            var applicationUserId = User.Identity.GetUserId();
            PotentialOwner potentialOwner =
                context.PotentialOwners.FirstOrDefault(p => p.ApplicationId == applicationUserId);

            appointment.PotentialOwnerId = potentialOwner.Id;
            context.Appointments.Add(appointment);
            context.SaveChanges();
            await SendAppointmentEmail(potentialOwner);
            return View("AppointmentSentConfirmation");
        }

        public async Task SendAppointmentEmail(PotentialOwner potentialOwner)
        {
            var breeder = context.Breeders.FirstOrDefault();
            var client = new SendGridClient(ApiKey.ApiKey.SendGrid);
            var from = new EmailAddress(potentialOwner.EmailAddress, potentialOwner.FirstName);
            var subject = "Appointment Request";
            var to = new EmailAddress(breeder.EmailAddress, breeder.FirstName);
            var plainTextContent = "<strong>" + potentialOwner.FirstName + Email.AppointmentMessage + "</strong>";
            var htmlContent = "<strong>" + potentialOwner.FirstName + Email.AppointmentMessage + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }


        //WatchLitter
        public ActionResult SelectWatchLitter(int? id)
        {
            var applicationId = User.Identity.GetUserId();
            PotentialOwner potentialOwner =
                context.PotentialOwners.FirstOrDefault(p => p.ApplicationId == applicationId);
            potentialOwner.WatchedLitterId = id;
            context.SaveChanges();
            return RedirectToAction("GetLittersByPreference", "Litters");
        }
    }
}