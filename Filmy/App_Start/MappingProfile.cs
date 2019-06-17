using AutoMapper;
using Filmy.DTOs;
using Filmy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmy.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
            
        }


    } 
}