using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using _02_ETicaret.Application.Validations.Product;
using _03_ETicaret.Infrastructure_.Filters;
using _04_ETicaret.Persistence_.Context;
using _04_ETicaret.Persistence_.IoC;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using _03_ETicaret.Infrastructure_;
using _03_ETicaret.Infrastructure_.Services.Storage.Local;
using _03_ETicaret.Infrastructure_.Services.Storage.Azurex;
using _02_ETicaret.Application_;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

builder.Services.AddControllers(options => options.Filters.Add<ValidationFlter>()).ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true).AddJsonOptions(o=>
{
    o.JsonSerializerOptions.IncludeFields = true;
    o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
});

//builder.Services.AddStorage();
builder.Services.AddFluentValidation(conf => 
conf.RegisterValidatorsFromAssemblyContaining<CreateProductValidation>());

builder.Services.AddCors(opt =>
  opt.AddDefaultPolicy(
      policy =>
      policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
      .AllowAnyHeader()
      .AllowAnyMethod()
  )
);
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// PostgreSQL için DbContext’i yapýlandýr
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
Console.WriteLine($"[Connection Test] {connectionString}");

builder.Services.AddInfrastructureservices();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(_02_ETicaret.Application_.ServiceRegistration).Assembly);
});
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DependencyResolver());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
