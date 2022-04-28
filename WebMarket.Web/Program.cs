using Microsoft.EntityFrameworkCore;
using WebMarket.DataAccess;
using WebMarket.DataAccess.Services;
using WebMarket.DataAccess.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefultConnection")
    ));

builder.Services.AddScoped<ICoverTypeService ,CoverTypeService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
//builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
