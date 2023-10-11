using ClothesStrore.Application.Context;
using ClothesStrore.Application.Gender.GetGenders;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Genders.GetGenders
{
    public class GetAllGendersCommandHandler : IRequestHandler<GetAllGendersRequest, List<GetAllGenderResponse>>
    {
        private readonly IGenderService _service;

        public GetAllGendersCommandHandler(IGenderService service) =>
                        _service = service;
        public async Task<List<GetAllGenderResponse>> Handle(GetAllGendersRequest request, CancellationToken cancellationToken) =>
            await _service.GetGendersAsync(request, cancellationToken);

    }
}
