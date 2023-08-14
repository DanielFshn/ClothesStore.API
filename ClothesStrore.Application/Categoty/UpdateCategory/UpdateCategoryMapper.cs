using ClothesStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.Categoty.UpdateCategory
{
    public class UpdateCategoryMapper : Profile
    {
        public UpdateCategoryMapper()
        {
            CreateMap<UpdateCategoryCommand, Category>()
            .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId))
            .ForPath(dest => dest.UpdatedOn, opt => opt.MapFrom(src => DateTime.Now))
            .ForPath(dest => dest.CategoryName, opt => opt.MapFrom(src => src.UpdateData.Name));
        }
    }
}
