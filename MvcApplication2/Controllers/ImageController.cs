using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class ImageController : Controller
    {
        AdatBazis db = new AdatBazis();
        //
        // GET: /Image/
        
        public ActionResult Get(int id)
        {
            var fenykep = db.fenykepek.SingleOrDefault(x => x.FenykepID == id);
            return File(fenykep.Kep, "img/jpeg");
        }

    }
}
