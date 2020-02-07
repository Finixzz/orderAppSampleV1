using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using orderAppSampleV1.Models;
using orderAppSampleV1.Dtos;

namespace orderAppSampleV1.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Item, ItemDto>();
            Mapper.CreateMap<ItemDto, Item>();

            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();

            Mapper.CreateMap<Order, OrderDto>();
            Mapper.CreateMap<OrderDto, Order>();

            Mapper.CreateMap<OrderContent, OrderContentDto>();
            Mapper.CreateMap<OrderContentDto, OrderContent>();
        }
       




    }
}