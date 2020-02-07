using orderAppSampleV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using orderAppSampleV1.Dtos;
using System.Data.SqlClient;

namespace orderAppSampleV1.Api
{
    public class OrdersController : ApiController
    {
        private ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }
        
        [HttpGet]
        public IHttpActionResult GetOrders()
        {
              var orderDtos = _context.Orders
                   .ToList()
                   .Select(Mapper.Map<Order, OrderDto>);
              return Ok(orderDtos);
          
        }

        private int generateOrderId()
        {
             var order = _context.Orders.OrderByDescending(x => x.Id).Take(1).Single();
             int uniqueId = order.Id;
             return ++uniqueId;
        }

        [HttpPost]
        public IHttpActionResult CreateOrder(OrderContentDto orderContentDto)
        {

            if (orderContentDto.ItemId == null)
                return BadRequest();

            orderContentDto.Id = generateOrderId();
            orderContentDto.Date = DateTime.Now;
            for (int i = 0; i < orderContentDto.ItemId.Count(); i++)
            {
                OrderDto orderedItemDto = new OrderDto()
                {
                    Id = orderContentDto.Id,
                    ItemId = orderContentDto.ItemId[i],
                    TableId = orderContentDto.TableId,
                    UserId = System.Diagnostics.Process.GetCurrentProcess().SessionId.ToString(),
                    Quantity = orderContentDto.Quantity[i],
                    Date = orderContentDto.Date

                };
                var orderedItem = Mapper.Map<OrderDto, Order>(orderedItemDto);
                _context.Orders.Add(orderedItem);
                _context.SaveChanges();

            }
            return Ok();
        }
    }
}
