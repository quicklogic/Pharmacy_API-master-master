using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyAPI.Controllers
{
    public class OrderController : ApiController
    {
        Pharmacy db = new Pharmacy();
        // GET api/<controller>
        public IEnumerable<Order> Get(string login)
        {
            return db.Orders.Where(c => c.Login == login).ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        public class Orders
        {

            public int DeliveryMethod { get; set; }
            public int PaymentMethod { get; set; }
            public string Comment { get; set; }
            public string Login { get; set; }
            public decimal Price { get; set; }

        }
        
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Orders order)
        {
            Order orders = new Order
            {
                Login = order.Login,
                Delivery =order.DeliveryMethod,
                Payment = order.PaymentMethod,
                Price = order.Price,
                Commentary = order.Comment,
                Status = 1,               
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Orders.Add(orders);
            db.SaveChanges();
            return Ok(orders);
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