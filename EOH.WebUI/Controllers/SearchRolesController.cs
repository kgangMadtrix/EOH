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
    public class SearchRolesController:  Controller
    {
        private IRolesRepository rolesRepository;
        private IRatesRepository ratesRepository;
        public SearchRolesController()
        {
            rolesRepository = new RolesRepository();
            ratesRepository = new RatesRepository();
        }

        // GET: /ManageRole/
        [AuthorizeAttribute(Roles = "Sales")]
        public ActionResult Index(string Search_Data)
        {
            var roles = new List<Role>();
            if (string.IsNullOrEmpty(Search_Data))
            {
                roles = rolesRepository.GetRolesAndRates();
                return View(roles);
            }
            else
            {
                roles = rolesRepository.GetSearchedRolesAndRates(Search_Data);
                return View(roles);
            }
        }

        // GET: /ManageRole/Details/5
        [AuthorizeAttribute(Roles = "Sales")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = rolesRepository.SelectByIDWithEmployees((int)id);
            //if (role == null)
            //{
            //    return HttpNotFound();
            //}
            ViewBag.EmployeeId = new MultiSelectList(role.Employees, "EmployeeId", "FullName");

            return View(role);
        }

       

    }
}