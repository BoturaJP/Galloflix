using.GalloFlix.Data;
using.GalloFlix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Objetos auxiliares da Conexão
string conn =  builder.Configuration.GetConnectionString("GalloFlix");
string version = ServerVersion.AutoDetect(conn);

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseMysql(conn, version)
);

builder.services.AddIdentity<AppUser, IdentityRole>()
.AddIdentityFrameworkStores<AppDbContext>()
.AddfaultTokenProviders();

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
