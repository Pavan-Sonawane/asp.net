using Hotel_Domain.Models;
using Hotel_Repository.Context;
using Hotel_Repository.Repository;
using Hotel_Repository.Services.Custom_Services;
using Hotel_Repository.Services.General_Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<MainDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DemoSupplierItem"))
);

// Add Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// Add more repositories for other entities as needed

// Add Services
builder.Services.AddScoped<GuestService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<Reservation_Service>();
builder.Services.AddScoped<RoomService>();
// Add more services for other entities as needed

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
