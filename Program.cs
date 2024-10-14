using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingList.WebApi.Models;
using ShoppingList.WebApi.Models.Domains;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddScoped<UnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<ShoppingListContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingListContext")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlParh = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlParh);
});

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
