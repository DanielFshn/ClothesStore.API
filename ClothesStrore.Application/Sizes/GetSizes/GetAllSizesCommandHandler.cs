using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Sizes.GetSizes
{
    public class GetAllSizesCommandHandler : IRequestHandler<GetAllSizesRequest, List<GetAllSizesResponse>>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public GetAllSizesCommandHandler(IMapper mapper, IMyDbContext cotnext)
        {
            _mapper = mapper;
            _context = cotnext;
        }

        public async Task<List<GetAllSizesResponse>> Handle(GetAllSizesRequest request, CancellationToken cancellationToken)
        {
            var sizes = await _context.Sizes.Where(x => x.DeletedOn == null).ToListAsync();
            var response = _mapper.Map<List<GetAllSizesResponse>>(sizes);
            return response;
        }
    }
}
