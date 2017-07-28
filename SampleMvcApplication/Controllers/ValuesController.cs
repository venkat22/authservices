using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SampleMvcApplication.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {

            var identity = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;
            return new string[] { identity.Claims.First().Issuer, identity.Claims.FirstOrDefault(c => c.Type == "Lastname").Value };
        }

        // GET api/<controller>/5
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