using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyApplication.Models;
using VidlyApplication.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            //var movies = _context.Movie.Include(m => m.Genre);
            //return View(movies);
            if(User.IsInRole("CanAccessMovies"))
                return View();
            return View("ReadOnlyView");
        }

        [Authorize(Roles = RoleNames.CanManagerMovies)]
        public ActionResult New()
        {
            var MovieViewModel = new MovieViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", MovieViewModel);
        }

        //public ActionResult Details(int Id)
        //{
        //    var movies = _context.Movie.Include(m => m.Genre).SingleOrDefault(s => s.Id == Id);
        //    if (movies != null)
        //        return View(movies);
        //    else
        //        return new HttpNotFoundResult();
        //}

        [Authorize(Roles = RoleNames.CanManagerMovies)]
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movie.Single(m => m.Id == Id);
            var MovieViewModel = new MovieViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", MovieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManagerMovies)]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var MovieViewModel = new MovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", MovieViewModel);
            }
            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movie.Add(movie);
            }
            else
            {
                var MovieToEdit = _context.Movie.Single(m => m.Id == movie.Id);
                MovieToEdit.Name = movie.Name;
                MovieToEdit.ReleaseDate = movie.ReleaseDate;
                MovieToEdit.GenreId = movie.GenreId;
                MovieToEdit.Stock = movie.Stock;
                MovieToEdit.DateAdded = DateTime.Now;         
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

       
    }
}