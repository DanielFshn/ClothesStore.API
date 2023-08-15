using ClothesStrore.Application.Context;
using ClothesStrore.Application.Gender.GetGenders;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Genders.GetGenders
{
    public class GetAllGendersCommandHandler : IRequestHandler<GetAllGendersRequest, List<GetAllGenderResponse>>
    {
        private IMapper _mapper { get; }
        private IMyDbContext _context { get; }

        public GetAllGendersCommandHandler(IMapper mapper, IMyDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllGenderResponse>> Handle(GetAllGendersRequest request, CancellationToken cancellationToken)
        {
            var genders = await _context.Genders.ToListAsync(cancellationToken);
            var response = _mapper.Map<List<GetAllGenderResponse>>(genders);
            return response;
        }
    }
}
