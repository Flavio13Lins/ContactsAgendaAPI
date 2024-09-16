using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAgendaAPI.Data;
using MyAgendaAPI.Repositories;
using MyAgendaAPI.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost8080",
            builder => builder
                .WithOrigins("http://localhost:8080")
                .AllowAnyHeader()
                .AllowAnyMethod()
            );
    });
builder.Services.AddControllers().AddJsonOptions(temp =>
    {
        temp.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        temp.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySQLConnection")));
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost8080");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
