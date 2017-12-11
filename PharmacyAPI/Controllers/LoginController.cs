using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyAPI.Controllers
{
    public class LoginController : ApiController
    {
        // GET api/<controller>
        Pharmacy db = new Pharmacy();
        public class user
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(user newuser)
        {

            var result = db.Users.Where( u => u.login == newuser.Login && u.password == newuser.Password).FirstOrDefault();
            if (result != null)
            {
                return Ok();
            }
            else return null;
                  
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]user newuser)
        {
            var result = db.Users.Where(u => u.login == newuser.Login && u.password == newuser.Password).FirstOrDefault();
            if (result != null)
            {
                return Ok();
            }
            else return null;
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