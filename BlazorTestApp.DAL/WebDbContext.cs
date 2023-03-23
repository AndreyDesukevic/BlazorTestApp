using BlazorTestApp.DAL.DbModels;
using BlazorTestApp.DAL.Enum;
using BlazorTestApp.DAL.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL
{
    public class WebDbContext : DbContext
    {
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<User>? Users { get; set; }

        public WebDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
             .HasOne(order => order.Client)
             .WithMany(client => client.Orders)
             .HasForeignKey(order => order.ClientId);

            modelBuilder.Entity<User>(builder =>
            {
                builder.HasData(new User
                {
                    Id = 1,
                    Name="admin",
                    Password = HashPasswordHelper.HashPassword("123456789"),
                    Email="admin@admin.com",
                    Role = UserRole.Administrator,
                    IsBlocked = false
                });
                builder.ToTable("Users").HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            });
        }
    }
}
