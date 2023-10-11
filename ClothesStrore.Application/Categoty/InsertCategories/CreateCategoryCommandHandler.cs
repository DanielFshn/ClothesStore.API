using ClothesStore.Domain.Entities;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Categoty.InsertCategories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryRequest, string>
    {
        public ICategoryService _service { get; }
        public CreateCategoryCommandHandler(ICategoryService service) =>
            (_service) = (service);


        public async Task<string> Handle(CreateCategoryRequest request, CancellationToken cancellationToken) =>
            await _service.CreateCategoryAsync(request, cancellationToken);
     
    }
}
