using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Filmy.DTOs;
using Filmy.Models;
using System.Data.Entity;
using AutoMapper;
namespace Filmy.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
            _context.Configuration.ProxyCreationEnabled = false;
            _context.Configuration.LazyLoadingEnabled = false;
        }


        //API/Movies GET
        public IHttpActionResult GetMovies(string query=null)
        {
            IEnumerable<Movie> moviesQuery = _context.Movies
                .Include(m => m.Genre).
                Where(m => m.NumberAvailable > 0);
            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }
            var moviesList = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDTO>);
            return Ok(moviesList);
        }

        //API/Movies/id GET 
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        //API/Movies/ POST
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult PostCustomer(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
                _context.Movies.Add(movie);
                _context.SaveChanges();
                movie.Id = movieDTO.Id;
                return Created(new Uri(Request.RequestUri+""+movie.Id),movieDTO);

            }
            catch (Exception)
            {
                return BadRequest();
                
            }
        }   

        //API/Movies/Id Put
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public IHttpActionResult PutMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            Mapper.Map(movieDTO, movieInDb);
            try
            {
                
                _context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //API/Movies/Id Delete
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            try
            {

                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}

