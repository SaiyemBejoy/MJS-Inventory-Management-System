﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_System;

namespace Inventory_Management_System.Controllers
{
    public class usersController : Controller
    {
        private inventoryDBEntities db = new inventoryDBEntities();

        // GET: users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.role);

            if (Session["role"] == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else if (Session["role"].ToString() == "admin")
            {
                return View(users.ToList());
            }

            return RedirectToAction("Index", "Auth");
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Active", Value = "1" });
            list.Add(new SelectListItem() { Text = "Inactive", Value = "0" });
            ViewBag.abc = new SelectList(list, "Value", "Text");

            ViewBag.u_roleID = new SelectList(db.roles, "r_id", "r_name");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "u_id,u_name,u_username,u_password,u_phone,u_email,u_status,u_roleID")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.u_roleID = new SelectList(db.roles, "r_id", "r_name", user.u_roleID);
            return View(user);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Active", Value = "1" });
            list.Add(new SelectListItem() { Text = "Inactive", Value = "0" });
            ViewBag.abc = new SelectList(list, "Value", "Text");

            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.u_roleID = new SelectList(db.roles, "r_id", "r_name", user.u_roleID);
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "u_id,u_name,u_username,u_password,u_phone,u_email,u_status,u_roleID")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.u_roleID = new SelectList(db.roles, "r_id", "r_name", user.u_roleID);
            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
