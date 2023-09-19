using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Sizes.GetSizeById;

public class GetSizeByIdCommandHandler : IRequestHandler<GetSizeByIdRequest, GetSizeByIdResponse>
{
    public IMyDbContext _context { get; }
    public GetSizeByIdCommandHandler(IMyDbContext context)
    {
        _context = context;
    }


    public async Task<GetSizeByIdResponse> Handle(GetSizeByIdRequest request, CancellationToken cancellationToken)
    {
        var size = await _context.Sizes
       .Where(g => g.DeletedOn == null && g.Id == request.Id)
       .FirstOrDefaultAsync(); if (size == null)
            throw new NotFoundException("Size not found!");
        var sizeDTO = new GetSizeByIdResponse()
        {
            Name = size.Name,
        };
        return sizeDTO;
    }
}
