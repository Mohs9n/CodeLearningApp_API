using codegym_api.Data;
using codegym_api.Interfaces;
using codegym_api.Services;
using codegym_api.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddCors();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddDbContext<DataContext>(opts => opts.UseSqlite("Data source=codegym.db"));

builder.Services.AddScoped<ICodeExecutionService, CodeExecutionService>();
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

app.UseCors(corsBuilder => corsBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapIdentityApi<User>();
app.MapControllers();

app.Run();
