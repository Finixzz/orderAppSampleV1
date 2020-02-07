using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace orderAppSampleV1.Models
{
    public class Order
    {
       
        public int Id { get; set; }
            
        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int TableId { get; set; }

        public Table Table { get; set; }

        public string UserId { get; set; }

        public byte Quantity { get; set; }

        public DateTime Date { get; set; }
        
    }
}