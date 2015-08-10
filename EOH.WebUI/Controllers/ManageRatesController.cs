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
    public class ManageRatesController : Controller
    {
        private IRatesRepository ratesRepository;

        public ManageRatesController()
        {
            ratesRepository = new RatesRepository();
        }

        // GET: /ManageRates/
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(ratesRepository.SelectAll().ToList());
        }

        // GET: /ManageRates/Details/5
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = ratesRepository.SelectByID((int)id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // GET: /ManageRates/Create
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ManageRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Create([Bind(Include="RateId,Amount")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                ratesRepository.Insert(rate);
                ratesRepository.Save();
                return RedirectToAction("Index");
            }

            return View(rate);
        }

        // GET: /ManageRates/Edit/5
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = ratesRepository.SelectByID((int)id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // POST: /ManageRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Edit([Bind(Include="RateId,Amount")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                ratesRepository.Update(rate);
                ratesRepository.Save();
                return RedirectToAction("Index");
            }
            return View(rate);
        }

        // GET: /ManageRates/Delete/5
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = ratesRepository.SelectByID((int)id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // POST: /ManageRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ratesRepository.Delete(id);
            ratesRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
