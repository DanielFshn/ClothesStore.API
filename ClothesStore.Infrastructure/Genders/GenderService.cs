using AutoMapper;
using ClothesStore.Domain.Entities;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.Gender.GetGenders;
using ClothesStrore.Application.Gender.InsertGender;
using ClothesStrore.Application.Genders;
using ClothesStrore.Application.Genders.DeleteGender;
using ClothesStrore.Application.Genders.GetById;
using ClothesStrore.Application.Genders.UpdateGender;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClothesStore.Infrastructure.Genders
{
    internal class GenderService : IGenderService
    {
        public IMyDbContext _context { get; }
        public IMapper _mapper { get; }
        public GenderService(IMyDbContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);


        public async Task<string> CreateAsync(CreateGenderRequest request, CancellationToken cancellationToken)
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

        public async Task<string> DeleteGenderAsync(DeleteGenderRequest request, CancellationToken cancellationToken)
        {
            var gender = await _context.Genders.FindAsync(request.GednerId);
            if (gender == null)
                throw new NotFoundException("Gender not found.");
            _mapper.Map(request, gender);
            gender.DeletedOn = DateTime.Now;
            await _context.SaveToDbAsync();
            return JsonConvert.SerializeObject(new { Message = "Gender is deleted succesfully" });
        }

        public async Task<GetGenderByIdResponse> GetByIdAsync(GetGenderByIdRequest request, CancellationToken cancellationToken)
        {
            var gender = await _context.Genders
                .Where(g => g.DeletedOn == null && g.Id == request.Id)
                .FirstOrDefaultAsync(); if (gender == null)
                throw new NotFoundException("Gender not found!");
            var genderDTO = _mapper.Map<GetGenderByIdResponse>(gender);
            return genderDTO;
        }

        public async Task<List<GetAllGenderResponse>> GetGendersAsync(GetAllGendersRequest request, CancellationToken cancellationToken)
        {
            var genders = await _context.Genders.Where(x => x.DeletedOn == null).ToListAsync(cancellationToken);
            var response = _mapper.Map<List<GetAllGenderResponse>>(genders);
            return response;
        }

        public async Task<string> UpateAsync(UpdateGenderCommand request, CancellationToken cancellationToken)
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
}
