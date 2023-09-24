
namespace ClothesStrore.Application.ProductsRating.UpdateProductRating;

public class UpdateProductRatingMapper : Profile
{
    public UpdateProductRatingMapper()
    {
        CreateMap<UpdateProductRatingCommand, ProductRating>()
           .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
           .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.updateProdutRatingDto.UserId))
            .ForMember(dest => dest.RatingNumber, opt => opt.MapFrom(src => src.updateProdutRatingDto.RatingNumber))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.updateProdutRatingDto.Title))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.updateProdutRatingDto.Comments));
    }
}
