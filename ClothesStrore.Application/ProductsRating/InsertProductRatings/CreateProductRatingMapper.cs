namespace ClothesStrore.Application.ProductsRating.InsertProductRatings
{
    public class CreateProductRatingMapper : Profile
    {
        public CreateProductRatingMapper()
        {
            CreateMap<CreateProductRatingRequest, ProductRating>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
