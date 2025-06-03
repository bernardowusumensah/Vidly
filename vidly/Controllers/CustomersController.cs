using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        // instantiating my dbcontext class for database queries
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
        // This is the route for the Customers Index view
        // The first method of the CustomersController class
        [Route("customers/index")]
        public ActionResult Index()
        {
            return View();
        }

        // This is the route for the Customers Details view
        // The second method of the CustomersController class
        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            // Fetching the customer from the database using the id
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            // If the customer is not found, return a NotFound view
            if (customer == null)
                return HttpNotFound();
            // Return the Details view with the customer data
            return View(customer);
        }

        // This is the route for the Customers New view
        //[Route("customers/new")]
        //public ActionResult New()
        //{
        //    // Fetching the membership types from the database to populate a dropdown in the view
        //    var membershipTypes = _context.MembershipTypes.ToList();
        //    // Creating a new customer object to pass to the view
        //   // var customer = new Customer();
        //    // Passing the customer and membership types to the view using ViewBag
        //    ViewBag.MembershipTypes = membershipTypes;
        //   // return View(customer);
        //}
    }
}

