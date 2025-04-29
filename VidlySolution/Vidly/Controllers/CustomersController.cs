using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
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
            var customerList = GetCustomers();
            return View(customerList);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            List<Customer> customerList = new List<Customer>(){
            new Customer { Name = "John Smith", Id = 1},
            new Customer { Name = "Mary Williams", Id = 2}
            };
            if (id > 2 || id<=0)
            {
                return HttpNotFound();
            }
           
            return View(customerList[id-1]);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            { new Customer { Name = "John Smith", Id = 1},
            new Customer { Name = "Mary Williams", Id = 2}
            };
        }
        }
}