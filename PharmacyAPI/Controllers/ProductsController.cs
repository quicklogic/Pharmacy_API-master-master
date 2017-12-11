using PharmacyAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmacyAPI.Controllers
{
    public class ProductsController : ApiController
    {
        Pharmacy db = new Pharmacy();

        public IEnumerable<object> Get()
        { 

            var result = from Product in db.Products.ToList()
                         join Category in db.Categories on Product.CategoryID equals Category.ID
                         join Type in db.Types on Product.TypeID equals Type.ID
                         join Producer in db.Producers on Product.ProducerID equals Producer.ID
                         join Availability in db.Availabilities on Product.AvailabilityID equals Availability.ID
                         select new
                         {
                             ID = Product.ID,
                             Name = Product.Name,
                             ProducerID = Producer.Name,
                             Description = Product.Description,
                             Price = Product.Price,
                             Availability = Availability.Name,
                             Amount = Product.Amount,
                             Type = Type.Name,
                             Category = Category.Name,
                             Discount = Product.Discount,
                             ImageURI = Product.ImageURI
                         };
                         
            return result;
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public IHttpActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Products.Add(product);
            db.SaveChanges();
            return Ok(product);
        }

        public IHttpActionResult Put([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(product);
        }

        public IHttpActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return Ok(product);
            }
            return NotFound();
        }
    }
}