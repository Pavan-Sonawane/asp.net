using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Repository.EmployeeDbContext;
using Repository.Repository;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" }));

builder.Services.AddDbContext<EmployeeDb>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
}
app.UseCors(builder =>
{
builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();  

});

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images",
    EnableDefaultFiles = true
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
