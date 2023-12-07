using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerce.Api.Orders.Database
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate {  get; set; }
        public double Total { get; set; }
        public DbSet<OrderItem> Items { get; set; }
    }
}
