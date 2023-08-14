using ClothesStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.Categoty.GetCategories
{
    public class GetAllCategoriesMapper : Profile
    {
        public GetAllCategoriesMapper()
        {
            CreateMap<Category, GetAllCategoriesResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName))
;
        }
    }
}
