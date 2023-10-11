namespace ClothesStrore.Application.Categoty.GetById;

public class GetCategoryByIdCommandHandler : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
{
    private readonly ICategoryService _service;
    public GetCategoryByIdCommandHandler(ICategoryService service) =>
        (_service) = (service); 
    
    

    public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken) =>
        await _service.GetCategoryByIdAsync(request, cancellationToken);
  
}
