using ClothesStrore.Application.Product.DeleteProduct;
using ClothesStrore.Application.Product.GetProducts;
using ClothesStrore.Application.Product.InsertProduct;
using ClothesStrore.Application.Product.UnDeleteProduct;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ClothesStore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ApiControllerBase
{
    [HttpGet("get-all")]
    public async Task<ActionResult> GetAllProducts()
    {
        var result = await Mediator.Send(new GetAllProductsRequest());
        return Ok(result);
    }
    [HttpPost("create")]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductRequest payload)
    {
        var result = await Mediator.Send(payload);
        return Ok(result);
    }
    [HttpPut("delete-product")]
    public async Task<ActionResult> DeleteProduct([FromQuery] DeleteProductRequest request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }
    [HttpPut("undelete-product")]
    public async Task<ActionResult> UnDeleteProduct([FromQuery] UnDeleteProductRequest request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }
}
