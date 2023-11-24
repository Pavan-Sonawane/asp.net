using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using MovieApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<MovieDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3001")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS before other middleware
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
