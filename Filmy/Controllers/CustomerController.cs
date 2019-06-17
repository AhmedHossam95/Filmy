using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filmy.Models;
using Filmy.ViewModels;

namespace Filmy.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Customer

        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var Customer = _context.Customers.SingleOrDefault(customer => customer.Id == id);
            return View(Customer);
        }
        public ActionResult Create()
        {
            var MembershipTypesList = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer= new Customer(),
                MembershipTypes = MembershipTypesList
            };
            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("Create", viewModel);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            
            return RedirectToAction("Index","Customer");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            
                return HttpNotFound();
            

            var Customer = _context.Customers.SingleOrDefault(m=>m.Id==id);
            if (Customer == null)
            
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = Customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };


            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult Edit(NewCustomerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new NewCustomerViewModel
                {
                    Customer=viewModel.Customer,
                    MembershipTypes=_context.MembershipTypes
                };
                return View("Edit", ViewModel);
            }

           
                _context.Entry(viewModel.Customer).State = System.Data.Entity.EntityState.Modified;

                _context.SaveChanges();
                return RedirectToAction("Index");
            
           
            
            
        }
    }
}