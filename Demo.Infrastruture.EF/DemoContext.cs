using Demo.Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.Infrastruture.EF
{
    public class DemoContext:DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options)
          : base(options) { }
     
        public DbSet<Product> Products { get; set; }
    }
}
