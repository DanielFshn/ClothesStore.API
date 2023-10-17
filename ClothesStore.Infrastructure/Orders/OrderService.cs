using AutoMapper;
using ClothesStore.Domain.Entities;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.Orders;
using ClothesStrore.Application.Orders.AddOrder;
using ClothesStrore.Application.Orders.GetOrders.GetOrderByUserId;
using ClothesStrore.Application.Orders.GetOrders.GetOrdersStatistics;
using ClothesStrore.Application.Product;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace ClothesStore.Infrastructure.Orders
{
    internal class OrderService : IOrderService
    {
        public IMyDbContext _context { get; }
        public IMapper _mapper { get; }
        public IProductService _productService { get; }

        public OrderService(IMyDbContext context, IMapper mapper, IProductService productService) =>
                (_context, _mapper, _productService) = (context, mapper, productService);



        public async Task<string> AddOrderAsync(AddOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _mapper.Map<AddOrderRequest, Order>(request);
                order.CreatedOn = DateTime.Now;
                _context.Orders.Add(order);
                await _context.SaveToDbAsync();
                var adressId = Guid.NewGuid().ToString();
                var adress = new AdressDetail
                {
                    Id = adressId,
                    City = request.City,
                    Country = request.Country,
                    PostalCode = request.PostalCode,
                    StreetName = request.StreetName

                };
                _context.Adresses.Add(adress);
                await _context.SaveToDbAsync();
                var orderId = order.Id;
                var orderDetailEntities = _mapper.Map<List<OrderDetails>, List<OrderDetail>>(request.Products);
                foreach (var orderDetail in orderDetailEntities)
                {
                    orderDetail.AdressId = adressId;
                    orderDetail.OrderId = orderId;
                    orderDetail.Id = Guid.NewGuid().ToString();
                }
                _context.OrderDetails.AddRange(orderDetailEntities);
                await _context.SaveToDbAsync();
                return JsonConvert.SerializeObject(new { Message = "Order saved succesfully." });

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding order: {ex.Message}");
                throw; // Re-throw the exception after logging

            }
        }

        public async Task<List<GetOrdersByIdResponse>> GetOrderByUserIdAsync(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userIdParameter = new SqlParameter("@UserId", SqlDbType.NVarChar) { Value = request.id.ToString() };
            var query = _context.GetOrdersByIdResponses.FromSqlRaw("GetOrdersByUserId @UserId", userIdParameter);
            return await query.ToListAsync();
        }

        public async Task<List<GetOrdersStatisticsResponse>> InicializeOrderGraphAsync(GetOrdersStatisticsQuery request, CancellationToken cancellationToken)
        {
            var lastMonthStartsDate = DateTime.Now.AddMonths(-1).Date;
            var orderData = await _context.Orders.Where(o => o.CreatedOn >= lastMonthStartsDate)
                .GroupBy(o => o.CreatedOn.Date)
                .Select(g => new GetOrdersStatisticsResponse
                {
                    OrderDate = g.Key,
                    OrderCount = g.Count()
                })
                .OrderBy(entity => entity.OrderDate).ToListAsync();
            return orderData;
        }
    }
}
