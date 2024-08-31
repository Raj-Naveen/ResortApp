using Microsoft.EntityFrameworkCore;
using ResortApp.Application.Common.Interfaces;
using ResortApp.Infrastructure.Data;
using ResortApp.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add scoped dependency that whenever someone request an implementation of a IVillaRepository,
//the container should be able to give them implementation in VillaRepository class.

//builder.Services.AddScoped<IVillaRepository,VillaRepository>();


//Instead of adding individual dependency injection (all repository class)  to one UnitOfWork class.
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

//builder.Services.AddScoped<IRepository<T>, Repository<T>>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
