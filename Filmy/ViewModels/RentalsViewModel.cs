using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Filmy.Models;
namespace Filmy.ViewModels
{
    public class RentalsViewModel
    {
        public Customer Customer{ get; set; }
        public Rental Rental { get; set; }
        public Movie Movie { get; set; }

    }
}