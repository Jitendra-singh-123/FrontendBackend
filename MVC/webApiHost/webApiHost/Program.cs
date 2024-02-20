using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using webApiHost.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TasksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myconn") ?? throw new InvalidOperationException("Connection string 'TasksDbContext' not found.")));

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.PropertyNamingPolicy = null; // Disable property name camel casing
	options.JsonSerializerOptions.IgnoreNullValues = true; // Ignore null values when serializing
	options.JsonSerializerOptions.WriteIndented = true; // Write indented JSON for better readability
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:44327")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
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


app.UseCors("AllowSpecificOrigin");
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
