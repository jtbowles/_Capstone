using AutoMapper;
using DogBreederCapstone.Dtos;
using DogBreederCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogBreederCapstone.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Litter, LitterDto>();
            Mapper.CreateMap<LitterDto, Litter> ();
        }
    }
}