

namespace ClothesStrore.Application.Categoty.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryRequest, string>
    {
        private readonly ICategoryService _service;
        public DeleteCategoryCommandHandler(ICategoryService service) =>
                    (_service) = (service);


        public async Task<string> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken) =>
            await _service.DeleteCategoryAsync(request, cancellationToken);

    }
}
