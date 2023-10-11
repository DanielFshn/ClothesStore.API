namespace ClothesStrore.Application.Categoty.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, string>
    {
        private readonly ICategoryService _service;
        public UpdateCategoryCommandHandler(ICategoryService service) =>
            _service = service;
        public async Task<string> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken) =>
            await _service.UpdateCategoryAsync(request, cancellationToken);
        }
    }
