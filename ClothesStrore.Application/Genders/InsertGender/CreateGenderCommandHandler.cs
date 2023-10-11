
using ClothesStrore.Application.Genders;

namespace ClothesStrore.Application.Gender.InsertGender
{
    public class CreateGenderCommandHandler : IRequestHandler<CreateGenderRequest, string>
    {
        private IGenderService _service { get; }

        public CreateGenderCommandHandler(IGenderService service) =>
            _service = service;
      

        public async Task<string> Handle(CreateGenderRequest request, CancellationToken cancellationToken) =>
            await _service.CreateAsync(request, cancellationToken);
    }
}
