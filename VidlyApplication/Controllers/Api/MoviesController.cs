using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using VidlyApplication.App_Start;
using VidlyApplication.Dtos;
using VidlyApplication.Models;

namespace VidlyApplication.Controllers.Api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/movie 
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movie
                .Include(m => m.Genre)
                .ToList()
                .Select(MappingProfile.MovieToMovieDtoMapper.Map<Movie, MovieDto>);
        }

        //GET api/movie/1
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movie
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return NotFound();

            return Ok(MappingProfile.MovieToMovieDtoMapper.Map<Movie, MovieDto>(movie));
        }

        //POST api/movie
        [HttpPost]
        [Authorize(Roles = RoleNames.CanManagerMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            movieDto.DateAdded = DateTime.Now;
            var movie = MappingProfile.MovieDtoToMovieMapper.Map<MovieDto, Movie>(movieDto);
            _context.Movie.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(Request.RequestUri + "/" + movieDto.Id, movieDto);
        }

        //PUT api/movie/1
        [HttpPut]
        [Authorize(Roles = RoleNames.CanManagerMovies)]
        public void UpdateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDB = _context.Movie.SingleOrDefault(m => m.Id == movieDto.Id);
            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            MappingProfile.MovieDtoToMovieMapper.Map(movieDto, movieInDB);

            _context.SaveChanges();
        }

        //DELETE api/movie/1
        [HttpDelete]
        [Authorize(Roles = RoleNames.CanManagerMovies)]
        public void DeleteMovie(int Id)
        {
            var movie = _context.Movie.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movie.Remove(movie);
            _context.SaveChanges();
        }
    }
}
