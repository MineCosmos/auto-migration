using AutoSample;
using AutoSample.Data;
using Microsoft.EntityFrameworkCore;
using MineCosmos.EntityFrameworkCore.Migrations.Auto;
using MineCosmos.EntityFrameworkCore.Migrations.Auto.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SampleDbContext>(opts =>
{
    opts.UseSqlite("Data Source=sample.db");
});

builder.Services.AddAutoMigration<SampleDbContext>();

var app = builder.Build();

app.UseAutoMigration<SampleDbContext>(MigrationMode.Design);

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
