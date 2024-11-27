using Microsoft.EntityFrameworkCore;
using companhia_aerea.Models;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration["ConnectionStrings:DefaultConnection"];


builder.Services.AddDbContext<CompanhiaAereaContext>(
    options => options.UseSqlServer(connString)
    );


builder.Services.AddControllersWithViews();

var app = builder.Build();


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
