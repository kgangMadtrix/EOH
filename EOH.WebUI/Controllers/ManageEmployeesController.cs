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
    public class ManageEmployeesController : Controller
    {
        private IRolesRepository rolesRepository;
        private IEmployeesRepository employeesRepository;

        public ManageEmployeesController()
        {
            rolesRepository = new RolesRepository();
            employeesRepository = new EmployeesRepository();
        }

        // GET: /ManageEmployees/
        [AuthorizeAttribute(Roles="Admin")]
        public ActionResult Index()
        {
            return View(employeesRepository.SelectAll().ToList());
        }

        // GET: /ManageEmployees/Details/5
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeesRepository.SelectByID((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolesId = new MultiSelectList(employee.Roles, "RoleId", "Name");
            return View(employee);
        }

        // GET: /ManageEmployees/Create
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.RolesId = new SelectList(rolesRepository.SelectAll(), "RoleId", "Name");
            return View();
        }

        // POST: /ManageEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Create([Bind(Include="EmployeeId,IdNumber,Name,Surname")] Employee employee, int?[] RolesId)
        {
            if (ModelState.IsValid)
            {
                if (RolesId != null)
                {
                    foreach (var roleId in RolesId)
                    {
                        Role role = employeesRepository.SelectRoleById((int)roleId);
                        employee.Roles.Add(role);
                    }
                }

                employeesRepository.Insert(employee);
                employeesRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.RolesId = new MultiSelectList(employee.Roles, "RoleId", "Name");
            return View(employee);
        }

        // GET: /ManageEmployees/Edit/5
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeesRepository.SelectByID((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.RolesId = new MultiSelectList(rolesRepository.SelectAll(), "RoleId", "Name", employee.Roles.Select(a => a.RoleId));
            return View(employee);
        }

        // POST: /ManageEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "EmployeeId,IdNumber,Name,Surname")] Employee employee, int?[] RolesId)
        {
            if (ModelState.IsValid)
            {
                employee.Roles.Clear();
                if (RolesId != null)
                {
                    foreach (var roleId in RolesId)
                    {
                        Role role = employeesRepository.SelectRoleById((int)roleId);
                        employee.Roles.Add(role);
                    }
                }
                employeesRepository.Update(employee);
                employeesRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.RolesId = new MultiSelectList(employee.Roles, "RoleId", "Name");
            return View(employee);
        }

        // GET: /ManageEmployees/Delete/5
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeesRepository.SelectByID((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /ManageEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            employeesRepository.Delete(id);
            employeesRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
