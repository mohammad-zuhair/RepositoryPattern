using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPatternWithUOW.core;
using RepositoryPatternWithUOW.core.Interfaces;
using RepositoryPatternWithUOW.EF;
using RepositoryPatternWithUOW.EF.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUnitOfWork ,UnitOfWork>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
option.UseSqlServer
(
    builder.Configuration.GetConnectionString("DefaultConnection"),
         b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)  
));


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
