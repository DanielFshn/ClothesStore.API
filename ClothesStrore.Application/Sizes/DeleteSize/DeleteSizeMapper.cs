using ClothesStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.Sizes.DeleteSize
{
    public class DeleteSizeMapper : Profile
    {
        public DeleteSizeMapper()
        {
            CreateMap<DeleteSizeRequest, Size>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DeletedOn, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
