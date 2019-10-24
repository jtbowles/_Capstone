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
        public IEnumerable<Litter> Get()
        {
            var littersFromDb = context.Litters.Include("Size").Include("Coat").ToList();
            return littersFromDb;
        }

        // GET api/litters/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}