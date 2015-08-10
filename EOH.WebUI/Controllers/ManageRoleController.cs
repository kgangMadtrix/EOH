using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EOH.Domain.Model;
using EOH.DAL;
using EOH.DAL.Interfaces;
using EOH.DAL.Repositories;

namespace EOH.WebUI.Controllers
{
    public class ManageRoleController : Controller
    {
        private IRolesRepository rolesRepository;
        private IRatesRepository ratesRepository;
        public ManageRoleController()
        {
            rolesRepository = new RolesRepository();
            ratesRepository = new RatesRepository();
        }

        // GET: /ManageRole/
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Index()
        {
            var roles = rolesRepository.GetRolesAndRates();
            return View(roles);
        }

        // GET: /ManageRole/Details/5
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = rolesRepository.SelectByID((int)id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: /ManageRole/Create
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.RateId = new SelectList(ratesRepository.SelectAll(), "RateId", "Amount");
            return View();
        }

        // POST: /ManageRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Create([Bind(Include="RoleId,Name,Description,RateId")] Role role)
        {
            if (ModelState.IsValid)
            {
                rolesRepository.Insert(role);
                rolesRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.RateId = new SelectList(ratesRepository.SelectAll(), "RateId", "RateId", role.RateId);
            return View(role);
        }

        // GET: /ManageRole/Edit/5
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = rolesRepository.SelectByID((int)id);
            if (role == null)
            {
                return HttpNotFound();
            }
            ViewBag.RateId = new SelectList(ratesRepository.SelectAll(), "RateId", "Amount", role.RateId);
            return View(role);
        }

        // POST: /ManageRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Edit([Bind(Include="RoleId,Name,Description,RateId")] Role role)
        {
            if (ModelState.IsValid)
            {
                rolesRepository.Update(role);
                rolesRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.RateId = new SelectList(ratesRepository.SelectAll(), "RateId", "RateId", role.RateId);
            return View(role);
        }

        // GET: /ManageRole/Delete/5
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = rolesRepository.SelectByID((int)id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: /ManageRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = rolesRepository.SelectByID(id);
            rolesRepository.Delete(role.RoleId);
            rolesRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
