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
        public IEnumerable<Litter> GetLitters()
        {
            //var littersFromDb = context.Litters.Include("Size").Include("Coat").ToList();
            //return littersFromDb;
            return context.Litters.ToList();
        }

        // GET api/litters/5
        public Litter GetLitter(int id)
        {
            var litter = context.Litters.FirstOrDefault(l => l.Id == id);

            if (litter == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return litter;
        }

        // POST api/litters
        [HttpPost]
        public Litter CreateLitter(Litter litter)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            context.Litters.Add(litter);
            context.SaveChanges();

            return litter;
        }

        // PUT api/litters/5
        [HttpPut]
        public void UpdateLitter(int id, Litter litter)
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

            litterFromDb.Name = litter.Name;
            litterFromDb.CoatId = litter.CoatId;
            litterFromDb.SizeId = litter.SizeId;
            litterFromDb.DueDate = litter.DueDate;
            litterFromDb.SendHomeDate = litter.SendHomeDate;

            context.SaveChanges();

        }

        // DELETE api/litters/5
        [HttpDelete]
        public void Delete(int id)
        {
            var litterFromDb = context.Litters.FirstOrDefault(l => l.Id == id);

            if (litterFromDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            context.Litters.Remove(litterFromDb);
            context.SaveChanges();
        }
    }
}