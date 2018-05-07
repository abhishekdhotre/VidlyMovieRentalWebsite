using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using VidlyApplication.Models;
using VidlyApplication.ViewModels;

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
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customer.Include(c => c.MembershipType);
            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes;
            var NewCustomerViewModel = new CustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", NewCustomerViewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
            {
                _context.Customer.Add(customer);
            }
            else
            {
                var CustomerToEdit = _context.Customer.Single(c => c.Id == customer.Id);
                CustomerToEdit.Name = customer.Name;
                CustomerToEdit.MembershipTypeId = customer.MembershipTypeId;
                CustomerToEdit.isSubscribedToNewsletter = customer.isSubscribedToNewsletter;
                CustomerToEdit.BirthDate = customer.BirthDate;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            var NewCustomerViewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm", NewCustomerViewModel);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return new HttpNotFoundResult();
            else
                return View(customer);
            
        }
    }
}