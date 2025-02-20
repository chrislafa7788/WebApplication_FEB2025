using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication_FEB2025.AutoMappers;
using WebApplication_FEB2025.DTOs;
using WebApplication_FEB2025.Models;
using WebApplication_FEB2025.Repository;
using WebApplication_FEB2025.Services;
using WebApplication_FEB2025.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IPeopleService,PeopleService>();

builder.Services.AddSingleton<IRandomServiceSingleton, RandomServiceSingleton>();
builder.Services.AddScoped<IRandomServiceScoped, RandomServiceScoped>();
builder.Services.AddTransient<IRandomServiceTransient, RandomServiceTransient>();

builder.Services.AddScoped<IPostService, PostService>();


builder.Services.AddKeyedScoped<ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>, BeerService>("beerService");

//Repository
builder.Services.AddScoped<IRepository<Beer>, BeerRepository>();

//httpClient servicio jsonplaceholer.
builder.Services.AddHttpClient<IPostService,PostService>(c=>{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPost"]);
});

builder.Services.AddDbContext<StoreContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));

});

//Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

//validadores.

builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>();
builder.Services.AddScoped<IValidator<BeerUpdateDto>, BeerUpdateValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
