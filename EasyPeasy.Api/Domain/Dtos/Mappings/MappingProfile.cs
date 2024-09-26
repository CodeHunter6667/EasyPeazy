using System;
using AutoMapper;
using EasyPeasy.Api.Domain.Dtos.Category;
using EasyPeasy.Api.Domain.Dtos.FinancialMovement;

namespace EasyPeasy.Api.Domain.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDTO, Domain.Category>().ReverseMap();
            CreateMap<FinancialMovementDTO, Domain.FinancialMovement>().ReverseMap();
        }
    }
}

