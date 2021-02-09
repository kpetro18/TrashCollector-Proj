using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Employee")]

    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            if (employee == null)
            {
                return RedirectToAction("Create");
            }

            var customerList = _context.Customers.Include(c => c.Day).ToList();
            var routeZipCodeCustomers = customerList.Where(c => c.ZipCode == employee.ZipCode).ToList();
            var currentDay = DateTime.Today.DayOfWeek.ToString();
            var regularPickupCustomers = routeZipCodeCustomers.Where(c => c.Day.Name == currentDay).ToList();
            var extraCustomers = routeZipCodeCustomers.Where(c => c.ExtraPickupDay == DateTime.Today).ToList();
            var allCustomersPreSuspension = regularPickupCustomers.Concat(extraCustomers);
            var allCustomersToday = allCustomersPreSuspension.Where(c => c.SuspendPickupStart == null ? true : (c.SuspendPickupStart > DateTime.Today && c.SuspendPickupEnd < DateTime.Today)).ToList();

            return View("Index", allCustomersToday);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, Employee employee)
        {
            try
            {
                employee.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault(); 
            
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            var loggedInEmployee = _context.Employees.SingleOrDefault(e => e.EmployeeId == id);
            loggedInEmployee.FirstName = employee.FirstName;
            loggedInEmployee.LastName = employee.LastName;
            loggedInEmployee.ZipCode = employee.ZipCode;

            _context.SaveChanges();
            return View(employee);
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.EmployeeId == id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                _context.Remove(_context.Employees.SingleOrDefault(c => c.EmployeeId == id));
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
