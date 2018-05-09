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
                cfg.CreateMap<Customer, CustomerDto>().ForMember(c => c.MembershipTypeDto, opt => opt.MapFrom("MembershipType")); 
            });

            var configDtoToCust = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDto, Customer>();
            });

            var configMovieToDto = new MapperConfiguration(cfg => {
                cfg.CreateMap<Movie, MovieDto>().ForMember(m => m.Genre, g => g.MapFrom("Genre"));
            });

            var configDtoToMovie = new MapperConfiguration(cfg => {
                cfg.CreateMap<MovieDto, Movie>();
            });

            var configDtoToMembershipType = new MapperConfiguration(cfg => {
                cfg.CreateMap<MembershipType, MembershipTypeDto>();
            });

            

            CustomerToCustomerDtoMapper = configCustToDto.CreateMapper();
            CustomerDtoToCustomerMapper = configDtoToCust.CreateMapper();
            MovieToMovieDtoMapper = configMovieToDto.CreateMapper();
            MovieDtoToMovieMapper = configDtoToMovie.CreateMapper();

        }
    }
}