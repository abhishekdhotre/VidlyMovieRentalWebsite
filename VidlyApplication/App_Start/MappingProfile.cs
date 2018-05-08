using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyApplication.Dtos;
using VidlyApplication.Models;

namespace VidlyApplication.App_Start
{
    public class MappingProfile : Profile
    {
        public static IMapper CustomerToCustomerDtoMapper;
        public static IMapper CustomerDtoToCustomerMapper;
        public static IMapper MovieToMovieDtoMapper;
        public static IMapper MovieDtoToMovieMapper;

        public MappingProfile()
        {
            var configCustToDto = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDto>();
            });

            var configDtoToCust = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDto, Customer>();
            });

            var configMovieToDto = new MapperConfiguration(cfg => {
                cfg.CreateMap<Movie, MovieDto>();
            });

            var configDtoToMovie = new MapperConfiguration(cfg => {
                cfg.CreateMap<MovieDto, Movie>();
            });

            CustomerToCustomerDtoMapper = configCustToDto.CreateMapper();
            CustomerDtoToCustomerMapper = configDtoToCust.CreateMapper();
            MovieToMovieDtoMapper = configMovieToDto.CreateMapper();
            MovieDtoToMovieMapper = configDtoToMovie.CreateMapper();

        }
    }
}