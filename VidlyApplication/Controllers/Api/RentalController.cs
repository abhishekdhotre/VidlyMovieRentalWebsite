using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using VidlyApplication.Dtos;
using VidlyApplication.Models;

namespace VidlyApplication.Controllers.Api
{
    public class RentalController : ApiController
    {
        ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult NewRentals(RentalDto rentalDto)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == rentalDto.CustomerId);

            var movies = _context.Movie.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach(var movie in movies)
            {
                if (movie.StockAvailabilty == 0)
                    return BadRequest("Movie is out of stock");

                movie.StockAvailabilty --;

                var rental = new Rental()
                {
                    Customer = customer,
                    CustomerId = customer.Id,
                    Movie = movie,
                    MovieId = movie.Id,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
