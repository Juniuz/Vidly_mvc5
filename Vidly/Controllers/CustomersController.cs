﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var cstmr = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(cstmr);
        }

        public ActionResult Details(int id)
        {
            var cust = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (cust == null)
                return HttpNotFound();

            return View(cust);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var custInDb = _context.Customers.Single(c => c.Id == customer.Id);

                custInDb.Name = customer.Name;
                custInDb.BirthDate = customer.BirthDate;
                custInDb.MembershipTypeId = customer.MembershipTypeId;
                custInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var cust = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (cust == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = cust,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}