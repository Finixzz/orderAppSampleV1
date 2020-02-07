using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using orderAppSampleV1.Models;

namespace orderAppSampleV1.ViewModels
{
    public class ItemFormViewModel
    {
        public IEnumerable <Item>Items { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}