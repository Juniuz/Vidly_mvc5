using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var cust = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (cust == null)
                return BadRequest();

            return Ok(Mapper.Map<Customer, CustomerDto>(cust));
        }

        // POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto custDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cust = Mapper.Map<CustomerDto, Customer>(custDto);
            _context.Customers.Add(cust);
            _context.SaveChanges();

            custDto.Id = cust.Id;

            return Created(new Uri(Request.RequestUri + "/" + cust.Id), custDto);
        }

        // PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto custDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var custInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (custInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(custDto, custInDb);

            _context.SaveChanges();
        }

        // DELETE api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var custInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (custInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(custInDb);
            _context.SaveChanges();
        }
    }
}
