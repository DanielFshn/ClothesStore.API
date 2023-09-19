
namespace ClothesStrore.Application.ProductsRating.GetProductRatings;

public class GetRatingProductMapper : Profile
{
    public GetRatingProductMapper()
    {
        CreateMap<ProductRating, GetAllProductRatingResponse>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.RatingNumber, opt => opt.MapFrom(src => src.RatingNumber))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
    }
}
