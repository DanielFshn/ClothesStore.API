using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Genders.GetById;

public class GetGenderByIdCommandHandler : IRequestHandler<GetGenderByIdRequest, GetGenderByIdResponse>
{
    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }
    public GetGenderByIdCommandHandler(IMapper maspper, IMyDbContext cotntext)
    {
        _mapper = maspper;
        _context = cotntext;
    }

    public async Task<GetGenderByIdResponse> Handle(GetGenderByIdRequest request, CancellationToken cancellationToken)
    {
        //var size = await _context.Genders.AsNoTracking().Where(g => g.DeletedOn != null).FirstOrDefaultAsync(x => x.Id == request.Id);
        var gender = await _context.Genders
            .Where(g => g.DeletedOn == null && g.Id == request.Id)
            .FirstOrDefaultAsync(); if (gender == null)
            throw new NotFoundException("Gender not found!");
        var genderDTO = _mapper.Map<GetGenderByIdResponse>(gender);
        return genderDTO;
    }
}
