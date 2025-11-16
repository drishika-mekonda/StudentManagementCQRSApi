using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentCqrsMediatRDemo.Behaviors;
using StudentCqrsMediatRDemo.Middlewares;
using StudentManagementCQRSApi.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Add Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//In-memory DB Service
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseInMemoryDatabase("StudentsDb"));

// MediatR Service
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Register Validation Behavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

//Configure Http request Pipeline
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();

