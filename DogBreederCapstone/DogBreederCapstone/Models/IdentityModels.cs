﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DogBreederCapstone.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool FirstTimeLogin { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Breeder> Breeders { get; set; }
        public DbSet<PotentialOwner> PotentialOwners { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Litter> Litters { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Coat> Coats { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Collar> Collars { get; set; }
        public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<ForumMessage> ForumMessages { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}