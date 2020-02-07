using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;


namespace orderAppSampleV1.Models
{
    public class Item
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }


        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

       
    }
}