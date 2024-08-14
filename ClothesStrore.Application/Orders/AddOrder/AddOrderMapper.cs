namespace ClothesStrore.Application.Orders.AddOrder
{
    internal class AddOrderMapper : Profile
    {
        public AddOrderMapper()
        {
            CreateMap<AddOrderRequest, Order>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<OrderDetails, OrderDetail>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.QuantityUnit))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
