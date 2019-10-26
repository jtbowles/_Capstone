using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using DogBreederCapstone.Dtos;
using DogBreederCapstone.Models;

namespace DogBreederCapstone.Controllers.Api
{
    public class DogsController : ApiController
    {
        private ApplicationDbContext context;

        public DogsController()
        {
            context = new ApplicationDbContext();
        }

        // GET api/litters
        public IHttpActionResult GetDogs()
        {
            var dogsFromDb = context.Dogs
                .Include(d => d.Collar)
                .Include(d => d.Gender)
                .Include(d => d.Litter).ToList();

            return Ok(dogsFromDb);
        }
    }
}