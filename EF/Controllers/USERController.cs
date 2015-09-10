using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class USERController : Controller
    {
        private ToDoListEntities db = new ToDoListEntities();

        //
        // GET: /USER/

        public ActionResult Index()
        {
            return View(db.USERS.ToList());
        }

        //
        // GET: /USER/Details/5

        public ActionResult Details(short id = 0)
        {
            USER user = db.USERS.Find(Convert.ToInt32(id));
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /USER/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /USER/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(USER user)
        {
            if (ModelState.IsValid)
            {
                db.USERS.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /USER/Edit/5

        public ActionResult Edit(short id = 0)
        {
            USER user = db.USERS.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /USER/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(USER user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /USER/Delete/5

        public ActionResult Delete(short id = 0)
        {
            USER user = db.USERS.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /USER/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            USER user = db.USERS.Find(id);
            db.USERS.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}