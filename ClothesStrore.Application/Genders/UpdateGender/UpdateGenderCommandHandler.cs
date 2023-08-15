using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;

namespace ClothesStrore.Application.Genders.UpdateGender
{
    public class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }

        public UpdateGenderCommandHandler(IMapper mapper, IMyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
        {
            var existingGender = await _context.Genders.FindAsync(request.Id);
            if (existingGender == null)
                throw new NotFoundException("Gender not found.");
            _mapper.Map(request, existingGender);
            await _context.SaveToDbAsync();
            return "{\"Message\":\"Gender is updated succesfully\"}";
        }
    }
}
