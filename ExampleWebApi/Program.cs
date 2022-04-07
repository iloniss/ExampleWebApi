using ExampleWebApi.APPLICATION.Services;
using ExampleWebApi.CORE.Repository;
using ExampleWebApi.INFRASTRUCTURE.Data;
using ExampleWebApi.INFRASTRUCTURE.Profiles;
using ExampleWebApi.INFRASTRUCTURE.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        actions => actions.MigrationsAssembly("ExampleWebApi.INFRASTRUCTURE"));
});

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
