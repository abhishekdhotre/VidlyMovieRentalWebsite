using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyApplication.App_Start;
using VidlyApplication.Dtos;
using VidlyApplication.Models;

namespace VidlyApplication.Controllers.Api
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customer
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customerQuery = _context.Customer.Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customerQuery = customerQuery.Where(c => c.Name.Contains(query));

            var CustomerDto = customerQuery
                .ToList()
                .Select(MappingProfile.CustomerToCustomerDtoMapper.Map<Customer, CustomerDto>);

            return Ok(CustomerDto);
        }

        //GET api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customer
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(MappingProfile.CustomerToCustomerDtoMapper.Map<Customer, CustomerDto>(customer));
        }

        //POST api/customers
        [HttpPost]
        [Authorize(Roles = RoleNames.CanManagerCustomers)]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = MappingProfile.CustomerDtoToCustomerMapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customer.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(Request.RequestUri + "/" + customer.Id, customerDto);
        }

        //PUT api/customers/1
        [HttpPut]
        [Authorize(Roles = RoleNames.CanManagerCustomers)]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            MappingProfile.CustomerDtoToCustomerMapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }

        //DELETE api/customers/1
        [HttpDelete]
        [Authorize(Roles = RoleNames.CanManagerCustomers)]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customer.Remove(customer);
            _context.SaveChanges();
        }
    }
}
