using ClothesStrore.Application.Sizes.DeleteSize;
using ClothesStrore.Application.Sizes.GetSizeById;
using ClothesStrore.Application.Sizes.GetSizes;
using ClothesStrore.Application.Sizes.InsertSizes;
using ClothesStrore.Application.Sizes.UpdateSize;

namespace ClothesStrore.Application.Sizes
{
    public interface ISizeService
    {
        Task<string> DeleteAsync(DeleteSizeRequest request, CancellationToken cancellationToken);
        Task<GetSizeByIdResponse> GetByIdAsync(GetSizeByIdRequest request, CancellationToken cancellationToken);
        Task<List<GetAllSizesResponse>> GetAsync(GetAllSizesRequest request, CancellationToken cancellationToken);
        Task<string> CreateAsync(CreateSizeRequest request, CancellationToken cancellationToken);
        Task<string> UpdateAsync(UpdateSizeCommand request, CancellationToken cancellationToken);
    }
}
