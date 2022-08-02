using System;
using System.Collections.Generic;

namespace BookingSample.Data.Models
{
    public class ListOrder
    {
        public ListOrder()
        {
            this.items = new List<OrderDetail>();
        }

        public List<OrderDetail> items { get; set; }
    }
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
    }
}