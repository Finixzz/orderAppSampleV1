using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace orderAppSampleV1.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public int TableId { get; set; }

        public string UserId { get; set; }

        public byte Quantity { get; set; }

        public DateTime Date { get; set; }
    }
}