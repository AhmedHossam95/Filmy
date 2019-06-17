using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filmy.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult Create()
        {
            return View();
        }
    }
}