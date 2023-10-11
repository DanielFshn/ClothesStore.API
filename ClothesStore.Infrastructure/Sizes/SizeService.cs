using AutoMapper;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.Sizes;
using ClothesStrore.Application.Sizes.DeleteSize;
using ClothesStrore.Application.Sizes.GetSizeById;
using ClothesStrore.Application.Sizes.GetSizes;
using ClothesStrore.Application.Sizes.InsertSizes;
using ClothesStrore.Application.Sizes.UpdateSize;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ClothesStore.Domain.Entities;
namespace ClothesStore.Infrastructure.Sizes;

internal class SizeService : ISizeService
{
    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }

    public SizeService(IMapper mapper, IMyDbContext context) =>
        (_mapper, _context) = (mapper, context);
    

    public async Task<string> CreateAsync(CreateSizeRequest request, CancellationToken cancellationToken)
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

    public async Task<string> DeleteAsync(DeleteSizeRequest request, CancellationToken cancellationToken)
    {
        var gender = await _context.Sizes.FindAsync(request.Id);
        if (gender == null)
            throw new NotFoundException("Size not found.");
        _mapper.Map(request, gender);
        await _context.SaveToDbAsync();
        return JsonConvert.SerializeObject(new { Message = "Size is deleted succesfully" });
    }

    public async Task<List<GetAllSizesResponse>> GetAsync(GetAllSizesRequest request, CancellationToken cancellationToken)
    {
        var sizes = await _context.Sizes.Where(x => x.DeletedOn == null).ToListAsync();
        var response = _mapper.Map<List<GetAllSizesResponse>>(sizes);
        return response;
    }

    public async Task<GetSizeByIdResponse> GetByIdAsync(GetSizeByIdRequest request, CancellationToken cancellationToken)
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

    public async Task<string> UpdateAsync(UpdateSizeCommand request, CancellationToken cancellationToken)
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
