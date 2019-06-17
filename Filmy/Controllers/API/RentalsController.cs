using Filmy.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Filmy.Models;
using System.Data.Entity;

namespace Filmy.Controllers.API
{
    public class RentalsController : ApiController
    {
       private ApplicationDbContext _context;
        

        public RentalsController()
        {
            _context = new ApplicationDbContext();
            _context.Configuration.ProxyCreationEnabled = false;
            _context.Configuration.LazyLoadingEnabled = false;
        }
        
        [HttpGet]
        public IHttpActionResult GetRentals()
        {
            var result = _context.Rentals.Include(r => r.Customer).Include(r => r.Movie).ToList();
            return Ok(result);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var rentalInDb = _context.Rentals.Single(r => r.Id == id);
            if (rentalInDb == null)
                return NotFound();
            _context.Rentals.Remove(rentalInDb);
            _context.SaveChanges();
            return Ok();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDTO rental)
        {
            if (rental.MovieIds.Count==0)
            {
                return BadRequest("No Movies are selected");
            }
            var customer = _context.Customers.SingleOrDefault(c => c.Id == rental.CustomerId);

            if (customer==null)
            {
                return BadRequest("Customer Id is invalid");
            }

            
            var movies = _context.Movies.Where(M => rental.MovieIds.Contains(M.Id)).ToList();

            if (movies.Count!=rental.MovieIds.Count)
            {
                return BadRequest("One Or More Movie Ids are invalid");

            }  
            
            
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("This Movie'" + movie.Name + "'Isn't available");
                }
                movie.NumberAvailable--;

                var newRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                    
                };

                _context.Rentals.Add(newRental);

            }
            _context.SaveChanges();
            return Ok();
        }
    }
}