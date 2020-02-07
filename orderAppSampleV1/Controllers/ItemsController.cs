using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using orderAppSampleV1.Models;
using orderAppSampleV1.ViewModels;

namespace orderAppSampleV1.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {

            var items = new ItemFormViewModel()
            {
                Items=_context.Items.ToList(),
                Categories = _context.Categories.ToList()
            };
            return View(items);
        }


        public ActionResult NewItem()
        {
            var itemViewModel = new ItemFormViewModel()
            {
                Categories = _context.Categories.ToList()
            };
            return View(itemViewModel);
        }


        public ActionResult NewCategory()
        {
            return View();
        }
    }
}