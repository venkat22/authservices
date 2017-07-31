using SampleMvcApplication.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace SampleMvcApplication.Controllers
{
    [ClaimsAuthorizeAttribute("Lastname","Yerrapothu")]

    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            var context = new HttpContextWrapper(HttpContext.Current);
            HttpRequestBase request = context.Request;
            var identity = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;
            return new string[] { request.Cookies.Get(0).Name, request.Cookies.Get(0).Value, request.Cookies.Get(1).Name, request.Cookies.Get(1).Value };
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