using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // CreateMap<Product, ProductReturnDto>();
            CreateMap<Product, ProductReturnDto>()
                .ForMember(d => d.ProductBrand, o=> o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o=> o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o=> o.MapFrom<ProductUrlResolver>());
        }
    }
}