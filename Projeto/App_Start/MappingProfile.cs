using AutoMapper;
using Projeto.Dtos;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Model to Dto
            Mapper.CreateMap<PaymentMethod, PaymentMethodDto>();
            Mapper.CreateMap<ArtWork, ArtWorkDto>();


            //Dto to Model
            Mapper.CreateMap<PaymentMethodDto, PaymentMethod>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<ArtWorkDto, ArtWork>().ForMember(c => c.Id, opt => opt.Ignore()); ;
        }
    }
}