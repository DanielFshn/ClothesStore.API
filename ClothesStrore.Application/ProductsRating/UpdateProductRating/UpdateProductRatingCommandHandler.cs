using AutoMapper;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.ProductsRating.UpdateProductRating
{
    public class UpdateProductRatingCommandHandler : IRequestHandler<UpdateProductRatingCommand, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public UpdateProductRatingCommandHandler(IMapper mapper, IMyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(UpdateProductRatingCommand request, CancellationToken cancellationToken)
        {
            var productRating = await _context.ProductRatings.FirstOrDefaultAsync(x => x.ProductId == request.ProductId && x.UserId == request.updateProdutRatingDto.UserId);
            if (productRating == null)
                return JsonConvert.SerializeObject(new { Message = "Not found rating for this product!" });
            _mapper.Map(request, productRating);
            await _context.SaveToDbAsync();
            return JsonConvert.SerializeObject(new { Message = "Product Raitng is updated succesfully" });
        }
    }
}
