using ClothesStore.Domain.Entities;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.Genders.DeleteGender
{
    public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderRequest, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }

        public DeleteGenderCommandHandler(IMapper mapper, IMyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(DeleteGenderRequest request, CancellationToken cancellationToken)
        {
            var gender = await _context.Genders.FindAsync(request.GednerId);
            if (gender == null)
                throw new NotFoundException("Category not found.");
            _mapper.Map(request, gender);
            await _context.SaveToDbAsync();
            return "{\"Message\":\"Gender is deleted succesfully\"}";
        }
    }
}
