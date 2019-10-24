using AutoMapper;
using DogBreederCapstone.Dtos;
using DogBreederCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DogBreederCapstone.Controllers.Api
{
    public class LittersController : ApiController
    {
        private ApplicationDbContext context;

        public LittersController()
        {
            context = new ApplicationDbContext();
        }

        // GET api/litters
        public IHttpActionResult GetLitters()
        {
            //var littersFromDb = context.Litters.Include("Size").Include("Coat").ToList();
            //return littersFromDb;
            return Ok(context.Litters.ToList().Select(Mapper.Map<Litter, LitterDto>));
        }

        // GET api/litters/5
        public IHttpActionResult GetLitter(int id)
        {
            var litter = context.Litters.FirstOrDefault(l => l.Id == id);

            if (litter == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Litter, LitterDto>(litter));
        }

        // POST api/litters
        [HttpPost]
        public IHttpActionResult CreateLitter(LitterDto litterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var litter = Mapper.Map<LitterDto, Litter>(litterDto);
            context.Litters.Add(litter);
            context.SaveChanges();

            litterDto.Id = litter.Id;

            return Created(new Uri(Request.RequestUri + "/" + litter.Id), litterDto);
        }

        // PUT api/litters/5
        [HttpPut]
        public IHttpActionResult UpdateLitter(int id, LitterDto litterDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var litterFromDb = context.Litters.FirstOrDefault(l => l.Id == id);

            if (litterFromDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(litterDto, litterFromDb);

            context.SaveChanges();
            return Ok();
        }

        // DELETE api/litters/5
        [HttpDelete]
        public IHttpActionResult DeleteLitter(int id)
        {
            var litterFromDb = context.Litters.FirstOrDefault(l => l.Id == id);

            if (litterFromDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            context.Litters.Remove(litterFromDb);
            context.SaveChanges();
            return Ok();
        }
    }
}