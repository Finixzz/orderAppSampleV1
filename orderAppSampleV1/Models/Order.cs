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
        [Key, Column(Order = 0),DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int TableId { get; set; }

        public Table Table { get; set; }

        public string UserId { get; set; }

        public int Quantity { get; set; }

        [Required,Key, Column(Order = 2), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime Date { get; set; }
        
    }
}