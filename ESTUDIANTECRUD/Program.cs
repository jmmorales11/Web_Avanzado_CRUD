using Microsoft.EntityFrameworkCore;
using ESTUDIANTECRUD.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DBINSTITUCIONContext>(options =>
//Configuramos la conexion con la cadenaSQL la cual cntiene los datos para la conexion y esta en el archivo appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"))
);

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
