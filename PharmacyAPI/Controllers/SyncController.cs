using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PharmacyAPI.Controllers
{
    public class SyncController: ApiController
    {
        Pharmacy db = new Pharmacy();
        [HttpGet]
        public int Get()
        {
            return db.Products.Count();
        }

    }
}