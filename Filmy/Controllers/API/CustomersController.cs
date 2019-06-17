using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Filmy.DTOs;
using Filmy.Models;
using System.Data.Entity;   
using AutoMapper;

namespace Filmy.Controllers.API
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            _context.Configuration.ProxyCreationEnabled = false;
            _context.Configuration.LazyLoadingEnabled = false;
        }



        public IHttpActionResult GetCustomers(string query = null )
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);
            if (!String.IsNullOrWhiteSpace(query))
            
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            

             var customersList=customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(customersList);
        }

        public IHttpActionResult GetCustomer(int id )
        {
            var customer= _context.Customers.SingleOrDefault(M=>M.Id==id);

            if (customer == null)
                return BadRequest();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));

        }

        [HttpPost]
        public IHttpActionResult PostCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            
                var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                customerDTO.Id = customer.Id;
                return Created(new Uri(Request.RequestUri + "" + customer.Id), customerDTO);

            }
            catch (Exception)
            {

                return BadRequest();
            }
            
            
           
        }


        [HttpPut]
        public IHttpActionResult PutCustomer(int id , CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            try
            {
                Mapper.Map(customerDTO, customerInDb);
                _context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }

        

    }
}
