using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.Sizes.DeleteSize
{
    public class DeleteSizeCommandHandler : IRequestHandler<DeleteSizeRequest, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }

        public DeleteSizeCommandHandler(IMapper mapper, IMyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<string> Handle(DeleteSizeRequest request, CancellationToken cancellationToken)
        {
            var gender = await _context.Sizes.FindAsync(request.Id);
            if (gender == null)
                throw new NotFoundException("Size not found.");
            _mapper.Map(request, gender);
            await _context.SaveToDbAsync();
            return "{\"Message\":\"Size is deleted succesfully\"}";
        }
    }
}
