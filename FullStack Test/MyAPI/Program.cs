using Microsoft.EntityFrameworkCore;

using Repository.Repository;
using Repository.Services.CustomServices.CartServices;
using Repository.Services.CustomServices.CategoryServices;
using Repository.Services.CustomServices.OrderItemServices;
using Repository.Services.CustomServices.OrderServices;
using Repository.Services.CustomServices.ProductServices;
using Repository.Services.GeneralServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MainDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DemoSupplierItem"))
);


/*builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IServices<>), typeof(Services<>));
builder.Services.AddTransient(typeof(ICategoryServices), typeof(CategoryServices));
builder.Services.AddTransient(typeof(IOrderServices), typeof(OrderServices));
builder.Services.AddTransient(typeof(IProductServices), typeof(ProductServices));*/
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IServices<>), typeof(Services<>));
builder.Services.AddTransient(typeof(ICategoryServices), typeof(CategoryServices));
builder.Services.AddTransient(typeof(IOrderServices), typeof(OrderServices));
builder.Services.AddTransient(typeof(IOrderItemServices), typeof(OrderItemservices));

builder.Services.AddTransient(typeof(IProductServices), typeof(ProductServices));
builder.Services.AddScoped(typeof(ICartServices), typeof(CartServices));
builder.Services.AddControllers();
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
