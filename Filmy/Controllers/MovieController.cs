using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filmy.Models;
using Filmy.ViewModels;

namespace Filmy.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Movie

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("Index");
            }
            return View("ReadOnlyIndex");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var Movie = _context.Movies.SingleOrDefault(movie => movie.Id == id);
            return View(Movie);
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var GenresList = _context.Genres.ToList();

            var viewModel = new NewMovieViewModel
            {
                Movie = new Movie() {
                NumberInStock=0,
                ReleaseDate=DateTime.MinValue},
                Genres = GenresList
            };
            return View(viewModel);
        }

        [HttpPost]
       
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                   
                    Genres = _context.Genres.ToList()
                };
                return View(viewModel);
            }
            movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            
                _context.SaveChanges();
                

                return RedirectToAction("index","Movies");
            
           

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var Movie = _context.Movies.Find(id);
            var viewModel = new NewMovieViewModel()
            {
                Movie = Movie,
                Genres=_context.Genres.ToList()
            
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewMovieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new NewMovieViewModel
                {
                    Movie = viewModel.Movie,
                    Genres = _context.Genres.ToList()
                };
                return View(ViewModel);
            }
                _context.Entry(viewModel.Movie).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            

        }
    }
}