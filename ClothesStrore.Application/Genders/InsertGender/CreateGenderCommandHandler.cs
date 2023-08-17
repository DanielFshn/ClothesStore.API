using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClothesStrore.Application.Gender.InsertGender
{
    public class CreateGenderCommandHandler : IRequestHandler<CreateGenderRequest, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public CreateGenderCommandHandler(IMapper mapper, IMyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(CreateGenderRequest request, CancellationToken cancellationToken)
        {

            if (await _context.Genders.AnyAsync(c => c.GenderName.ToLower() == request.Name.ToLower(), cancellationToken))
            {
                throw new ConflictException("A gender with the same Name already exists.");
            }
            var gender = _mapper.Map<ClothesStore.Domain.Entities.Gender>(request);
            gender.CreatedOn = DateTime.Now;
            _context.Genders.Add(gender);
            await _context.SaveToDbAsync();
            return JsonConvert.SerializeObject(new { Message = "Gender is added succesfully" });

        }
    }
}
