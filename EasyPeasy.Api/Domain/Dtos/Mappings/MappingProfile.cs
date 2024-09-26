using System;
using AutoMapper;

namespace EasyPeasy.Api.Domain.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<FinancialMovementDTO, FinancialMovement>().ReverseMap();
        }
    }
}

