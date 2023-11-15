
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Configuration;
using System;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

//strip configuration
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//forpayment
builder.Services.AddDbContext<Capstone1.Data.AppDbContext>(options => options.UseSqlite("Data Source = ./Data/AppDb.db"));

//for razor pages
builder.Services.AddRazorPages();



builder.Services.AddDbContext<Capstone1.Models.AllInformation>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DBConn")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";
var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";
app.MapGet("/", () => $"Hello {target}!");


app.UseHttpsRedirection();
app.UseCors();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//for razor
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(url);
