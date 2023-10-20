using ClothesStrore.Application.Orders.AddOrder;
using ClothesStrore.Application.Orders.GetOrders.GetOrderByUserId;
using ClothesStrore.Application.Orders.GetOrders.GetOrdersStatistics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ApiControllerBase
{
    [HttpPost("add-order")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult> CreateOrder([FromBody] AddOrderRequest request) =>
        Ok(await Mediator.Send(request));
    [HttpGet("orders")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult> GetOrdersByUserId([FromQuery] GetOrdersByUserIdQuery request) =>
        Ok(await Mediator.Send(request));
    [HttpGet("statistics")]
    [Authorize(Roles = "Admin")]    
    public async Task<ActionResult> GetOrdersStatistics([FromQuery] GetOrdersStatisticsQuery request) =>
        Ok(await Mediator.Send(request));
}
