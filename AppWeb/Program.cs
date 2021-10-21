using AppWeb.DataAccess.Context;
using AppWeb.Helpers;
using AppWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMultiTenancy()
    .WithResolutionStrategy<HostResolutionStrategy>()
    .WithStore<DbContextTenantStore>();

builder.Services.AddDbContext<TenantAdminDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TenantAdmin")));

builder.Services.AddDbContext<SingleTenantDbContext>();

builder.Services.AddTransient<ITenantAccessor<TenantDto>, TenantAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseMultiTenancy();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
