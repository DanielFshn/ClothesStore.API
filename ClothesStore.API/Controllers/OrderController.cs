using ClothesStrore.Application.Orders.AddOrder;
using ClothesStrore.Application.Orders.GetOrders.GetOrderByUserId;
using ClothesStrore.Application.Orders.GetOrders.GetOrdersStatistics;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ApiControllerBase
{
    [HttpPost("add-order")]
    public async Task<ActionResult> CreateOrder([FromBody] AddOrderRequest request) =>
        Ok(await Mediator.Send(request));
    [HttpGet("orders")]
    public async Task<ActionResult> GetOrdersByUserId([FromQuery] GetOrdersByUserIdQuery request) =>
        Ok(await Mediator.Send(request));
    [HttpGet("statistics")]
    public async Task<ActionResult> GetOrdersStatistics([FromQuery] GetOrdersStatisticsQuery request) =>
        Ok(await Mediator.Send(request));
}
