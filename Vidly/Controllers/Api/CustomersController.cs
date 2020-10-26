using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Routing;
using Vidly.DTOs;
using Vidly.Models;
using AutoMapper;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //GET list of customers /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customers.Include(m=>m.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);


            return Ok(customers);
        }

        public IHttpActionResult GetCustomersFiltered(string query)
        {
            var customers = _context.Customers.Include(m => m.MembershipType).Where(m=>m.Name.Contains(query)).ToList().Select(Mapper.Map<Customer, CustomerDto>);


            return Ok(customers);
        }

        //GET a single Customer /api/customers/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }


        //[HttpGet]
        //public IHttpActionResult GetCustomer(string name)
        //{
        //    var customer = _context.Customers.Where(c=> c.Name.StartsWith(name)).ToList();

        //    if (customer == null)
        //        return NotFound();

        //    return Ok(Mapper.Map<Customer, CustomerDto>(customer.First()));
        //}

        //POST New Customer /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri+"/"+customerDto.Id),customerDto);
        }

        //PUT Modifying customer /api/customers/1
        [HttpPut]
        public void EditCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var customerInDb = _context.Customers.Single(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            throw new HttpResponseException(HttpStatusCode.OK);

        }

        //[Authorize]
        [HttpDelete]
        public IHttpActionResult DeleteCostumer(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok();
        }



    }
}
