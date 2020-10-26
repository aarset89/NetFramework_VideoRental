using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        //DataBase call
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipType = _context.membershipTypes.OrderBy(m => m.DiscountRate).ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.membershipTypes.OrderBy(m=>m.DiscountRate).ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save (Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.membershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            else
            {

                if (customer.Id == 0)
                    _context.Customers.Add(customer);
                else
                {
                    var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                    customerInDb.Name = customer.Name;
                    customerInDb.Birthdate = customer.Birthdate;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    customerInDb.IsSubscribeToNewsletter = customer.IsSubscribeToNewsletter;
                }

                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
        }

        

        //returned views
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "John Smith" },
        //        new Customer { Id = 2, Name = "Mary Williams" }
        //    };
        //}
    }
}