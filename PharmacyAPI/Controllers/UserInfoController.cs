using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyAPI.Controllers
{
    
    public class UserInfoController : ApiController
    {
        Pharmacy db = new Pharmacy();

        [HttpGet]
         public IQueryable Get(string login)
        {
            return db.UsersInfoes.Where(p => p.login == login);
        }

        public class UserInf
        {
            public string Login { get; set; }
            public string Number { get; set; }
            public string Mail { get; set; }
            public string Address { get; set; }
        }
        public IHttpActionResult Put([FromBody]UserInf user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UsersInfo usr = db.UsersInfoes.Find(user.Login);
            usr.mail = user.Mail;
            usr.number = user.Number;
            usr.address = user.Address;
            db.SaveChanges();
            return Ok(user);
        }

    }
}