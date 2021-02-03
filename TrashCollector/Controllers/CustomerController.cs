using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Customer")]

    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (customer == null)
            {
                return RedirectToAction("Create");  
            }

            return View("Details", customer);  
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).SingleOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            //maybe create a Days model
            var days = _context.Days.ToList();
            Customer customer = new Customer()
            {
                Days = new SelectList(days, "Id", "Name")
            };
            return View(customer);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.Days = new SelectList(_context.Days.ToList(), "Id", "Name");
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            var loggedInCustomer = _context.Customers.SingleOrDefault(m => m.CustomerId == id);
            loggedInCustomer.FirstName = customer.FirstName;
            loggedInCustomer.LastName = customer.LastName;
            loggedInCustomer.Address = customer.Address;
            loggedInCustomer.ZipCode = customer.ZipCode;
            loggedInCustomer.DayId = customer.DayId;
            loggedInCustomer.Days = new SelectList(_context.Days.ToList(), "Id", "Name");
            loggedInCustomer.ExtraPickupDay = customer.ExtraPickupDay;
            loggedInCustomer.SuspendPickupStart = customer.SuspendPickupStart;
            loggedInCustomer.SuspendPickupEnd = customer.SuspendPickupEnd;

            _context.SaveChanges();
            return RedirectToAction("Details", customer);
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                //var deletedCustomer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
                _context.Remove(_context.Customers.SingleOrDefault(c => c.CustomerId == id));
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
