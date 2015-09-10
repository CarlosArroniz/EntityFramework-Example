using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class TASKController : Controller
    {
        private ToDoListEntities db = new ToDoListEntities();

        //
        // GET: /TASK/

        public ActionResult Index()
        {
            var tasks = db.TASKS.Include(t => t.USER1);
            return View(tasks.ToList());
        }

        //
        // GET: /TASK/Details/5

        public ActionResult Details(short id = 0)
        {
            TASK task = db.TASKS.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        //
        // GET: /TASK/Create

        public ActionResult Create()
        {
            ViewBag.USER = new SelectList(db.USERS, "ID_USER", "NAME");
            return View();
        }

        //
        // POST: /TASK/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TASK task)
        {
            if (ModelState.IsValid)
            {
                db.TASKS.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USER = new SelectList(db.USERS, "ID_USER", "NAME", task.USER);
            return View(task);
        }

        //
        // GET: /TASK/Edit/5

        public ActionResult Edit(short id = 0)
        {
            TASK task = db.TASKS.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.USER = new SelectList(db.USERS, "ID_USER", "NAME", task.USER);
            return View(task);
        }

        //
        // POST: /TASK/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TASK task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USER = new SelectList(db.USERS, "ID_USER", "NAME", task.USER);
            return View(task);
        }

        //
        // GET: /TASK/Delete/5

        public ActionResult Delete(short id = 0)
        {
            TASK task = db.TASKS.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        //
        // POST: /TASK/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            TASK task = db.TASKS.Find(id);
            db.TASKS.Remove(task);
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