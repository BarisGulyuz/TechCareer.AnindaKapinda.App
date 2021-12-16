using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
  public  class AnındaKapındaContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        //public AnındaKapındaContext(DbContextOptions<AnındaKapındaContext> options) : base(options)
        //{
            
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-3JM41IE\\ERP; database=AnındaKapındaStoreDb; integrated security=true;");
        }

        public AnındaKapındaContext()
        {
        }
    }
}
