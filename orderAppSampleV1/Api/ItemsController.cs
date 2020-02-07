using orderAppSampleV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using orderAppSampleV1.Dtos;

namespace orderAppSampleV1.Api
{
    public class ItemsController : ApiController
    {
        private ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }


        //GET
        [HttpGet]
        public IHttpActionResult GetItems()
        {
            var items = _context.Items
                .ToList()
                .Select(Mapper.Map<Item, ItemDto>);

            return Ok(items);
        }

        //GET
        [HttpGet]
        public IHttpActionResult GetItem(int id)
        {
            var itemInDb = _context.Items.Single(c => c.Id == id);

            if (itemInDb == null)
                return BadRequest();

            return Ok(Mapper.Map<Item,ItemDto>(itemInDb));
        }

        //POST
        [HttpPost]
        public IHttpActionResult CreateItem(ItemDto itemDto)
        {
            ModelState.Remove("itemDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            var item = Mapper.Map<ItemDto, Item>(itemDto);

            _context.Items.Add(item);
            _context.SaveChanges();

            itemDto.Id = item.Id;

            return Created(new Uri(Request.RequestUri + "/" + itemDto.Id), itemDto);
        }

        //PUT
        [HttpPut]
        public IHttpActionResult EditItem(ItemDto itemDto,int id)
        {
            ModelState.Remove("itemDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();


            var itemInDb = _context.Items.Single(c => c.Id == id);
            if (itemInDb == null)
                return NotFound();


            Mapper.Map(itemDto, itemInDb);
            _context.SaveChanges();
            return Ok(itemDto);
        }


        //DELETE
        [HttpDelete]
        public IHttpActionResult DeleteItem(int id)
        {
            var itemInDb = _context.Items.Single(c => c.Id == id);
            if (itemInDb == null)
                return NotFound();

            _context.Items.Remove(itemInDb);
            _context.SaveChanges();
           

            return Ok(itemInDb);
        }






    }
}
