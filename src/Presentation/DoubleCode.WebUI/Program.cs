using System.Reflection;
using DoubleCode.Application;
using DoubleCode.Infrastructure;
using DoubleCode.Infrastructure.Persistence;
using DoubleCode.WebUI;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebUIServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "defult",
      pattern: "{controller=Home}/{action=Index}/{id?}");

}); app.Run();
