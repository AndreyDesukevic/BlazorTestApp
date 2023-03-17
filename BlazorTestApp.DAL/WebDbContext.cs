using BlazorTestApp.DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL
{
    public class WebDbContext : DbContext
    {
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Order>? Orders { get; set; }

        public WebDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
             .HasOne(order => order.Client)
             .WithMany(client => client.Orders)
             .HasForeignKey(order => order.ClientId);
        }
    }
}
