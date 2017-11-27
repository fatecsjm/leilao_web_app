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
            Mapper.CreateMap<Auction, AuctionDto>();
            Mapper.CreateMap<Finality, FinalityDto>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<AuctionState, AuctionStateDto>();
            Mapper.CreateMap<Bid, BidDto>();


            //Dto to Model
            Mapper.CreateMap<PaymentMethodDto, PaymentMethod>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<ArtWorkDto, ArtWork>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<AuctionDto, Auction>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<FinalityDto, Finality>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CategoryDto, Category>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<AuctionStateDto, AuctionState>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<BidDto, Bid>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}