
using CarRentalProjectApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RoadReadyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myconnection") ?? throw new InvalidOperationException("Connection string 'myconnection' not found.")));




// Add services to the container.



builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Disable property name camel casing
    options.JsonSerializerOptions.IgnoreNullValues = true; // Ignore null values when serializing
    options.JsonSerializerOptions.WriteIndented = true; // Write indented JSON for better readability
});


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

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
