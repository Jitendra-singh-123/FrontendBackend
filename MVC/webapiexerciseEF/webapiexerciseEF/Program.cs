using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using webapiexerciseEF.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<webapiexerciseEFContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Myconn") ?? throw new InvalidOperationException("Connection string 'Myconn' not found.")));



// Add services to the container.

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