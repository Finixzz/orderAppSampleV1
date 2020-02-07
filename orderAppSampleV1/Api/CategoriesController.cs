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
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/categories
        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            var categories = _context.Categories
                .ToList()
                .Select(Mapper.Map<Category, CategoryDto>);
            return Ok(categories);
        }

        //GET api/categories/1
        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            var category = _context.Categories.Single(c => c.Id == id);

            if (category == null)
                return NotFound();

            return Ok(Mapper.Map<Category, CategoryDto>(category));
        }


        //POST /api/categories
        [HttpPost]
        public IHttpActionResult CreateCategory(CategoryDto categoryDto)
        {
            ModelState.Remove("categoryDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            var category = Mapper.Map<CategoryDto, Category>(categoryDto);

            _context.Categories.Add(category);
            _context.SaveChanges();

            categoryDto.Id = category.Id;

            return Created(new Uri(Request.RequestUri + "/" + categoryDto.Id), categoryDto);
        }


        //PUT /api/categories/1
        [HttpPut]
        public IHttpActionResult EditCategory(CategoryDto categoryDto,int id)
        {
            ModelState.Remove("categoryDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            var categoryInDb = _context.Categories.Single(c => c.Id == id);
            if (categoryInDb == null)
                return NotFound();

            Mapper.Map(categoryDto, categoryInDb);
            _context.SaveChanges();

            return Ok(categoryDto);
        }

        //DELETE /api/categories/1
        public IHttpActionResult DeleteCategory(int id)
        {
            var categoryInDb = _context.Categories.Single(c => c.Id == id);
            if (categoryInDb == null)
                return NotFound();

            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();

            return Ok(Mapper.Map<Category, CategoryDto>(categoryInDb));
        }
    }
}
