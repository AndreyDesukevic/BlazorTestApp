using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorTestApp.DAL;
using Microsoft.EntityFrameworkCore;
using BlazorTestApp.DAL.Repositories;
using BlazorTestApp.DAL.DbModels;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<WebDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<BaseRepository<Client>,ClientRepository>();
builder.Services.AddScoped<BaseRepository<Order>, OrderRepository>();



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
