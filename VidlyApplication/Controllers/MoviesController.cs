using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movie = new List<Movie>()
            {
                new Movie { Name = "Avengers" },
                new Movie { Name = "Rampage" },
                new Movie { Name = "Qoiet Place" },
                new Movie { Name = "Jumanji" }
            };

            var RandomViewModel = new RandomMovieViewModel()
            {
                Movie = movie,
            };

            return View(RandomViewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
    }
}