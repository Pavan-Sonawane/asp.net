using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Context;
using Infrastrcture.Repository;
using Infrastrcture.Services.CustomServices.GenereService;
using Infrastrcture.Services.CustomServices.MovieCastServices;
using Infrastrcture.Services.CustomServices.MovieDirectionServices;
using Infrastrcture.Services.CustomServices.MovieGenereServices;
using Infrastrcture.Services.CustomServices.MovieService;
using Infrastrcture.Services.CustomServices.RatingServices;
using Infrastrcture.Services.CustomServices.ReviewerService;
using Infrastrcture.Services.General_Services;
using Infrastrcture.Services.General_Services.DirectorService;
using Infrastrcture.Services.General_Services.MovieService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region   Database Connection

builder.Services.AddDbContext<MainDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DemoSupplierItem"))
);
#endregion 

#region   COROS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
#endregion

#region  Dependency Injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IDirectorService, DirectorService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IReviewerService,ReviewerService>();
builder.Services.AddScoped<IRatingService,RatingService>();
builder.Services.AddScoped<IGenere,GenereService>();
builder.Services.AddScoped<IMovieGenere,MovieGenereService>();
builder.Services.AddScoped<IMovieDirectionService, MovieDirectionService>();
builder.Services.AddScoped<IMovieCastService, MovieCastService>();
#endregion

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    }); builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
