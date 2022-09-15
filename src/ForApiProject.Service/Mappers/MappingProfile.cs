using AutoMapper;
using ForApiProject.Domain.Entities.Products;
using ForApiProject.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductForCreationDto, Product>().ReverseMap();  
            CreateMap<Category, CategoryForCreationDto>().ReverseMap();
        }
    }
}
