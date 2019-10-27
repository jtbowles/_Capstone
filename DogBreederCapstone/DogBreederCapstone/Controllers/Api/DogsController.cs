using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        // GET api/dogs
        public IHttpActionResult GetDogs()
        {
            var dogsFromDb = context.Dogs
                .Include(d => d.Collar)
                .Include(d => d.Gender)
                .Include(d => d.Litter)
                .ToList()
                .Select(Mapper.Map<Dog, DogDto>);

            return Ok(dogsFromDb);
        }

        // GET api/dogs/5
        public IHttpActionResult GetDog(int id)
        {
            var dogFromDb = context.Dogs.FirstOrDefault(d => d.Id == id);

            if (dogFromDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Dog, DogDto>(dogFromDb));
        }

        // POST api/dogs
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateDog(DogDto dogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var dog = Mapper.Map<DogDto, Dog>(dogDto);
            context.Dogs.Add(dog);
            context.SaveChanges();

            dogDto.Id = dog.Id;

            return Created(new Uri(Request.RequestUri + "/" + dog.Id), dogDto);
        }

        // PUT api/dogs/5
        public IHttpActionResult UpdateDog(int id, DogDto dogDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var dogFromDb = context.Dogs.FirstOrDefault(d => d.Id == id);

            if (dogFromDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(dogDto, dogFromDb);

            context.SaveChanges();
            return Ok();
        }

        // DELETE api/dogs/5
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteDog(int id)
        {
            var dogFromDb = context.Dogs.FirstOrDefault(d => d.Id == id);

            if (dogFromDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            context.Dogs.Remove(dogFromDb);
            context.SaveChanges();
            return Ok();
        }
    }
}