using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EOH.DAL.Repositories;
using EOH.DAL.Interfaces;
using System.Linq;
using EOH.Domain.Model;

namespace EOH.Tests.DAL
{
    /// <summary>
    /// Summary description for RepositoryTests
    /// </summary>
    [TestClass]
    public class RepositoryTests
    {
        private IRolesRepository rolesRepository;
        private IEmployeesRepository employeesRepository;
        private IRatesRepository ratesRepository;

        [TestInitialize]
        public void Init()
        {
            rolesRepository = new RolesRepository();
            employeesRepository = new EmployeesRepository();
            ratesRepository = new RatesRepository();
        }

        [TestMethod]
        public void TestGetRates()
        {
            var GetAllRoles = ratesRepository.SelectAll();
            decimal rate = 300.00m;
            Rate role = ratesRepository.SelectRateByValue(rate);
            //setting ignore case to true
            Assert.AreEqual(rate, role.Amount);
        }

        [TestMethod]
        public void TestGetRoles()
        {
            var GetAllRoles = rolesRepository.SelectAll().ToList();
            string roleName = ".net developer";
            Role role = rolesRepository.SelectRoleByName(roleName);
            //setting ignore case to true
            Assert.AreEqual(roleName, role.Name, true);
        }

        [TestMethod]
        public void TestAddRoles()
        {
            //check role does not exists
            var role = rolesRepository.SelectRoleByName("UnitTestRole");
            Assert.AreEqual(null, role, "This UnitTestRole already exists in the role data");
            rolesRepository.Insert(new Role { Name = "UnitTestRole", Description = "UnitTestRole" });
            rolesRepository.Save();
            role = rolesRepository.SelectRoleByName("UnitTestRole");
            Assert.AreEqual("UnitTestRole", role.Name);

            //cleanup
            rolesRepository.Delete(role.RoleId);
            rolesRepository.Save();
            role = rolesRepository.SelectRoleByName("UnitTestRole");
            Assert.AreEqual(null, role, "This UnitTestRole has not been deleted as part of the cleanup for TestAddRoles");
        }

        [TestMethod]
        public void TestSaveEmployeeAndRoles()
        {
            Employee employee = new Employee();
            employee.IdNumber = "8409295";

            string roleName = "Administrator";
            Role role = employeesRepository.SelectRoleByName(roleName);
            employee.Roles.Add(role);
            employeesRepository.Insert(employee);
            employeesRepository.Save();
        }


    }
}
