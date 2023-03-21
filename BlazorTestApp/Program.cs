using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorTestApp.DAL;
using Microsoft.EntityFrameworkCore;
using BlazorTestApp.DAL.Repositories;
using BlazorTestApp.DAL.DbModels;
using BlazorTestApp.BLL.Services.Implementations;
using BlazorTestApp.BLL.Services.Interfaces;
using AutoMapper;
using BlazorTestApp.BLL.Search.Interfaces;
using BlazorTestApp.BLL.Search.Implementations;
using BlazorTestApp.BLL.Sorting.Implementations;
using BlazorTestApp.BLL.Sorting.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<WebDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<IBaseRepository<Client>,ClientRepository>();
builder.Services.AddScoped<IBaseRepository<Order>,OrderRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ISearchOrder, SearchOrder>();
builder.Services.AddScoped<ISortingOrder,SortingOrder>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
