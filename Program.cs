using Microsoft.EntityFrameworkCore;
using WebApi.Logic.Services;
using WebApplication1.Data;
using WebApplication1.Mapping;
using WebApplication1.Repositories;
using WebApplication1.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("----->Connection string:" + connectionString);
builder.Services.AddAutoMapper(typeof(MappingProfile));
//sql server connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<GroupRepository>();
builder.Services.AddScoped<TeacherRepository>();
builder.Services.AddScoped<GroupService>();
builder.Services.AddScoped<TeacherService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();