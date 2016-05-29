﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
    }
}