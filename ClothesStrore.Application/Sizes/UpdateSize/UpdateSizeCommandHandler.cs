using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClothesStrore.Application.Sizes.UpdateSize
{
    public class UpdateSizeCommandHandler : IRequestHandler<UpdateSizeCommand, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public UpdateSizeCommandHandler(IMapper mapper, IMyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<string> Handle(UpdateSizeCommand request, CancellationToken cancellationToken)
        {
            var isTaken = await _context.Sizes.AnyAsync(x => x.Name == request.UpdateRequest.Name);
            if (isTaken)
                throw new DuplicateEntryException("This product name is already exist!");
            var existingSize = await _context.Sizes.FindAsync(request.Id);
            if (existingSize == null)
                throw new NotFoundException("Size not found.");
            _mapper.Map(request, existingSize);
            await _context.SaveToDbAsync();
            return JsonConvert.SerializeObject(new { Message = "Size is updated succesfully" });

        }
    }
}
