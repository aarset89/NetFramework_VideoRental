using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace App_Start
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>()
                /*.ForMember(c => c.Id, opt => opt.Ignore())*/;
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());


            Mapper.CreateMap<Movie, MovieDto>()
                /*.ForMember(m=>m.Id, opt=>opt.Ignore())*/;
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDTO>()
                .ReverseMap();

            Mapper.CreateMap<Genre, GenreDTO>()
                .ReverseMap();

            Mapper.CreateMap<Rental, NewRentalDTO>()
                .ReverseMap();

        }
    }
}