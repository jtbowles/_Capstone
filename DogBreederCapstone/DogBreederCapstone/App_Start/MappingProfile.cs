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
            //Domain to Dto
            Mapper.CreateMap<Litter, LitterDto>();
            Mapper.CreateMap<Coat, CoatDto> ();
            Mapper.CreateMap<Size, SizeDto> ();
            Mapper.CreateMap<Dog, DogDto> ();
            Mapper.CreateMap<Gender, GenderDto> ();
            Mapper.CreateMap<Collar, CollarDto> ();

            //Dto to domain
            Mapper.CreateMap<LitterDto, Litter>();
            //.ForMember(l => l.Id, opt => opt.Ignore());

            Mapper.CreateMap<DogDto, Dog>();

        }
    }
}