using Application.IServices;
using Application.Services;
using Domain.Interfaces;
using FluentValidation;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbContextMericurio>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IServiceService, ServiceService>();

builder.Services.AddTransient<IContactUsRepository, ContactUsRepository>();
builder.Services.AddTransient<IContactUsService, ContactUsService>();

builder.Services.AddTransient<IWhyUsRepository, WhyUsRepository>();
builder.Services.AddTransient<IWhyUsService, WhyUsService>();

builder.Services.AddTransient<IOverViewRepository, OverViewRepository>();
builder.Services.AddTransient<IOverViewService, OverViewService>();

builder.Services.AddTransient<IAboutUsSectionRepository, AboutUsSectionRepository>();
builder.Services.AddTransient<IAboutUsSectionService, AboutUsSectionService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);



var app = builder.Build();



// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/


app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
