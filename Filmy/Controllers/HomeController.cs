using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filmy.Models;
using Filmy.ViewModels;

namespace Filmy.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
            _context.Configuration.LazyLoadingEnabled = false;
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");

            return View("ReadOnlyIndex");
        }
    }
}