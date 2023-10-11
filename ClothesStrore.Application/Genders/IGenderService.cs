using ClothesStrore.Application.Gender.GetGenders;
using ClothesStrore.Application.Gender.InsertGender;
using ClothesStrore.Application.Genders.DeleteGender;
using ClothesStrore.Application.Genders.GetById;
using ClothesStrore.Application.Genders.UpdateGender;

namespace ClothesStrore.Application.Genders;

public interface IGenderService
{
    Task<string> DeleteGenderAsync(DeleteGenderRequest request, CancellationToken cancellationToken);
    Task<GetGenderByIdResponse> GetByIdAsync(GetGenderByIdRequest request, CancellationToken cancellationToken);
    Task<List<GetAllGenderResponse>> GetGendersAsync(GetAllGendersRequest request, CancellationToken cancellationToken);
    Task<string> CreateAsync(CreateGenderRequest request, CancellationToken cancellationToken);
    Task<string> UpateAsync(UpdateGenderCommand request, CancellationToken cancellationToken);

}
