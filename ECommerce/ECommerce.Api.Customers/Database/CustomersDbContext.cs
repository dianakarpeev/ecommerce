﻿using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Customers.Database
{
    public class CustomersDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set;}

        public CustomersDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
