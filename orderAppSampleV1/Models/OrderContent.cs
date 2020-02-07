using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace orderAppSampleV1.Models
{
    public class OrderContent
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public List<int> ItemId { get; set; }

        [Required]
        public int TableId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public List<int> Quantity { get; set; }

        public DateTime Date { get; set; }
    }
}