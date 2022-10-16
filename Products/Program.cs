using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Products.Repo;
using Products.Entities;
using Products.Repo.Interface;
using Products.Service.Implementation;
using Products.Service.Interface;
using Products.Repo.Implementation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer("Server=10.49.78.101;Database=Test1;user id=sa;password=P@ssw0rd;Connection Timeout=30;"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepo, Products.Repo.Implementation.ProductRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
