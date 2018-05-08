using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            return _context.Movie.ToList().Select(MappingProfile.MovieToMovieDtoMapper.Map<Movie, MovieDto>);
        }

        //GET api/movie/1
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movie.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return NotFound();

            return Ok(MappingProfile.MovieToMovieDtoMapper.Map<Movie, MovieDto>(movie));
        }

        //POST api/movie
        [HttpPost]
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
