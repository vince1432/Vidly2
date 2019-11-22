using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //model to modeldto
            Mapper.CreateMap<Customer, CustomersDto>();
            Mapper.CreateMap<Movie, MoviesDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();


            //modeldto  to model 
            Mapper.CreateMap<CustomersDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MoviesDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());

           
        }
    }
}