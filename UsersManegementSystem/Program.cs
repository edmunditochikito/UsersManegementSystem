using Microsoft.EntityFrameworkCore;
using UsersManegementSystem.Data;
using UsersManegementSystem.Data.Repository;
using UsersManegementSystem.Data.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseNpgsql(builder.Configuration.GetConnectionString("ConexionSQL")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>();

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
    pattern: "{controller=Inicio}/{action=Index}/{id?}");

app.Run();
