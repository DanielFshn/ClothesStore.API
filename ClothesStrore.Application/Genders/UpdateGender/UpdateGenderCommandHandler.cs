using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Genders.UpdateGender;

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
        var isTaken = await _context.Genders.AnyAsync(x => x.GenderName == request.UpdateRequest.Name);
        if (isTaken)
            throw new DuplicateEntryException("This gender name is already exist!");
        var existingGender = await _context.Genders.FindAsync(request.Id);
        if (existingGender == null)
            throw new NotFoundException("Gender not found.");
        _mapper.Map(request, existingGender);
        await _context.SaveToDbAsync();
        return JsonConvert.SerializeObject(new { Message = "Gender is updated succesfully" });
    }
}
