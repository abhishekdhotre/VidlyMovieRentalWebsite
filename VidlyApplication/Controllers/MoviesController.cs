using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyApplication.Models;
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
            var movies = _context.Movie.Include(m => m.Genre);
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movies = _context.Movie.Include(m => m.Genre).SingleOrDefault(s => s.Id == Id);
            if (movies != null)
                return View(movies);
            else
                return new HttpNotFoundResult();
        }

       
    }
}