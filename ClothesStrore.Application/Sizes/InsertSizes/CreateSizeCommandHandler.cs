using ClothesStore.Domain.Entities;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClothesStrore.Application.Sizes.InsertSizes
{
    public class CreateSizeCommandHandler : IRequestHandler<CreateSizeRequest, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public CreateSizeCommandHandler(IMapper mapper, IMyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(CreateSizeRequest request, CancellationToken cancellationToken)
        {
            if (await _context.Sizes.AnyAsync(c => c.Name.ToLower() == request.Name.ToLower(), cancellationToken))
            {
                throw new ConflictException("A size with the same Name already exists.");
            }
            var size = _mapper.Map<Size>(request);
            size.CreatedOn = DateTime.Now;
            _context.Sizes.Add(size);
            await _context.SaveToDbAsync();
            return JsonConvert.SerializeObject(new { Message = "Size is added succesfully" });

        }
    }
}
