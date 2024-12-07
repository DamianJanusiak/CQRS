using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CQRS.Data;
using Application;
using Infrastructure;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CQRSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CQRSContext") ?? throw new InvalidOperationException("Connection string 'CQRSContext' not found.")));

// Add services to the container.
builder.Services.AddRepository()
                .AddRequestHandlers()
                .AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "DemoAPI v1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
