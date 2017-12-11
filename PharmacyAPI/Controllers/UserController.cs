using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyAPI.Controllers
{
    public class UserController : ApiController
    {
        Pharmacy db = new Pharmacy();
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public class user
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
        // GET api/<controller>/5
        //public IQueryable<User> Get(user newuser)
        //{
        //    return db.Users.Where(p => p.login == newuser.Login).Where(p => p.password == newuser.Password);
        //}

        public class AddUser
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string Patronomyc { get; set; }
            public string Address { get; set; }
            public string BornDate { get; set; }
            public string Number { get; set; }
            public string Mail { get; set; }
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody]AddUser user)
        {
           
            User us = new User
            {
                login = user.Login,
                password = user.Password
            };
            db.Users.Add(us);
            UsersInfo usf = new UsersInfo
            {
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                login = user.Login,
                address = user.Address,
                BornDate = Convert.ToDateTime(user.BornDate),
                mail = user.Mail,
                number = user.Number,
                Patronomyc = user.Patronomyc
            };
            db.UsersInfoes.Add(usf);
            db.SaveChanges();
            return Ok();
        }
        
        // PUT api/<controller>/5
        //public IQueryable Put(string login,string password, [FromBody]User value)
        //{

        //}

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}