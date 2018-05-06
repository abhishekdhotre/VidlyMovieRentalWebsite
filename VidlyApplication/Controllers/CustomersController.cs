using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> ListCustomers;
        // GET: Customers
        public ActionResult Index()
        {
            ListCustomers = new List<Customer>()
            {
                new Customer { Id=1, Name="Abhishek" },
                new Customer { Id=2, Name="Tushar" },
                new Customer { Id=3, Name="Ritesh" }
               
            };

            Session["List"] = ListCustomers;
            var CustomerListViewModel = new CustomerListViewModel { customers = ListCustomers };

            return View(CustomerListViewModel);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            ListCustomers = (List<Customer>)Session["List"];
            try
            {
                Customer singleCustomer = ListCustomers.Find(x => x.Id == id);
                if (singleCustomer != null)
                    return View(singleCustomer);
                else
                    return new HttpNotFoundResult();
            }
            catch (ArgumentNullException)
            {
                return new HttpNotFoundResult();
            }         
        }
    }
}