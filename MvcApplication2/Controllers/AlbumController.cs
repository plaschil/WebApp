using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication2.Controllers
{
    public class AlbumController : Controller
    {
        AdatBazis db = new AdatBazis();
        //
        // GET: /Album/

        public ActionResult Index()
        {
            return View(db.fenykepek);
        }

        //
        // GET: /Album/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Album/Create
        [Authorize]
        public ActionResult Create()
        {
            // A Get során ez a View töltődik be
            return View();
        }

        //
        // POST: /Album/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if(Request.Files.Count > 0)
            {
                var fajl = Request.Files[0];
                byte[] tomb = new byte[fajl.ContentLength];
                fajl.InputStream.Read(tomb, 0, fajl.ContentLength);

                Fenykep fenykep = new Fenykep();
                fenykep.Fajlnev = fajl.FileName;
                fenykep.Kep = tomb;

                var user = Membership.GetUser();
                fenykep.FelhasznaloNev = user.UserName;
                
                db.fenykepek.Add(fenykep);
                db.SaveChanges();
            }
            // A Post után ez a View töltődik be
            return View();
        }

        //
        // GET: /Album/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Album/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Album/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
